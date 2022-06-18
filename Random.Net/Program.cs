using System;

namespace SimpleX.Random.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("效率测试");
                var test1 = new Test1();
                test1.Run();
                Console.WriteLine("");

                Console.WriteLine("重复周期测试（耗时较长，请耐心等待）");
                var test2 = new Test2();
                test2.Run();
                Console.WriteLine("");

                Console.WriteLine("分布测试");
                var test3 = new Test3();
                test3.Run();
                Console.WriteLine("");

                Console.WriteLine("输入 exit 退出，其他任意字符继续");
                if ("exit" == Console.ReadLine()) break;

                Console.Clear();
            }
        }
    }
}
