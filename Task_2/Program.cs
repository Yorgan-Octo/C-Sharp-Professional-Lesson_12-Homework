using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_2
{
    internal class Program
    {
        //[ThreadStatic]
        public static int count = 0;

        public static void Method(object stat)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(count);
            Console.ResetColor();
            count++;

            if (count == 10)
            {
                count = 0;
                (stat as AutoResetEvent).Set();
            }

        }

        public static void Method2(object stat)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(count);
            Console.ResetColor();
            count++;

            if (count == 10)
            {
                count = 0;
                (stat as AutoResetEvent).Set();
            }

        }




        static void Main()
        {

            AutoResetEvent auto = new AutoResetEvent(false);
            TimerCallback timerCallback = new TimerCallback(Method);


            while (true)
            {
                Console.Clear();

                Timer timer1 = new Timer(timerCallback, auto, 1000, 500);
                auto.WaitOne();
                timer1.Dispose();


                Timer timer2 = new Timer(Method2, auto, 1000, 500);
                auto.WaitOne();
                timer2.Dispose();


                Console.WriteLine("Поченаем Звонову через!");

                Thread.Sleep(3000);
            }
        }
    }
}
