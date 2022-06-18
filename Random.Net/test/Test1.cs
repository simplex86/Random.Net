using System;
using SimpleX.Random;

namespace SimpleX.Random.Test
{
    class Test1
    {
        private long costTime = 0;
        private const int count = 100000;

        public void Run()
        {
            var seed = GetSeed();

            var sr = new SRandom(seed);
            BeginProfiler();
            for (int i = 0; i < count; i++)
            {
                var num = sr.Next(1, 100);
            }
            EndProfiler();

            Console.WriteLine($"SRandom 耗时 {costTime} ms");

            var lr = new LRandom(seed);
            BeginProfiler();
            for (int i = 0; i < count; i++)
            {
                var num = lr.Next(1, 100);
            }
            EndProfiler();

            Console.WriteLine($"LRandom 耗时 {costTime} ms");

            var qr = new BRandom(seed);
            BeginProfiler();
            for (int i = 0; i < count; i++)
            {
                var num = qr.Next(1, 100);
            }
            EndProfiler();

            Console.WriteLine($"QRandom 耗时 {costTime} ms");
        }

        private int GetSeed()
        {
            var dt = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(dt.TotalSeconds);
        }

        private void BeginProfiler()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            costTime = Convert.ToInt64(ts.TotalMilliseconds);
        }

        private void EndProfiler()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            costTime = Convert.ToInt64(ts.TotalMilliseconds) - costTime;
        }
    }
}
