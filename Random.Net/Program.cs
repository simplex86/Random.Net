using System;

namespace SimpleX.Random.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Efficiency Test");
            var test1 = new EfficiencyTest();
            test1.Run();
            Console.WriteLine("");

            Console.WriteLine("Repetition Period Test");
            var test2 = new RepetitionPeriodTest();
            test2.Run();
            Console.WriteLine("");

            Console.WriteLine("Distribution Test");
            var test3 = new DistributionTest();
            test3.Run();
            Console.WriteLine("");

            Console.ReadLine();
        }
    }
}
