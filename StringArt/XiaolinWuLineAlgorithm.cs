using System;

namespace StringArt
{
    //https://rosettacode.org/wiki/Xiaolin_Wu%27s_line_algorithm#C#
    public static class XiaolinWuLineAlgorithm
    {

        private static int IntegerPart(double x) { return (int)x; }

        private static int Round(double x) { return IntegerPart(x + 0.5); }

        private static double FractionPart(double x)
        {
            if (x < 0)
            {
                return (1 - (x - Math.Floor(x)));
            }

            return (x - Math.Floor(x));
        }

        private static double InverseFractionPart(double x)
        {
            return 1 - FractionPart(x);
        }


        public static void PlotLine(double x0, double y0, double x1, double y1, Action<int, int, double> plotFunction)
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

            double xEnd = Round(x0);
            double yEnd = y0 + gradient * (xEnd - x0);
            double xGap = InverseFractionPart(x0 + 0.5);
            double xPixel1 = xEnd;
            double yPixel1 = IntegerPart(yEnd);

            if (steep)
            {
                plotFunction((int)yPixel1, (int)xPixel1, InverseFractionPart(yEnd) * xGap);
                plotFunction((int)yPixel1 + 1, (int)xPixel1, FractionPart(yEnd) * xGap);
            }
            else
            {
                plotFunction((int)xPixel1, (int)yPixel1, InverseFractionPart(yEnd) * xGap);
                plotFunction((int)xPixel1, (int)(yPixel1 + 1), FractionPart(yEnd) * xGap);
            }
            double intery = yEnd + gradient;

            xEnd = Round(x1);
            yEnd = y1 + gradient * (xEnd - x1);
            xGap = FractionPart(x1 + 0.5);
            double xPixel2 = xEnd;
            double yPixel2 = IntegerPart(yEnd);
            if (steep)
            {
                plotFunction((int)yPixel2, (int)xPixel2, InverseFractionPart(yEnd) * xGap);
                plotFunction((int)yPixel2 + 1, (int)xPixel2, FractionPart(yEnd) * xGap);
            }
            else
            {
                plotFunction((int)xPixel2, (int)yPixel2, InverseFractionPart(yEnd) * xGap);
                plotFunction((int)xPixel2, (int)yPixel2 + 1, FractionPart(yEnd) * xGap);
            }

            if (steep)
            {
                for (int x = (int)(xPixel1 + 1); x <= xPixel2 - 1; x++)
                {
                    plotFunction(IntegerPart(intery), x, InverseFractionPart(intery));
                    plotFunction(IntegerPart(intery) + 1, x, FractionPart(intery));
                    intery += gradient;
                }
            }
            else
            {
                for (int x = (int)(xPixel1 + 1); x <= xPixel2 - 1; x++)
                {
                    plotFunction(x, IntegerPart(intery), InverseFractionPart(intery));
                    plotFunction(x, IntegerPart(intery) + 1, FractionPart(intery));
                    intery += gradient;
                }
            }
        }
    }
}
