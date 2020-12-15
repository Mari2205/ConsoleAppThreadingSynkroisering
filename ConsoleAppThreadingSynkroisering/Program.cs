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
        static int numberOfChar = 0;
        static void Main(string[] args)
        {
            #region opg 1
            //Thread threadUP = new Thread(CountUp);
            //Thread threadDown = new Thread(CountDown);


            //threadUP.Start();
            ////Thread.Sleep(500);
            //threadDown.Start();
            #endregion

            #region opg 2,3
            Thread threadStar = new Thread(SixtyChars);
            Thread threadHashtag = new Thread(SixtyChars);

            threadStar.Start('*');
            Thread.Sleep(100);
            threadHashtag.Start('#');
            #endregion

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

        static void SixtyChars(object _char)
        {
            while (true)
            {
                Thread.Sleep(500);
                Monitor.Enter(beton);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {
                        numberOfChar++;
                        Console.Write(_char);

                    }
                    Console.WriteLine(numberOfChar);
                }
                finally
                {
                    Monitor.Exit(beton);
                }
            }
        }
    }
}
