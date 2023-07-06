using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_5
{
    internal class Program
    {
        static string logFilePath = "logfile.log";
        static object locOb = new object();

        static Semaphore semaphore = new Semaphore(2, 6, "Sim345788");


        public static void LogMenejaError(object ob)
        {
            Thread.Sleep(1000);
            semaphore.WaitOne();

            try
            {
                throw new Exception("Тут что то пошло не так: " + DateTime.Now + " ///  ");
            }
            catch (Exception ex)
            {
                lock (locOb)
                {
                    File.AppendAllText(logFilePath, ex.Message);
                }

                Console.WriteLine(ex.Message);
                Thread.Sleep(2000);
                Console.WriteLine("Записанно в logfile.log");
            }

            semaphore.Release();

        }


        static void Main()
        {

            ThreadPool.QueueUserWorkItem(LogMenejaError);
            ThreadPool.QueueUserWorkItem(LogMenejaError);
            ThreadPool.QueueUserWorkItem(LogMenejaError);
            ThreadPool.QueueUserWorkItem(LogMenejaError);
            ThreadPool.QueueUserWorkItem(LogMenejaError);

            Console.ReadKey();

        }
    }
}
