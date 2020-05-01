using System;

namespace StringArt
{
    public static class XiaolinWuLineAlgorithm
    {

        private static int ipart(double x) { return (int)x; }

        private static int round(double x) { return ipart(x + 0.5); }

        private static double fpart(double x)
        {
            if (x < 0)
            {
                return (1 - (x - Math.Floor(x)));
            }

            return (x - Math.Floor(x));
        }

        private static double rfpart(double x)
        {
            return 1 - fpart(x);
        }


        public static void PlotLine(double x0, double y0, double x1, double y1, Action<int, int, double> plot)
        {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            double temp;
            if (steep)
            {
                temp = x0; x0 = y0; y0 = temp;
                temp = x1; x1 = y1; y1 = temp;
            }
            if (x0 > x1)
            {
                temp = x0; x0 = x1; x1 = temp;
                temp = y0; y0 = y1; y1 = temp;
            }

            double dx = x1 - x0;
            double dy = y1 - y0;
            double gradient = dy / dx;

            double xEnd = round(x0);
            double yEnd = y0 + gradient * (xEnd - x0);
            double xGap = rfpart(x0 + 0.5);
            double xPixel1 = xEnd;
            double yPixel1 = ipart(yEnd);

            if (steep)
            {
                plot((int)yPixel1, (int)xPixel1, rfpart(yEnd) * xGap);
                plot((int)yPixel1 + 1, (int)xPixel1, fpart(yEnd) * xGap);
            }
            else
            {
                plot((int)xPixel1, (int)yPixel1, rfpart(yEnd) * xGap);
                plot((int)xPixel1, (int)(yPixel1 + 1), fpart(yEnd) * xGap);
            }
            double intery = yEnd + gradient;

            xEnd = round(x1);
            yEnd = y1 + gradient * (xEnd - x1);
            xGap = fpart(x1 + 0.5);
            double xPixel2 = xEnd;
            double yPixel2 = ipart(yEnd);
            if (steep)
            {
                plot((int)yPixel2, (int)xPixel2, rfpart(yEnd) * xGap);
                plot((int)yPixel2 + 1, (int)xPixel2, fpart(yEnd) * xGap);
            }
            else
            {
                plot((int)xPixel2, (int)yPixel2, rfpart(yEnd) * xGap);
                plot((int)xPixel2, (int)yPixel2 + 1, fpart(yEnd) * xGap);
            }

            if (steep)
            {
                for (int x = (int)(xPixel1 + 1); x <= xPixel2 - 1; x++)
                {
                    plot(ipart(intery), x, rfpart(intery));
                    plot(ipart(intery) + 1, x, fpart(intery));
                    intery += gradient;
                }
            }
            else
            {
                for (int x = (int)(xPixel1 + 1); x <= xPixel2 - 1; x++)
                {
                    plot(x, ipart(intery), rfpart(intery));
                    plot(x, ipart(intery) + 1, fpart(intery));
                    intery += gradient;
                }
            }
        }
    }
}
