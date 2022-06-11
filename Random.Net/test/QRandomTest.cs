using System;

namespace SimpleX.Random
{
    class QRandomTest
    {
        public void Run()
        {
            QRandom rand = new QRandom();

            for (int i = 0; i < 1000; i++)
            {
                var num = rand.Next(1, 10000);
                Console.WriteLine($"{num}");
            }
        }
    }
}
