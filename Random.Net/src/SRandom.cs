using System;

namespace SimpleX.Random
{
    using SimpleX.Random.Internal;

    // .Net提供的伪随机
    // 简单封装了一下
    public class SRandom : IRandom
    {
        private System.Random rand = null;

        public SRandom()
        {
            var seed = Const.Seed;
            rand = new System.Random(seed);
        }

        public SRandom(int seed)
        {
            rand = new System.Random(seed);
        }

        // [0.0, 1.0]
        public float Next()
        {
            var num = rand.Next(0, 99);
            return num / 99.0f;
        }

        // [min, max]
        public int Next(int min, int max)
        {
            return rand.Next(min, max);
        }
    }
}
