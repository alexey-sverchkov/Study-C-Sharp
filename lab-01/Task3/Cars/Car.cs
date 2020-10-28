using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal abstract class Car
    {
        protected readonly String model;
        protected          String number;
        protected          int    speed;
        protected          int    liftingCapacity;

        public Car(String model, String number, int liftingCapacity, int speed = 0)
        {
            this.model = model;
            Number = number;
            Speed = speed;
            LiftingCapacity = liftingCapacity;
        }

        public String Model 
        {
            get
            {
                return model;
            } 
        }

        public String Number
        {
            get { return number; }
            set { number = value; }
        }
        public int Speed
        {
            get { return speed; }
            protected set
            {
                if (value < 0)
                {
                    Console.WriteLine("Error: speed can't be < 0");
                    speed = 0;
                }
                else
                {
                    speed = value;
                }
            }
        }
        public abstract int LiftingCapacity { get; set; }

        public override string ToString()
        {
            return ("Car [ Model = " + Model + 
                       ", Number = " + Number +
                       ", Speed = " + Speed +
                       ", LiftingCapacity = " + LiftingCapacity + " ]");
        }
    }
}
