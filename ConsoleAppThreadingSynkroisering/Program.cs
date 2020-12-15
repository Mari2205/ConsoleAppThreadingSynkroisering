using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleAppThreadingSynkroisering
{
    class Program
    {
        static int count = 0;
        static object beton = new object();
        static void Main(string[] args)
        {
            Thread threadUP = new Thread(CountUp);
            Thread threadDown = new Thread(CountDown);


            threadUP.Start();
            //Thread.Sleep(500);
            threadDown.Start();


            Console.ReadKey();
        }

        static void CountUp()
        {

            Monitor.Enter(beton);
            try
            {
                //while (true)
                //{
                Thread.Sleep(1000);
                count = count + 2;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ")  " + count);
                Console.ResetColor();
                //}
            }
            finally
            {
                Monitor.Exit(beton);
            }

        }

        static void CountDown()
        {
            Monitor.Enter(beton);
            try
            {
                //while (true)
                //{
                Thread.Sleep(1000);
                count = count - 1;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ")  " + count);

                //}
            }
            finally
            {
                Monitor.Exit(beton);
            }
        }
    }
}
