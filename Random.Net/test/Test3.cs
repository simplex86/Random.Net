using System;
using System.Collections.Generic;

namespace SimpleX.Random
{
    class Section
    {
        private int min;
        private int max;

        public int count { get; private set; } = 0;

        public Section(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public bool Hit(int num)
        {
            if (min <= num && max >= num)
            {
                count++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            count = 0;
        }

        public string ToString()
        {
            return $"[{min}, {max}]: {count}";
        }
    }

    class Test3
    {
        private List<Section> sections = new List<Section>(10);

        private const int min = 1;
        private const int max = 100000000;

        public Test3()
        {
            var s = 10;
            var n = 0;
            var x = 0;
            var v = max / s;

            for (int i=0; i<s; i++)
            {
                n = min + (i * v);
                x = n + v - min;

                sections.Add(new Section(n, x));
            }
        }

        public void Run()
        {
            var seed = GetSeed();

            var sr = new SRandom(seed);
            Run(sr);

            var lr = new LRandom(seed);
            Run(lr);

            var br = new BRandom(seed);
            Run(br);
        }

        private void Run(IRandom random)
        {
            for (int i = 0; i < 1000; i++)
            {
                var r = random.Next(min, max);
                foreach (var s in sections)
                {
                    if (s.Hit(r)) continue;
                }
            }
            Console.WriteLine($"{random.GetType().Name}的分布");
            foreach (var s in sections)
            {
                Console.WriteLine(s.ToString());
                s.Reset();
            }
        }

        private int GetSeed()
        {
            var dt = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(dt.TotalSeconds);
        }
    }
}
