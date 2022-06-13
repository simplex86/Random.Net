using System;
using SimpleX.Random;

namespace SimpleX.Random.Test
{
    class EfficiencyTest
    {
        private long costTime = 0;

        private const int seed = 123456789;
        private const int count = 100000;
        private static readonly DateTime Utc1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public void Run()
        {
            var sr = new SRandom(seed);
            BeginProfiler();
            for (int i = 0; i < count; i++)
            {
                var num = sr.Next(1, 100);
            }
            EndProfiler();

            Console.WriteLine($"SRandom const {costTime} ms");

            var lr = new LRandom(seed);
            BeginProfiler();
            for (int i = 0; i < count; i++)
            {
                var num = lr.Next(1, 100);
            }
            EndProfiler();

            Console.WriteLine($"LRandom const {costTime} ms");

            var qr = new BRandom(seed);
            BeginProfiler();
            for (int i = 0; i < count; i++)
            {
                var num = qr.Next(1, 100);
            }
            EndProfiler();

            Console.WriteLine($"QRandom const {costTime} ms");
        }

        private void BeginProfiler()
        {
            TimeSpan ts = DateTime.UtcNow - Utc1970;
            costTime = Convert.ToInt64(ts.TotalMilliseconds);
        }

        private void EndProfiler()
        {
            TimeSpan ts = DateTime.UtcNow - Utc1970;
            costTime = Convert.ToInt64(ts.TotalMilliseconds) - costTime;
        }
    }
}
