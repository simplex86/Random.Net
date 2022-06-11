using System;

namespace SimpleX.Random
{
    class LRandomTest
    {
        public void Run()
        {
            LRandom rand = new LRandom();

            for (int i = 0; i < 100; i++)
            {
                var num = rand.Next(1, 10);
                Console.WriteLine($"{num}");
            }
        }
    }
}
