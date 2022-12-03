using System;
using System.Threading;

namespace ConsoleApplication1
{

    
    public class Producer
    {
        private Buffer b;
        private Random r;
        private Boolean isAsleep;
        private static Boolean wakeProducersUp;


        public Producer(Buffer b)
        {
            r = new Random();
            this.b = b;
        }
        
        
        public void produce()
        {
            while (true)
            {
                if (isAsleep)
                {
                    Console.WriteLine("producer asleep...");
                    Thread.Sleep(50);

                    if (wakeProducersUp)
                    {
                        Console.WriteLine("producer wurde aufgeweckt");
                        isAsleep = false;
                    }
                }
                else
                {
                    Thread.Sleep(r.Next(500, 1500));
                    Mutex m = b.getMutex();
                    m.WaitOne();

                    if (b.empty())
                    {
                        Consumer.wakeUp();
                    }

                    if (!b.full())
                    {
                        Car c = new Car();
                        b.push(c);
                        Console.WriteLine("car " + c.getThisCarId() + " added");
                    }
                    else
                    {
                        wakeProducersUp = false;
                        isAsleep = true;
                        
                    }

                    m.ReleaseMutex();

                }
            }
        }

        public static void wakeUp()
        {
            wakeProducersUp = true;
        }
    }
    
}