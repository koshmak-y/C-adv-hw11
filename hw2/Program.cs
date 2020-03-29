using System;
using System.Threading;

namespace hw2
{
    class Program
    {
        static readonly object locker = new object();
        static void Main(string[] args)
        {
            Random random = new Random();
            while (true)
            {
                Thread.Sleep(3000);
                new Thread(Method).Start();
            }
        }

        static void Method()
        {
            Random random = new Random();

            int CharacterCounter = random.Next(10, Convert.ToInt32(Console.WindowHeight / 3));
            int RandomCursorLeft = random.Next(0, Console.WindowWidth - 1);

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                lock (locker)
                {
                    if (i > 0)
                    {
                        Console.SetCursorPosition(RandomCursorLeft, i - 1);
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(RandomCursorLeft, i);
                    for (int k = 0; k < CharacterCounter; k++)
                    {
                        if (k == 0) Console.ForegroundColor = ConsoleColor.White;
                        if (k == 1) Console.ForegroundColor = ConsoleColor.Green;
                        if (k >= 2) Console.ForegroundColor = ConsoleColor.DarkGreen;
                        if (Console.CursorTop + 1 < Console.WindowHeight)
                        {
                            Console.SetCursorPosition(RandomCursorLeft, i + k);
                            Console.Write((char)random.Next(0x0040, 0x007E));
                        }
                        Thread.Sleep(25);
                    }
                    if (i == Console.WindowHeight - 1)
                    {
                        Console.SetCursorPosition(RandomCursorLeft, Console.WindowHeight - 1);
                        Console.Write(" ");
                    }
                }
            }
        }
    }
}
