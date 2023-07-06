using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Program
    {

        static Mutex mutex = new Mutex(false, "NDB");

        public static void Method1(Object state)
        {
            mutex.WaitOne();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Method1 - " + i);
                Thread.Sleep(500);
            }

            Thread.Sleep(500);
            Console.WriteLine();
            mutex.ReleaseMutex();
        }

        public static void Method2(Object state)
        {
            mutex.WaitOne();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Method2 - " + i);
                Thread.Sleep(500);
            }
            Thread.Sleep(500);
            Console.WriteLine();
            mutex.ReleaseMutex();
        }

        static void Main()
        {
            Thread.Sleep(800);

            ThreadPool.QueueUserWorkItem(Method1);
            ThreadPool.QueueUserWorkItem(Method2);

            Console.ReadKey();
        }
    }
}
