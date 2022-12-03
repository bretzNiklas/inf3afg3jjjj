
using System;



namespace ConsoleApplication1
{



    public class Car
    {
        static int carId = 0;
        private int thisCarId;

        public Car()
        {
            thisCarId = carId;
            carId++;
            Console.WriteLine("auto erstellt " + thisCarId);
        }

        public void count()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }

        public int getThisCarId()
        {
            return thisCarId;
        }


    }
}
