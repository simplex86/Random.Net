using System;
using System.Collections.Generic;
using SimpleX.Random;

namespace SimpleX.Random.Test
{
    class Test2
    {
        private const long REPEAT_TIMES = 100000000;

        public void Run()
        {
            var seed = GetSeed();

            var sp = GetRepetitionPeriod(new SRandom(seed));
            if (sp == REPEAT_TIMES)
            {
                Console.WriteLine($"SRandom 重复周期 > {sp}");
            }
            else
            {
                Console.WriteLine($"SRandom 重复周期 = {sp}");
            }

            var lp = GetRepetitionPeriod(new LRandom(seed));
            if (lp == REPEAT_TIMES)
            {
                Console.WriteLine($"LRandom 重复周期 > {lp}");
            }
            else
            {
                Console.WriteLine($"LRandom 重复周期 = {lp}");
            }

            var bp = GetRepetitionPeriod(new BRandom(seed));
            if (bp == REPEAT_TIMES)
            {
                Console.WriteLine($"BRandom 重复周期 > {bp}");
            }
            else
            {
                Console.WriteLine($"BRandom 重复周期 = {bp}");
            }
        }

        private int GetSeed()
        {
            var dt = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(dt.TotalSeconds);
        }

        // 获取重复周期
        private int GetRepetitionPeriod(IRandom rand)
        {
            List<int> random = new List<int>();
            List<int> shadow = new List<int>();

            long times = 0;
            while (times < REPEAT_TIMES)
            {
                var n = rand.Next(0, 10000);
                if (n < 0 || n > 10000)
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
