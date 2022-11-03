using System.Drawing;

namespace StringArt
{
    public class RandomizerParameters : AlgorithmParameters
    {
        public int LinesTakenIntoConsideration { get; }

        public RandomizerParameters(int seed, int alpha, PointF[] edges, int linesTakenIntoConsideration) : base(seed, alpha, edges)
        {
            LinesTakenIntoConsideration = linesTakenIntoConsideration;
        }
    }
}
