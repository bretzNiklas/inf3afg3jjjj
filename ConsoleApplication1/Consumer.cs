using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ConsoleApplication1
{
    public class Consumer
    {
        private Buffer b;
        private Random r;
        private Boolean isAsleep;
        private static Boolean wakeConsumersUp;

        public Consumer(Buffer b)
        {
            this.b = b;
            r = new Random();
        }

        public void consume()
        {
            while (true)
            {
                if (isAsleep)
                {
                    Console.WriteLine("consumer asleep...");
                    Thread.Sleep(50);
                

                    if (wakeConsumersUp)
                    {
                        Console.WriteLine("consumer wurde aufgeweckt");
                        isAsleep = false;
                    }
                }
                else
                {
                    Thread.Sleep(r.Next(500, 1500));
                    Mutex m = b.getMutex();
                    m.WaitOne();

                    if (b.full())
                    {
                        Producer.wakeUp();
                    }
                    
                    if (!b.empty())
                    {
                        Car c = b.pop();
                        Console.WriteLine("Auto ausgeparkt " + c.getThisCarId());
                    }
                    else
                    {
                        wakeConsumersUp = false;
                        isAsleep = true;
                    }

                    m.ReleaseMutex();

                }
            }
        }
/*
        private void sleep()
        {
            while (isAsleep)
            {
                Console.WriteLine("asleep...");
                Thread.Sleep(50);
                

                if (wakeConsumersUp)
                {
                    Console.WriteLine("wurde aufgeweckt");
                    isAsleep = false;
                }
            }
        }
*/
        public static void wakeUp()
        {
            wakeConsumersUp = true;

        }
    }
}