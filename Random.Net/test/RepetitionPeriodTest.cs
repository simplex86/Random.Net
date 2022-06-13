using System;
using System.Collections.Generic;
using SimpleX.Random;

namespace SimpleX.Random.Test
{
    class RepetitionPeriodTest
    {
        private const int seed = 123456789;

        public void Run()
        {
            var sp = GetRepetitionPeriod(new SRandom(seed));
            Console.WriteLine($"SRandom period = {sp}");

            var lp = GetRepetitionPeriod(new LRandom(seed));
            Console.WriteLine($"LRandom period = {lp}");

            var bp = GetRepetitionPeriod(new BRandom(seed));
            Console.WriteLine($"BRandom period = {bp}");
        }

        // 获取重复周期
        private int GetRepetitionPeriod(IRandom rand)
        {
            List<int> random = new List<int>();
            List<int> shadow = new List<int>();

            long times = 0;
            while (times < 100000000)
            {
                var n = rand.Next(0, 100);
                if (n < 0 || n > 100)
                {
                    Console.WriteLine($"{rand.GetType().Name} Error: random num = {n}");
                    break;
                }
                random.Add(n);
                if (random.Count > 10)
                {
                    int index = shadow.Count;
                    if (random[index] == n)
                    {
                        shadow.Add(n);
                    }
                    else
                    {
                        shadow.Clear();
                    }
                }
                times++;

                if (shadow.Count >= 10) break;
            }
            return random.Count - shadow.Count;
        }
    }
}
