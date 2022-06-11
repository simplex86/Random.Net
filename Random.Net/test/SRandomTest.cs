using System;

namespace SimpleX.Random
{
    class SRandomTest
    {
        public void Run()
        {
            SRandom rand = new SRandom();

            for (int i = 0; i < 1000; i++)
            {
                var num = rand.Next(1, 10000);
                Console.WriteLine($"{num}");
            }
        }
    }
}
