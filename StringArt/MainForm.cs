using AnimatedGif;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringArt
{
    public partial class MainForm : Form
    {
        private Bitmap _originalImage;
        private readonly Bitmap _stringBitmap;


        private readonly int _panelSize;

        private PointF[] _edgePoints;
        private readonly List<Tuple<PointF, PointF>> _lines = new List<Tuple<PointF, PointF>>();


        private byte[] _imageGrayBytes;
        private int[] _stringImageGrayBytes;
        private int[] startingXForByteArray;

        private bool _stopArt = false;
        private bool _isArting = false;



        public MainForm()
        {
            InitializeComponent();

            _panelSize = picturePanel.Width;
            //ChooseImage(null, null);


            #region Initialize __stringBitmap
            _stringBitmap = new Bitmap(_panelSize, _panelSize, PixelFormat.Format32bppRgb);
            using (Graphics g = Graphics.FromImage(_stringBitmap))
            {
                g.Clear(Color.White);
            }

            #endregion
            #region Initialize _stringImageGrayBytes
            _stringImageGrayBytes = new int[_panelSize * _panelSize * 1 /*1 byte for grayness*/];
            for (int i = 0; i < _stringImageGrayBytes.Length; i++)
            {
                _stringImageGrayBytes[i] = 255;
            }
            #endregion
            #region Initialize startingXForByteArray (Commented)
            startingXForByteArray = new int[_panelSize];
            double radius = _panelSize / 2d;
            for (int i = 0; i < startingXForByteArray.Length / 2; i++)
            {
                //double asin = Math.Asin(i / radius);
                //startingXForByteArray[i] = (int)(Math.Cos(asin) * radius);
                //double part = (double)i / startingXForByteArray.Length;
                //double angle = 1.5 * Math.PI - part * Math.PI;
                //startingXForByteArray[i] = (int)(radius * 2 - (Math.Cos(angle) * radius));
                // startingXForByteArray[i] = (int)(radius - (radius / (Math.Sqrt(Math.Pow(Math.Tan(angle), 2) + 1))));
                //startingXForByteArray[i] = (int)Math.Sqrt(radius * radius - Math.Pow(i - radius, 2));

                //r^2 = x^2 + y^2
                //y^2 = r^2 - x^2
                // int y = (startingXForByteArray.Length / 2 - i - 1);

                //startingXForByteArray[i] = (int)Math.Sqrt(radius * radius - y * y);
                startingXForByteArray[i] = 0;
            }

            for (int i = startingXForByteArray.Length / 2; i < startingXForByteArray.Length; i++)
            {
                startingXForByteArray[i] = startingXForByteArray[startingXForByteArray.Length / 2 - (i - startingXForByteArray.Length / 2) - 1];
            }
            #endregion


            NumberOfEdgePointsNumericValueChanged(null, null);

        }
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        private static Bitmap ResizeImage(Image image, int width, int height, bool dispose)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            if (dispose)
            {
                image.Dispose();
            }
            return destImage;
        }

        // makes nice round ellipse/circle images from rectangle images
        private Bitmap ClipToCircle(Image srcImage, PointF center, float radius, bool dispose)
        {
            Bitmap dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);

            using (Graphics g = Graphics.FromImage(dstImage))
            {
                RectangleF r = new RectangleF(center.X - radius, center.Y - radius,
                    radius * 2, radius * 2);

                // enables smoothing of the edge of the circle (less pixelated)
                g.SmoothingMode = SmoothingMode.AntiAlias;

                //// fills background color
                //using (Brush br = new SolidBrush(backGround))
                //{
                //    g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
                //}

                // adds the new ellipse & draws the image again 
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(r);
                g.SetClip(path);
                g.DrawImage(srcImage, 0, 0);

                if (dispose)
                {
                    srcImage.Dispose();
                }
                return dstImage;
            }
        }

        private void PrepareOriginalImage(Image image)
        {
            Bitmap transformedImage = ClipToCircle(ResizeImage(image, _panelSize, _panelSize, true),
                new PointF(_panelSize / 2, _panelSize / 2), _panelSize, true);

            BitmapData transformedImageBitmapData = transformedImage.LockBits(
                new Rectangle(0, 0, _panelSize, _panelSize), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);


            Bitmap grayScaleImage = new Bitmap(_panelSize, _panelSize, PixelFormat.Format32bppRgb);

            BitmapData grayScaleImageBitmapData = grayScaleImage.LockBits(new Rectangle(0, 0, _panelSize, _panelSize),
                ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
            _imageGrayBytes = new byte[_panelSize * _panelSize * 1 /*1 byte for grayness*/];
            for (int y = 0; y < _panelSize; y++)
            {
                int transformedImageYOffset = transformedImageBitmapData.Stride * y;
                int grayScaleImageYOffset = grayScaleImageBitmapData.Stride * y;
                for (int x = 0; x < _panelSize; x++)
                {
                    unsafe
                    {
                        int transformedImageIndex = x * (32 / 8) + transformedImageYOffset;
                        int grayScaleImageIndex = x * (32 / 8) + grayScaleImageYOffset;
                        byte* transformedImagePtr = (byte*)transformedImageBitmapData.Scan0 + transformedImageIndex;
                        byte* grayScaleImagePtr = (byte*)grayScaleImageBitmapData.Scan0 + grayScaleImageIndex;
                        byte b = transformedImagePtr[0];
                        byte g = transformedImagePtr[1];
                        byte r = transformedImagePtr[2];

                        byte gray = (byte)(((b + g + r) / (Byte.MaxValue * 3f) * byte.MaxValue));

                        grayScaleImagePtr[0] = gray;
                        grayScaleImagePtr[1] = gray;
                        grayScaleImagePtr[2] = gray;
                        _imageGrayBytes[y * _panelSize + x] = gray;
                    }
                }
            }
            transformedImage.UnlockBits(transformedImageBitmapData);
            transformedImage.Dispose();
            grayScaleImage.UnlockBits(grayScaleImageBitmapData);

            _originalImage = grayScaleImage;
            picturePanel.Refresh();

        }

        private void PicturePanelPaint(object sender, PaintEventArgs e)
        {
            if (_originalImage != null)
            {
                e.Graphics.DrawImage(_originalImage, 0, 0);
            }
        }

        private void NumberOfEdgePointsNumericValueChanged(object sender, EventArgs e)
        {
            int edgePointsCount = (int)numberOfEdgePointsNumeric.Value;
            double angleChange = Math.PI * 2 / edgePointsCount;
            double currentAngle = 0;
            double radius = _panelSize / 2d;
            _edgePoints = new PointF[edgePointsCount];
            for (int i = 0; i < edgePointsCount; i++)
            {
                double x = Math.Cos(currentAngle) * radius + radius;
                double y = Math.Sin(currentAngle) * radius + radius;
                _edgePoints[i] = new PointF((float)x, (float)y);

                currentAngle += angleChange;
            }

            canvas.Refresh();
        }

        private void CanvasPaint(object sender, PaintEventArgs e)
        {

            if (_stringBitmap != null)
            {
                lock (_stringBitmap)
                {
                    e.Graphics.DrawImage(_stringBitmap, 0, 0);
                }
            }
            foreach (PointF edgePoint in _edgePoints)
            {
                const float r = 1f;
                e.Graphics.FillEllipse(Brushes.Red, new RectangleF(edgePoint.X - r, edgePoint.Y - r, r * 2, r * 2));
            }

        }

        private void ArtBtnClick(object sender, EventArgs e)
        {
            if (_isArting)
            {
                MessageBox.Show("Already drawing!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _isArting = true;
            _stopArt = false;

            if (firstComeFirstTakesRadioBtn.Checked)
            {
                int seed;
                if (customSeedCheckBox.Checked)
                {
                    seed = (int)randomizerSeedNumeric.Value;
                }
                else
                {
                    seed = Environment.TickCount;
                }

                Task.Run(() => FirstComeFirstTakesStringArt(seed));

            }
            else if (randomizerRadioBtn.Checked)
            {
                int seed;
                if (customSeedCheckBox.Checked)
                {
                    seed = (int)randomizerSeedNumeric.Value;
                }
                else
                {
                    seed = Environment.TickCount;
                }

                int linesTakenIntoConsideration = (int)randomizerLinesNum.Value;
                Task.Run(() => RandomizedStringArt(seed, linesTakenIntoConsideration));
            }
            else if (constantUpdateRadioBtn.Checked)
            {
                int seed;
                if (customSeedCheckBox.Checked)
                {
                    seed = (int)randomizerSeedNumeric.Value;
                }
                else
                {
                    seed = Environment.TickCount;
                }

                int linesTakenIntoConsideration = (int)randomizerLinesNum.Value;
                Task.Run(() => ConstantUpdateStringArt(seed, linesTakenIntoConsideration));
            }
            else
            {
                Task.Run(InefficientStringArt);
            }
        }

        private void ConstantUpdateStringArt(int seed, int linesTakenIntoConsideration)
        {
            Random random = new Random(seed);

            double lineAdditionDelta;
            double lineRemovalDelta;

            int lineChange = (int)lineChangeNumeric.Value;

            do
            {
                lineAdditionDelta = Double.NegativeInfinity;
                lineRemovalDelta = Double.NegativeInfinity;

                Tuple<PointF, PointF> edgesAdded = null;

                for (int i = 0; i < linesTakenIntoConsideration; i++)
                {
                    int edgePoint1Index = random.Next(_edgePoints.Length);
                    int edgePoint2Index = random.Next(_edgePoints.Length - 1);
                    if (edgePoint2Index == edgePoint1Index)
                    {
                        edgePoint2Index = _edgePoints.Length - 1;
                    }

                    PointF edgePoint1 = _edgePoints[edgePoint1Index];
                    PointF edgePoint2 = _edgePoints[edgePoint2Index];

                    long currentDelta = CalculateLineApplianceDifference(_stringImageGrayBytes, edgePoint1,
                        edgePoint2, lineChange, _imageGrayBytes);

                    if (currentDelta > lineAdditionDelta)
                    {
                        edgesAdded = new Tuple<PointF, PointF>(edgePoint1, edgePoint2);
                        lineAdditionDelta = currentDelta;
                    }
                }


                Console.WriteLine("ADD - ({0}, {1}) to ({2}, {3}) d = {4}", edgesAdded.Item1.X, edgesAdded.Item1.Y, edgesAdded.Item2.X,
                    edgesAdded.Item2.Y, lineAdditionDelta);
                if (lineAdditionDelta > 0)
                {
                    _lines.Add(edgesAdded);
                    //Connector connector = new Connector(edgesAdded.Item1, edgesAdded.Item2);

                    //if (_linesLayered.ContainsKey(connector))
                    //{
                    //    _linesLayered[connector]++;
                    //}
                    //else
                    //{
                    //    _linesLayered.Add(connector, 1);
                    //}

                    lock (_stringImageGrayBytes)
                    {
                        _stringImageGrayBytes =
                            ApplyLine(_stringImageGrayBytes, edgesAdded.Item1, edgesAdded.Item2, lineChange);
                    }
                }
                else
                {
                    Console.WriteLine("Addition delta is less than zero so line not added");
                }




                if (_lines.Count < 2)
                {
                    continue;
                }

                Tuple<PointF, PointF> edgesRemoved = null;
                int edgeRemovalIndex = -1;

                for (int i = 0; i < linesTakenIntoConsideration; i++)
                {
                    int lineIndex = random.Next(_lines.Count - 1); // no need to include the last index because we just added it
                    (PointF edgePoint1, PointF edgePoint2) = _lines[lineIndex];
                    long currentDelta = CalculateLineRemovalDifference(_stringImageGrayBytes, edgePoint1,
                        edgePoint2, lineChange, _imageGrayBytes);

                    if (currentDelta > lineRemovalDelta)
                    {
                        edgesRemoved = new Tuple<PointF, PointF>(edgePoint1, edgePoint2);
                        edgeRemovalIndex = lineIndex;
                        lineRemovalDelta = currentDelta;
                    }
                }


                if (lineRemovalDelta > 0)
                {
                    Console.WriteLine("REM (i={5}) - ({0}, {1}) to ({2}, {3}) d = {4}", edgesRemoved.Item1.X, edgesRemoved.Item1.Y, edgesRemoved.Item2.X,
                        edgesRemoved.Item2.Y, lineRemovalDelta, edgeRemovalIndex);
                    _lines.RemoveAt(edgeRemovalIndex);
                    //Connector connector = new Connector(edgesAdded.Item1, edgesAdded.Item2);

                    //if (_linesLayered.ContainsKey(connector))
                    //{
                    //    _linesLayered[connector]++;
                    //}
                    //else
                    //{
                    //    _linesLayered.Add(connector, 1);
                    //}

                    lock (_stringImageGrayBytes)
                    {
                        _stringImageGrayBytes =
                            RemoveLine(_stringImageGrayBytes, edgesRemoved.Item1, edgesRemoved.Item2, lineChange);
                    }
                }
                else
                {
                    //Console.WriteLine("delta is less than or equal to zero so line not removed");
                }




            } while ((lineAdditionDelta > 0 || lineRemovalDelta > 0) && !_stopArt);

            if (_stopArt)
            {
                Console.WriteLine("Arting stopped because user");
            }
            else
            {
                Console.WriteLine("Arting stopped because delta");
            }

            UpdateStringImageBitmap();
            _isArting = false;
        }

        private void InefficientStringArt()
        {
            double delta;

            int lineChange = (int)lineChangeNumeric.Value;

            do
            {
                delta = Double.NegativeInfinity;
                Tuple<PointF, PointF> edges = null;

                for (int i = 0; i < _edgePoints.Length; i++)
                {
                    PointF edgePoint1 = _edgePoints[i];
                    for (int j = 0; j < _edgePoints.Length; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        PointF edgePoint2 = _edgePoints[j];

                        //double currentDelta = CalculateDifference(_imageGrayBytes,
                        //    ApplyLine(_stringImageGrayBytes, edgePoint1, edgePoint2, lineChange));
                        long currentDelta = CalculateLineApplianceDifference(_stringImageGrayBytes, edgePoint1,
                            edgePoint2, lineChange, _imageGrayBytes);

                        if (currentDelta > delta)
                        {
                            edges = new Tuple<PointF, PointF>(edgePoint1, edgePoint2);
                            delta = currentDelta;
                        }
                    }
                }

                if (edges == null)
                {
                    break;
                }


                Console.WriteLine("({0}, {1}) to ({2}, {3}) d = {4}", edges.Item1.X, edges.Item1.Y, edges.Item2.X,
                    edges.Item2.Y, delta);
                if (delta > 0)
                {
                    _lines.Add(edges);
                    lock (_stringImageGrayBytes)
                    {
                        _stringImageGrayBytes =
                            ApplyLine(_stringImageGrayBytes, edges.Item1, edges.Item2, lineChange);
                    }
                }
                else
                {
                    Console.WriteLine("delta is less than or equal to zero so line not added and arting stopped");
                }
            } while (delta > 0 && !_stopArt);

            if (_stopArt)
            {
                Console.WriteLine("Arting stopped because user");
            }

            UpdateStringImageBitmap();
            _isArting = false;
        }

        private void RandomizedStringArt(int seed, int linesTakenIntoConsideration)
        {
            Random random = new Random(seed);

            double delta;

            int lineChange = (int)lineChangeNumeric.Value;

            do
            {
                delta = Double.NegativeInfinity;
                Tuple<PointF, PointF> edges = null;

                for (int i = 0; i < linesTakenIntoConsideration; i++)
                {
                    int edgePoint1Index = random.Next(_edgePoints.Length);
                    int edgePoint2Index = random.Next(_edgePoints.Length - 1);
                    if (edgePoint2Index == edgePoint1Index)
                    {
                        edgePoint2Index = _edgePoints.Length - 1;
                    }

                    PointF edgePoint1 = _edgePoints[edgePoint1Index];
                    PointF edgePoint2 = _edgePoints[edgePoint2Index];

                    long currentDelta = CalculateLineApplianceDifference(_stringImageGrayBytes, edgePoint1,
                        edgePoint2, lineChange, _imageGrayBytes);

                    if (currentDelta > delta)
                    {
                        edges = new Tuple<PointF, PointF>(edgePoint1, edgePoint2);
                        delta = currentDelta;
                    }
                }

                if (edges == null)
                {
                    break;
                }


                Console.WriteLine("({0}, {1}) to ({2}, {3}) d = {4}", edges.Item1.X, edges.Item1.Y, edges.Item2.X,
                    edges.Item2.Y, delta);
                if (delta > 0)
                {
                    _lines.Add(edges);
                    lock (_stringImageGrayBytes)
                    {
                        _stringImageGrayBytes =
                            ApplyLine(_stringImageGrayBytes, edges.Item1, edges.Item2, lineChange);
                    }
                }
                else
                {
                    Console.WriteLine("delta is less than or equal to zero so line not added and arting stopped");
                }
            } while (delta > 0 && !_stopArt);

            if (_stopArt)
            {
                Console.WriteLine("Arting stopped because user");
            }

            UpdateStringImageBitmap();
            _isArting = false;

        }

        private void FirstComeFirstTakesStringArt(int seed)
        {
            Random random = new Random(seed);

            double delta;

            int lineChange = (int)lineChangeNumeric.Value;


            int maxIterations = (int)(_edgePoints.Length * _edgePoints.Length * 1.5);

            do
            {
                delta = Double.NegativeInfinity;
                Tuple<PointF, PointF> edges = null;

                int currentIteration = 0;
                do
                {
                    int edgePoint1Index = random.Next(_edgePoints.Length);
                    int edgePoint2Index = random.Next(_edgePoints.Length - 1);
                    if (edgePoint2Index == edgePoint1Index)
                    {
                        edgePoint2Index = _edgePoints.Length - 1;
                    }

                    PointF edgePoint1 = _edgePoints[edgePoint1Index];
                    PointF edgePoint2 = _edgePoints[edgePoint2Index];

                    long currentDelta = CalculateLineApplianceDifference(_stringImageGrayBytes, edgePoint1,
                        edgePoint2, lineChange, _imageGrayBytes);

                    if (currentDelta > 0)
                    {
                        edges = new Tuple<PointF, PointF>(edgePoint1, edgePoint2);
                        delta = currentDelta;
                        break;
                    }

                    currentIteration++;
                } while (currentIteration < maxIterations);

                if (currentIteration >= maxIterations)
                {
                    Console.WriteLine("Reached max iterations ({0})", maxIterations);
                }

                if (edges == null)
                {
                    break;
                }


                Console.WriteLine("({0}, {1}) to ({2}, {3}) d = {4}", edges.Item1.X, edges.Item1.Y, edges.Item2.X,
                    edges.Item2.Y, delta);
                if (delta > 0)
                {
                    _lines.Add(edges);
                    lock (_stringImageGrayBytes)
                    {
                        _stringImageGrayBytes =
                            ApplyLine(_stringImageGrayBytes, edges.Item1, edges.Item2, lineChange);
                    }
                }
                else
                {
                    Console.WriteLine("delta is less than or equal to zero so line not added and arting stopped");
                }
            } while (delta > 0 && !_stopArt);

            if (_stopArt)
            {
                Console.WriteLine("Arting stopped because user");
            }

            UpdateStringImageBitmap();
            _isArting = false;

        }
        private void UpdateStringImageBitmap()
        {
            int[] bytes;
            lock (_stringImageGrayBytes)
            {
                bytes = (int[])_stringImageGrayBytes.Clone();
            }

            lock (_stringBitmap)
            {
                BitmapData stringImageBitmapData = _stringBitmap.LockBits(new Rectangle(0, 0, _panelSize, _panelSize),
                    ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);

                for (int y = 0; y < _panelSize; y++)
                {
                    int startingX = startingXForByteArray[y];
                    int endingX = _panelSize - startingX;
                    for (int x = startingX; x < endingX; x++)
                    {
                        unsafe
                        {
                            int grayValue = bytes[y * _panelSize + x];
                            byte grayValueByte = (byte)Math.Max(grayValue, 0);
                            byte* ptr = (byte*)stringImageBitmapData.Scan0 + y * stringImageBitmapData.Stride +
                                        x * (32 / 8);
                            ptr[0] = grayValueByte;
                            ptr[1] = grayValueByte;
                            ptr[2] = grayValueByte;
                        }
                    }
                }


                _stringBitmap.UnlockBits(stringImageBitmapData);
            }

            if (canvas.InvokeRequired)
            {
                canvas.Invoke(new Action(() => canvas.Refresh()));
            }
            else
            {
                canvas.Refresh();
            }
        }

        private long CalculateLineApplianceDifference(int[] grayImageData, PointF point1, PointF point2, int lineChange, byte[] comparisonByteArray)
        {
            long difference = 0;
            void Plot(int x, int y, double brightness)
            {
                if (y >= _panelSize)
                {
                    return;
                }

                int pixelValueIndex = y * _panelSize + x;

                int oldPixelValue = grayImageData[pixelValueIndex];
                byte oldPixelValueByte = (byte)Math.Max(oldPixelValue, 0);
                int newPixelValue = grayImageData[pixelValueIndex] - (int)(brightness * lineChange);
                byte newPixelValueByte =
                    (byte)Math.Max(newPixelValue, 0);

                byte targetPixelValue = comparisonByteArray[pixelValueIndex];

                int oldTargetDiff = Math.Abs(oldPixelValueByte - targetPixelValue);
                int newTargetDiff = Math.Abs(newPixelValueByte - targetPixelValue);

                int delta = oldTargetDiff - newTargetDiff;
                if (delta < 0)
                {
                    delta = (int)(delta * 2d);
                }

                difference += delta;
            }

            XiaolinWuLineAlgorithm.PlotLine(point1.X, point1.Y, point2.X, point2.Y, Plot);
            return difference;
        }

        private long CalculateLineRemovalDifference(int[] grayImageData, PointF point1, PointF point2, int lineChange, byte[] comparisonByteArray)
        {
            long difference = 0;
            void Plot(int x, int y, double brightness)
            {
                if (y >= _panelSize)
                {
                    return;
                }

                int pixelValueIndex = y * _panelSize + x;

                int oldPixelValue = grayImageData[pixelValueIndex];
                byte oldPixelValueByte = (byte)Math.Max(oldPixelValue, 0);

                int newPixelValue = Math.Min(grayImageData[pixelValueIndex] + (int)(brightness * lineChange), 255);
                byte newPixelValueByte =
                    (byte)Math.Max(newPixelValue, 0);


                byte targetPixelValue = comparisonByteArray[pixelValueIndex];

                int oldTargetDiff = Math.Abs(oldPixelValueByte - targetPixelValue);
                int newTargetDiff = Math.Abs(newPixelValueByte - targetPixelValue);

                int delta = oldTargetDiff - newTargetDiff;
                if (delta < 0)
                {
                    delta = (int)(delta * 1.25d);
                }

                difference += delta;
            }

            XiaolinWuLineAlgorithm.PlotLine(point1.X, point1.Y, point2.X, point2.Y, Plot);
            return difference;
        }


        private int[] ApplyLine(int[] grayImageData, PointF point1, PointF point2, int lineChange)
        {
            int[] newGrayImageData = (int[])grayImageData.Clone();
            void Plot(int x, int y, double brightness)
            {
                if (y >= _panelSize)
                {
                    return;
                }

                int pixelValueIndex = y * _panelSize + x;
                int oldPixelValue = grayImageData[pixelValueIndex];
                int newPixelValue = oldPixelValue - (int)(brightness * lineChange);
                newGrayImageData[pixelValueIndex] = newPixelValue;
            }

            XiaolinWuLineAlgorithm.PlotLine(point1.X, point1.Y, point2.X, point2.Y, Plot);
            return newGrayImageData;
        }


        private int[] RemoveLine(int[] grayImageData, PointF point1, PointF point2, int lineChange)
        {
            int[] newGrayImageData = (int[])grayImageData.Clone();
            void Plot(int x, int y, double brightness)
            {
                if (y >= _panelSize)
                {
                    return;
                }

                int pixelValueIndex = y * _panelSize + x;
                int oldPixelValue = grayImageData[pixelValueIndex];
                int newPixelValue = Math.Min(oldPixelValue + (int)(brightness * lineChange), 255);
                newGrayImageData[pixelValueIndex] = newPixelValue;
            }

            XiaolinWuLineAlgorithm.PlotLine(point1.X, point1.Y, point2.X, point2.Y, Plot);
            return newGrayImageData;
        }


        private unsafe void ApplyLine(int* grayImageData, PointF point1, PointF point2, int lineChange)
        {
            void Plot(int x, int y, double brightness)
            {
                if (y >= _panelSize)
                {
                    return;
                }

                int pixelValueIndex = y * _panelSize + x;
                int oldPixelValue = grayImageData[pixelValueIndex];
                int newPixelValue = oldPixelValue - (int)(brightness * lineChange);
                grayImageData[pixelValueIndex] = newPixelValue;
            }

            XiaolinWuLineAlgorithm.PlotLine(point1.X, point1.Y, point2.X, point2.Y, Plot);
        }


        //private double CalculateDifference(byte[] grayImageData1, byte[] grayImageData2)
        //{
        //    //  bool test = grayImageData1.SequenceEqual(grayImageData2);
        //    long diffrence = 0;
        //    for (int y = 0; y < _panelSize; y++)
        //    {
        //        for (int x = startingXForByteArray[y]; x < _panelSize; x++)
        //        {
        //            byte gray1 = grayImageData1[y * _panelSize + x];
        //            byte gray2 = grayImageData2[y * _panelSize + x];
        //            diffrence += gray2 - gray1;
        //        }
        //    }

        //    return diffrence;
        //}

        private void SaveLineDataBtnClick(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                DefaultExt = "*.tstringart",
                Filter = "Tal String Art File (*.tstringart)|*.tstringart"
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                using (FileStream fileStream = File.Create(saveFileDialog.FileName))
                {
                    int lineChangeValue = (int)lineChangeNumeric.Value;

                    fileStream.Write(BitConverter.GetBytes(lineChangeValue), 0, 4);
                    fileStream.Write(BitConverter.GetBytes(_edgePoints.Length), 0, 4);
                    foreach ((PointF point1, PointF point2) in _lines)
                    {
                        void WritePoint(PointF point)
                        {
                            fileStream.Write(BitConverter.GetBytes(point.X), 0, sizeof(float));
                            fileStream.Write(BitConverter.GetBytes(point.Y), 0, sizeof(float));
                        }
                        WritePoint(point1);
                        WritePoint(point2);
                    }
                    fileStream.Close();
                }
            }
        }

        private void UpdateImageBtnClick(object sender, EventArgs e)
        {
            UpdateStringImageBitmap();
        }

        private void StopArtBtn(object sender, EventArgs e)
        {
            _stopArt = true;
        }

        private void ClearArtBtnClick(object sender, EventArgs e)
        {
            lock (_stringBitmap)
            {
                using (Graphics g = Graphics.FromImage(_stringBitmap))
                {
                    g.Clear(Color.White);
                }
            }
            lock (_stringImageGrayBytes)
            {
                for (int i = 0; i < _stringImageGrayBytes.Length; i++)
                {
                    _stringImageGrayBytes[i] = 255;
                }
            }
            _lines.Clear();
            canvas.Refresh();
        }

        private void ChooseImage(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png",
                Title = "Choose image file",
                Multiselect = false
            })
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fileName = openFileDialog.FileName;
                Bitmap image;
                try
                {
                    image = new Bitmap(fileName);
                    PrepareOriginalImage(image);
                }
                catch
                {
                    MessageBox.Show("Cannot load image");

                }


                fileNameLbl.Text = openFileDialog.SafeFileName;
            }
        }

        private void FirstComeFirstTakesRadioBtnCheckedChanged(object sender, EventArgs e)
        {
            if (firstComeFirstTakesRadioBtn.Checked)
            {
                customSeedCheckBox.Enabled = true;
            }
        }

        private void RandomizerRadioBtnCheckedChanged(object sender, EventArgs e)
        {
            if (randomizerRadioBtn.Checked)
            {
                customSeedCheckBox.Enabled = true;
            }
        }

        private void BestFirstRadioBtnCheckedChanged(object sender, EventArgs e)
        {
            if (bestFirstRadioBtn.Checked)
            {
                customSeedCheckBox.Enabled = false;
                customSeedLbl.Enabled = false;
                randomizerSeedNumeric.Enabled = false;
            }
        }

        private void CustomSeedCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = customSeedCheckBox.Checked;
            customSeedLbl.Enabled = isChecked;
            randomizerSeedNumeric.Enabled = isChecked;
        }

        private void LoadLineDataBtnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                DefaultExt = "*.tstringart",
                Filter = "Tal String Art File (*.tstringart)|*.tstringart"
            })
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    lock (_stringImageGrayBytes)
                    {
                        lock (_stringBitmap)
                        {
                            using (FileStream fileStream = File.OpenRead(openFileDialog.FileName))
                            {
                                LoadStringArtFromFile(fileStream);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Couldn't load string art", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                canvas.Refresh();

            }




        }

        private unsafe void LoadStringArtFromFile(FileStream fileStream)
        {
            byte[] buffer = new byte[sizeof(int) + sizeof(int)];
            int read = fileStream.Read(buffer, 0, buffer.Length);
            if (read < buffer.Length)
            {
                MessageBox.Show("File may be corrupt", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            int lineChangeValue = BitConverter.ToInt32(buffer, 0);
            int edgePointsLength = BitConverter.ToInt32(buffer, sizeof(int));

            lineChangeNumeric.Value = lineChangeValue;

            numberOfEdgePointsNumeric.Value = edgePointsLength;

            buffer = new byte[sizeof(float) * 2 * 2];

            using (Graphics g = Graphics.FromImage(_stringBitmap))
            {
                g.Clear(Color.White);
            }


            for (int i = 0; i < _stringImageGrayBytes.Length; i++)
            {
                _stringImageGrayBytes[i] = 255;
            }

            fixed (int* stringImageGrayBytesPtr = _stringImageGrayBytes)
            {
                while (fileStream.Position < fileStream.Length)
                {
                    read = fileStream.Read(buffer, 0, buffer.Length);
                    if (read < buffer.Length)
                    {
                        MessageBox.Show("File may be corrupt", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        PointF point1 = new PointF(BitConverter.ToSingle(buffer, 0),
                            BitConverter.ToSingle(buffer, sizeof(float)));
                        PointF point2 = new PointF(BitConverter.ToSingle(buffer, sizeof(float) * 2),
                            BitConverter.ToSingle(buffer, sizeof(float) * 3));
                        _lines.Add(new Tuple<PointF, PointF>(point1, point2));
                        ApplyLine(stringImageGrayBytesPtr, point1, point2, lineChangeValue);
                    }
                }
            }
            UpdateStringImageBitmap();

        }

        private unsafe void CreateGifBtnClick(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Gif File|*.gif"
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;

                }

                string filePath = saveFileDialog.FileName;

                int timeInSeconds = int.Parse(Interaction.InputBox("Enter the length of the gif (in seconds)"));
                int framesPerSecond = int.Parse(Interaction.InputBox("Enter how many frames per second"));

                Bitmap frame;
                using (AnimatedGifCreator gif = AnimatedGif.AnimatedGif.Create(filePath, framesPerSecond))
                {
                    int[] frameBytes = new int[_panelSize * _panelSize * 1];
                    for (int i = 0; i < frameBytes.Length; i++)
                    {
                        frameBytes[i] = Byte.MaxValue;

                    }
                    frame = new Bitmap(_panelSize, _panelSize, PixelFormat.Format32bppRgb);
                    int split = _lines.Count / (timeInSeconds * framesPerSecond);
                    if (_lines.Count % (timeInSeconds * framesPerSecond) != 0)
                    {
                        split = _lines.Count / (timeInSeconds * framesPerSecond - 1);
                    }
                    int lineChange = (int)lineChangeNumeric.Value;
                    fixed (int* frameBytesPtr = frameBytes)
                    {
                        for (int i = 0; i < timeInSeconds; i++)
                        {
                            for (int j = 0; j < framesPerSecond; j++)
                            {
                                int startingLineIndex = (i * framesPerSecond + j) * split;
                                int endingLineIndex = Math.Min(_lines.Count, startingLineIndex + split);
                                Console.WriteLine("{0} - {1} out of {2}", startingLineIndex, endingLineIndex, _lines.Count);
                                for (int currentLineIndex = startingLineIndex; currentLineIndex < endingLineIndex; currentLineIndex++)
                                {
                                    (PointF point1, PointF point2) = _lines[currentLineIndex];
                                    ApplyLine(frameBytesPtr, point1, point2, lineChange);
                                }

                                BitmapData frameBitmapData = frame.LockBits(
                                    new Rectangle(0, 0, frame.Width, frame.Height),
                                    ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);

                                for (int y = 0; y < _panelSize; y++)
                                {
                                    for (int x = 0; x < _panelSize; x++)
                                    {

                                        int grayValue = frameBytesPtr[y * _panelSize + x];
                                        byte grayValueByte = (byte)Math.Max(grayValue, 0);
                                        byte* framePtr = (byte*)frameBitmapData.Scan0 + y * frameBitmapData.Stride +
                                                         x * (32 / 8);
                                        framePtr[0] = grayValueByte;
                                        framePtr[1] = grayValueByte;
                                        framePtr[2] = grayValueByte;

                                    }
                                }

                                frame.UnlockBits(frameBitmapData);

                                gif.AddFrame(frame, -3, GifQuality.Bit8);
                            }
                        }
                    }

                }

                frame.Dispose();

            }
        }

        private void ConstantUpdateRadioBtnCheckedChanged(object sender, EventArgs e)
        {
            if (constantUpdateRadioBtn.Checked)
            {
                customSeedCheckBox.Enabled = true;
            }
        }
    }
}
