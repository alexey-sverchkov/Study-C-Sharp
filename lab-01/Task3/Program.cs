using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3;
using Task3.Cars;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager();
            carManager.ReadFromXMLFile("../../Input/cars.xml");
            Console.WriteLine("Loaded collection:");
            carManager.PrintCollection();

            int maxLiftingCapacity = 210;
            Car[] certainCars = carManager.getCertainCars(maxLiftingCapacity).ToArray();

            Console.WriteLine("\n\nCars with lifting capacity <= " + maxLiftingCapacity);
            foreach(Car car in certainCars)
            {
                Console.WriteLine(car.ToString());
            }

        }

        
    }
}
