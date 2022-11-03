using System.Drawing;

namespace StringArt
{
    public class AlgorithmParameters
    {
        public int Seed { get; }
        public int Alpha { get; }
        public PointF[] Edges { get; }

        public AlgorithmParameters(int seed, int alpha, PointF[] edges)
        {
            Seed = seed;
            Alpha = alpha;
            Edges = edges;
        }

    }
}
