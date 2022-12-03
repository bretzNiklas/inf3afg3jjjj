using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApplication1
{
    public class Buffer
    {
        private Queue<Car> carQueue;
        private int size = 10;
        private Mutex mutex;

        public Buffer()
        {
            mutex = new Mutex();
            carQueue = new Queue<Car>();
        }

        public void push(Car c)
        {
            if (carQueue.Count == size)
            {
                throw new Exception("Buffer voll");
            }
            

            carQueue.Enqueue(c);
        }

        public Car pop()
        {
            if (carQueue.Count == 0)
            {
                throw new Exception("Buffer leer");
            }

            return carQueue.Dequeue();
        }

        public bool full()
        {
            bool isFull = false;
            if (carQueue.Count == size)
            {
                isFull = true;
            }

            return isFull;
        }

        public bool empty()
        {
            if (carQueue.Count == 0)
            {
                return true;
            }

            return false;
        }

        public Mutex getMutex()
        {
            return this.mutex;
        }


    }
}