using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Cars
{
    internal class Motorcycle : Car
    {
        private bool hasSidecar;

        public Motorcycle(String model, String number, int liftingCapacity, int speed = 0, bool hasSidecar = false) 
            : base(model, number, liftingCapacity, speed)
        {
            HasSidecar = hasSidecar;
            LiftingCapacity = liftingCapacity; // update lifting capacity because of sidecar
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
                else if (!hasSidecar)
                {                    
                    liftingCapacity = 0;
                }
                else
                {
                    liftingCapacity = value;
                }
            }
        }

        public bool HasSidecar
        {
            get { return hasSidecar; }
            set { hasSidecar = value; }
        }

        public override string ToString()
        {
            return "Motorcycle [" + base.ToString() + ", hasSidecar = " + hasSidecar + " ]";
        }
    }
}
