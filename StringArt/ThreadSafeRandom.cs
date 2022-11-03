using System;

namespace StringArt
{
    public class ThreadSafeRandom
    {
        [ThreadStatic] private static Random _local;

        public ThreadSafeRandom(int seed)
        {
            _local = new Random(seed);
        }

        public int Next()
        {
            return _local.Next();
        }
        public int Next(int max)
        {
            return _local.Next(max);
        }
    }
}
