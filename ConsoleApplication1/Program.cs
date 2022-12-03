using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace ConsoleApplication1 
{

    public static

    class Program
    {
        public static void Main(string[] args)
        {

            int nrProd = int.Parse(args[0]);
            int nrCons = int.Parse(args[1]);

            Buffer b = new Buffer();

            for(int i = 0; i < nrProd; i++)
            {
                Producer p = new Producer(b);
                
                Thread newThread = new Thread(p.produce);
                newThread.Start();
            }

            for (int i = 0; i < nrCons; i++)
            {
                Consumer c = new Consumer(b);

                Thread newThread = new Thread(c.consume);
                newThread.Start();
                
            }
            
            /*
            
            Producer p = new Producer(b);
            Producer p2 = new Producer(b);
            Consumer c = new Consumer(b);
            Consumer c2 = new Consumer(b);

            Thread producer = new Thread(p.produce);
            Thread producer2 = new Thread(p2.produce);
            Thread consumer = new Thread(c.consume);
            Thread consumer2 = new Thread(c2.consume);
            
            
            producer.Start();
            producer2.Start();
            consumer.Start();
            consumer2.Start();
*/
        }

        static void setAsleep()
        {
            Thread.Sleep(8000);
            Consumer.wakeUp();
        }
        
    }

    /*
    public class Test
    {
        private String output = "Hallo";
        private Mutex mutex = new Mutex();

        public void setOutput(string output)
        {
            this.output = output;
        }

        public string getOutput()
        {
            return this.output;
        }

        public Mutex getMutex()
        {
            return mutex;
        }

        public void runTest()
        {

            //Console.WriteLine(output);
            Thread.Sleep(50);

        }
    }

    public class ChangeOutput
    {
        Test test;
        private string changeTo;
        
        public ChangeOutput(Test test, String changeTo)
        {
            this.changeTo = changeTo;
            this.test = test;
        }
        
        public void badbad()
        {
            while (true)
            {
                Mutex m = test.getMutex();
                Thread.Sleep(1000);
                m.WaitOne();
                test.setOutput(changeTo);
                Console.WriteLine(changeTo);
                m.ReleaseMutex();
            }
        }
    }
    */
}
    



