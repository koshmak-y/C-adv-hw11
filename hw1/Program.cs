using System;
using System.Threading;

namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            Method();
            while (true)
            {
                Thread.Sleep(500);
                Console.WriteLine($"{Thread.CurrentThread.GetHashCode()} ID \t Main Thread");
            }
        }

        static void Method()
        {
            Thread.Sleep(100);
            Console.WriteLine($"\t\t\t{Thread.CurrentThread.GetHashCode()} \tID Method Thread");
            ThreadStart threadStart = new ThreadStart(Method);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

    }
}
