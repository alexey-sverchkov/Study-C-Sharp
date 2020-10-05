using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class PassengerCar : Car
    {
        public PassengerCar(String model, String number, int liftingCapacity, int speed = 0) 
            : base(model, number, liftingCapacity, speed)
        {
        }

        public override int LiftingCapacity
        {
            get { return liftingCapacity; }
            set 
            {
                if (value < 0)
                {
                    Console.WriteLine("Error: lifting capacity can't be < 0");
                    liftingCapacity = 0;
                }
                else
                {
                    liftingCapacity = value;
                }
            }
        }

        public override string ToString()
        {
            return "Passenger Car[ " + base.ToString() + " ]";
        }
    }
}
