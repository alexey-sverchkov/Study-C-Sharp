using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Task3.Cars;

namespace Task3
{
    internal class CarManager
    {
        private List<Car> cars;

        public CarManager() 
        {
            cars = new List<Car>();
        }

        public Car[] Cars { get; }

        public void ReadFromXMLFile(String path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            XmlElement xRoot = xDoc.DocumentElement;

            foreach(XmlNode xnode in xRoot)
            {
                /* get common fields for each type of car */
                
                // get model of car
                XmlNode modelAttribute = xnode.Attributes.GetNamedItem("model");
                String model = "";
                if (modelAttribute != null)
                {
                    model = modelAttribute.Value;
                }

                String number = "";
                int liftingCapacity = 0;
                int speed = 0;

                foreach (XmlNode childNode in xnode.ChildNodes)
                {
                    switch (childNode.Name)
                    {
                        case "number":
                            number = childNode.InnerText;
                            break;
                        case "liftingCapacity":
                            liftingCapacity = int.Parse(childNode.InnerText);
                            break;
                        case "speed":
                            speed = int.Parse(childNode.InnerText);
                            break;
                        default:
                            break;
                    }
                }


                /*  get individual fields for each type of car 
                 *  add car to the array */
                switch (xnode.Name)
                {
                    case "passengerCar":
                    {
                        Car passengerCar = new PassengerCar(model, number, liftingCapacity, speed);
                        cars.Add(passengerCar);
                        break;
                    }

                    case "motorcycle":
                    {


                        bool hasSidecar = false;

                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            switch (childNode.Name)
                            {
                                case "hasSidecar":
                                    hasSidecar = bool.Parse(childNode.InnerText);
                                    break;
                                default:                                    
                                    break;
                            }
                        }

                        Car motocycle = new Motorcycle(model, number, liftingCapacity, speed, hasSidecar);
                        cars.Add(motocycle);
                        break;
                    }

                    case "truck":
                    {
                        bool hasTrailer = false;

                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            switch (childNode.Name)
                            {
                                case "hasTrailer":
                                    hasTrailer = bool.Parse(childNode.InnerText);
                                    break;
                                default:                                    
                                    break;
                            }
                        }
                        Car truck = new Truck(model, number, liftingCapacity, speed, hasTrailer);
                        cars.Add(truck);
                        break;
                    }

                    default:
                        Console.WriteLine("Warning: unknown type of car when reading from xml file");
                        break;
                }
            }
        }

        public void PrintCollection()
        {
            foreach(Car car in cars){
                Console.WriteLine(car.ToString());
            }
        }

        public List<Car> getCertainCars(int maxLiftingCapacity)
        {
            List<Car> result = new List<Car>();
            foreach(Car car in cars)
            {
                if (car.LiftingCapacity <= maxLiftingCapacity)
                {
                    result.Add(car);
                }
            }
            return result;
        }

        public List<Car> getCertainCars(int minLiftingCapacity, int maxLiftingCapacity)
        {
            List<Car> result = new List<Car>();
            foreach (Car car in cars)
            {
                if (minLiftingCapacity <= car.LiftingCapacity && car.LiftingCapacity <= maxLiftingCapacity)
                {
                    result.Add(car);
                }
            }
            return result;
        }
    }
}
