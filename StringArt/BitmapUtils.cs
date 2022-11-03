using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace StringArt
{
    // ReSharper disable once UnusedMember.Global
    public static class BitmapUtils
    {
        public static Bitmap ClipToCircle(this Image srcImage, PointF center, float radius)
        {
            Bitmap dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);
            using (Graphics g = Graphics.FromImage(dstImage))
            {
                RectangleF r = new RectangleF(center.X - radius, center.Y - radius,
                    radius * 2, radius * 2);

                // enables smoothing of the edge of the circle (less pixelated)
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.Clear(Color.White);

                // adds the new ellipse & draws the image again 
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(r);
                g.SetClip(path);
                g.DrawImage(srcImage, 0, 0);


                srcImage.Dispose();

                return dstImage;
            }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap Resize(this Image image, int width, int height)
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
            image.Dispose();

            return destImage;
        }

        public static Bitmap ToGrayScale(this Bitmap bitmap, out byte[] grayscaleBytes)
        {
            // TODO: maybe parallel this? and use a more appropriate image format
            // for the output image
            int width = bitmap.Width;
            int height = bitmap.Height;
            Bitmap grayScaleImage;
            BitmapData grayScaleImageBitmapData;
            using (bitmap)
            {
                BitmapData transformedImageBitmapData = bitmap.LockBits(
                    new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);

                grayScaleImage = new Bitmap(width, height, PixelFormat.Format32bppRgb);
                grayScaleImageBitmapData = grayScaleImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                grayscaleBytes = new byte[width * height * 1 /*1 byte for grayness*/];
                for (int y = 0; y < height; y++)
                {
                    int transformedImageYOffset = transformedImageBitmapData.Stride * y;
                    int grayScaleImageYOffset = grayScaleImageBitmapData.Stride * y;
                    for (int x = 0; x < width; x++)
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
                            grayscaleBytes[y * width + x] = gray;
                        }
                    }
                }
                bitmap.UnlockBits(transformedImageBitmapData);
            }

            grayScaleImage.UnlockBits(grayScaleImageBitmapData);
            return grayScaleImage;
        }

    }
}
