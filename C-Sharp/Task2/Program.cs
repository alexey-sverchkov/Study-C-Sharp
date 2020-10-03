using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(10, 12);
            rectangle.Print();
            Console.WriteLine("Perimeter: {0}", rectangle.CalculatePerimeter());
            Console.WriteLine("Square: {0}", rectangle.CalculateSquare());


            rectangle.Length = 100;
            Console.WriteLine("Rectangle after changing length: ");
            rectangle.Print();
            Console.WriteLine("Rectangle after changing width: ");
            rectangle.Width = 100;
            rectangle.Print();

            Console.WriteLine("Rectangle is square: {0}", rectangle.IsSquare);
        }
    }

    public class Rectangle
    {
        private int a; // length
        private int b; // width

        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public void Print() => Console.WriteLine("length = {0}, width = {1}", a, b);

        public int CalculatePerimeter() => 2 * (a + b);
        public int CalculateSquare() => a * b;

        public int Length
        {
            get { return a; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Error: value of length of rectangle can't be negative or zero");
                    return;
                }
                a = value;
            }
        }
        public int Width
        {
            get { return b; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Error: value of width of rectangle can't be negative or zero");
                    return;
                }
                b = value;
            }
        }
        public bool IsSquare
        {
            get => a == b ? true : false;
        }
    }
}
