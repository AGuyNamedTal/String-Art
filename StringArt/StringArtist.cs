using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;

namespace StringArt
{
    public class StringArtist
    {
        /// <summary>
        /// The width of the input/output image
        /// </summary>
        private readonly int _width;
        /// <summary>
        /// The height of the input/output image
        /// </summary>
        private readonly int _height;
        /// <summary>
        /// The bytes of the image gray values (1 byte per pixel)
        /// </summary>
        private readonly byte[] _inputGrayBytes;

        /// <summary>
        /// Starting X for each Y value when working on the image (should represent a circle/ellipse)
        /// </summary>
        //todo: maybe from int[] to byte[]/short[]?
        private readonly int[] _startingXForByteArray;


        /// <summary>
        /// The updated output bitmap
        /// </summary>
        public Bitmap OutputBitmap { get; private set; }
        /// <summary>
        /// The output bitmap gray bytes, 4 bytes for each gray value, one gray value for each pixel. This is so we can have negative gray values or gray values larger than 255 so when we remove lines after adding them we can know the 
        /// </summary>
        private int[] _outputGrayBytes;

        private readonly object _outputGrayBytesLock = new object();

        public readonly List<Tuple<PointF, PointF>> LinesDrawn = new List<Tuple<PointF, PointF>>();


        /// <summary>
        /// When getting, it generates a new clone
        /// </summary>

        private int[] OutputGrayBytesSynced
        {
            get
            {
                int[] clone;
                lock (_outputGrayBytesLock)
                {
                    clone = (int[])_outputGrayBytes.Clone();
                }

                return clone;
            }
            set
            {
                lock (_outputGrayBytesLock)
                {
                    _outputGrayBytes = value;
                }
            }
        }


        public StringArtist(Bitmap outputBitmap, byte[] inputGrayBytes)
        {
            _width = outputBitmap.Width;
            _height = outputBitmap.Height;
            OutputBitmap = outputBitmap;
            _outputGrayBytes = new int[_width * _height];
            _inputGrayBytes = inputGrayBytes;
            _startingXForByteArray = new int[_height];
            PrepareStartingXForByteArray();
        }

        private void PrepareStartingXForByteArray()
        {
            // TODO: https://en.wikipedia.org/wiki/Ellipse
        }

        private static byte LimitToByte(int integer)
        {
            return (byte)Math.Max(Math.Min(integer, 255), 0);
        }

        public Task StartRandomizerAsync(RandomizerParameters parameters, CancellationToken cancellationToken)
        {
            return Task.Run(() => StartRandomizer(parameters.Seed, parameters.LinesTakenIntoConsideration, parameters.Alpha, parameters.Edges, cancellationToken), cancellationToken);
        }

        private void StartRandomizer(int seed, int linesTakenIntoConsideration, int alpha, PointF[] edges, CancellationToken cancellationToken)
        {
            ThreadSafeRandom random = new ThreadSafeRandom(seed);

            // Like cost, but opposite meaning
            int lineChange = alpha;
            object benefitLock = new object();
            double benefit;

            Stopwatch stopwatch = Stopwatch.StartNew();
            int[] outputGrayBytes = OutputGrayBytesSynced;
            do
            {
                benefit = Double.NegativeInfinity;
                Tuple<PointF, PointF> currentEdge = null;
                Parallel.For(0L, linesTakenIntoConsideration,
                    new ParallelOptions
                    {
                        CancellationToken = cancellationToken,
                        MaxDegreeOfParallelism = Environment.ProcessorCount
                    }, i =>
                    {
                        int edge1Index = random.Next(edges.Length);
                        int edge2Index = random.Next(edges.Length - 1);
                        if (edge2Index == edge1Index)
                        {
                            edge2Index = edges.Length - 1;
                        }

                        PointF edge1 = edges[edge1Index];
                        PointF edge2 = edges[edge2Index];

                        long currentDelta = CalculateLineApplianceDifference(outputGrayBytes, edge1,
                            edge2, lineChange, _inputGrayBytes);
                        lock (benefitLock)
                        {
                            if (currentDelta > benefit)
                            {
                                currentEdge = new Tuple<PointF, PointF>(edge1, edge2);
                                benefit = currentDelta;
                            }
                        }
                    });
                if (currentEdge == null)
                {
                    break;
                }

                Console.WriteLine("({0}, {1}) to ({2}, {3}) d = {4}", currentEdge.Item1.X, currentEdge.Item1.Y, currentEdge.Item2.X,
                    currentEdge.Item2.Y, benefit);
                if (benefit > 0)
                {
                    LinesDrawn.Add(currentEdge);
                    ApplyLine(ref outputGrayBytes, currentEdge.Item1, currentEdge.Item2, lineChange);
                    OutputGrayBytesSynced = outputGrayBytes;
                }
            } while (benefit > 0);
            stopwatch.Stop();

            Console.WriteLine("Time took: {0}", stopwatch.Elapsed.ToString());
        }


        public unsafe void CreateOutputBitmap()
        {
            int[] outputGrayBytes = OutputGrayBytesSynced;

            Bitmap outputBitmap;
            lock (OutputBitmap)
            {
                outputBitmap = (Bitmap)OutputBitmap.Clone();
            }

            BitmapData bitmapData = outputBitmap.LockBits(new Rectangle(0, 0, _width, _height),
                ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb); //TODO: maybe use argb?


            for (int y = 0; y < _height; y++)
            {
                int startingX = _startingXForByteArray[y];
                int endingX = _width - startingX;
                for (int x = startingX; x < endingX; x++)
                {
                    int grayValue = outputGrayBytes[y * _width + x];
                    byte grayValueByte = LimitToByte(grayValue);
                    byte* bitmapDataPtr = (byte*)bitmapData.Scan0 + y * bitmapData.Stride +
                                          x * (32 / 8);
                    const int bytesToCopy = 3;
                    for (int i = 0; i < bytesToCopy; i++)
                    {
                        bitmapDataPtr[i] = grayValueByte;
                    }
                }
            }
            outputBitmap.UnlockBits(bitmapData);
            lock (OutputBitmap)
            {
                OutputBitmap?.Dispose();
                OutputBitmap = outputBitmap;
            }

            //if (canvas.InvokeRequired)
            //{
            //    canvas.Invoke(new Action(() => canvas.Refresh()));
            //}
            //else
            //{
            //    canvas.Refresh();
            //}
        }


        private void ApplyLine(ref int[] grayBytes, PointF point1, PointF point2, int lineChange)
        {
            void Plot(int x, int y, double brightness)
            {
                if (y >= _height)
                {
                    return;
                }

                int pixelValueIndex = y * _width + x;
                int oldPixelValue = grayBytes[pixelValueIndex];
                int newPixelValue = oldPixelValue - (int)Math.Round(brightness * lineChange);
                grayBytes[pixelValueIndex] = newPixelValue;
            }

            XiaolinWuLineAlgorithm.PlotLine(point1.X, point1.Y, point2.X, point2.Y, Plot);
        }
        private long CalculateLineApplianceDifference(int[] grayImageData, PointF point1, PointF point2, int lineChange, byte[] targetBytes)
        {
            long difference = 0;
            void Plot(int x, int y, double brightness)
            {
                if (y >= _height)
                {
                    return;
                }

                int pixelValueIndex = y * _width + x;

                int oldPixelValue = grayImageData[pixelValueIndex];
                byte oldPixelValueByte = LimitToByte(oldPixelValue);
                int newPixelValue = grayImageData[pixelValueIndex] - (int)Math.Round(brightness * lineChange);
                byte newPixelValueByte = LimitToByte(newPixelValue);

                byte targetPixelValue = targetBytes[pixelValueIndex];

                int oldTargetDiff = Math.Abs(oldPixelValueByte - targetPixelValue);
                oldTargetDiff *= oldTargetDiff;
                int newTargetDiff = Math.Abs(newPixelValueByte - targetPixelValue);
                newTargetDiff *= newTargetDiff;

                int currentDelta = oldTargetDiff - newTargetDiff;
                if (currentDelta < 0)
                {
                    currentDelta = (int)(currentDelta * 2d);
                }

                difference += currentDelta;
            }

            XiaolinWuLineAlgorithm.PlotLine(point1.X, point1.Y, point2.X, point2.Y, Plot);
            return difference;
        }
    }
}
