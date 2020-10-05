using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Cars
{
    internal class Truck : Car
    {
        private bool hasTrailer;

        public Truck(String model, String number, int liftingCapacity, int speed = 0, bool hasTrailer = false)
            : base(model, number, liftingCapacity, speed)
        {
            HasTrailer = hasTrailer;
            LiftingCapacity = liftingCapacity; // update lifting capacity because of trailer
        }

        public bool HasTrailer
        {
            get { return hasTrailer; }
            set { hasTrailer = value; }
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
                else if (hasTrailer)
                {
                    liftingCapacity = 2 * value;
                }
                else
                {
                    liftingCapacity = value;
                }
            }
        }

        public override string ToString()
        {
            return "Truck [ " +  base.ToString() + ", HasTrailer: " + hasTrailer + " ]";
        }

    }
}
