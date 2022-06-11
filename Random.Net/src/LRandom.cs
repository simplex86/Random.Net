using System;

namespace SimpleX.Random
{
    using SimpleX.Random.Internal;

    // 线性同余伪随机
    // 详情见《计算机程序设计艺术》.卷2.第三章
    public class LRandom : IRandom
    {
        private long s = 0;

        private const long a = 1103515245;
        private const long b = 15107;
        private const long m = 838859327;

        public LRandom()
        {
            s = Const.Seed;
        }

        public LRandom(int seed)
        {
            s = (long)seed;
        }

        // [0.0, 1.0]
        public float Next()
        {
            s = (s * a + b) % m;
            return (float)(s / (double)m);
        }

        // [min, max]
        public int Next(int min, int max)
        {
            var mod = Next();
            max = max - min;

            return (int)Math.Floor(mod * max + min);
        }
    }
}