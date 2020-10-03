using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* ------------------ Task 2.1 ------------------ */
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


            /* ------------------ Task 2.2 ------------------ */
            Console.WriteLine("Rectangle[0] = {0}", rectangle[0]);
            Console.WriteLine("Rectangle[1] = {0}", rectangle[1]);

            rectangle++;

            rectangle.Print();

            if (rectangle)
            {
                Console.WriteLine("Rectangle is square");
            }

            int scalar = 4;
            rectangle *= scalar;

            Console.WriteLine("Rectagle after multiplying on scalar = {0}", scalar);
            rectangle.Print();

            String textRectangle = (string)rectangle;
            Console.WriteLine("String from Rectangle:");
            Console.WriteLine(textRectangle);

            Rectangle rectangle1 = (Rectangle)textRectangle;
            Console.WriteLine("Rectangle from string:");
            rectangle1.Print();
         
        }
    }

    public class Rectangle
    {
        private int a; // length
        private int b; // width

        public Rectangle() { }
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

        // indexator
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return a;
                    case 1: return b;
                    default: return -1;
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        a = value;
                        break;
                    case 1:
                        b = value;
                        break;

                }
            }
        }

        public static Rectangle operator ++(Rectangle rect)
        {
            ++rect.a;
            ++rect.b;
            return rect;
        }

        public static Rectangle operator --(Rectangle rect)
        {
            --rect.a;
            --rect.b;
            return rect;
        }

        public static bool operator true(Rectangle rect)
        {
            return rect.IsSquare ? true : false;
        }

        public static bool operator false(Rectangle rect)
        {
            return !rect.IsSquare ? true : false;
        }

        public static Rectangle operator *(Rectangle rect, int scalar)
        {
            rect.a *= scalar;
            rect.b *= scalar;
            return rect;
        }

        public static explicit operator string(Rectangle rect)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Rectangle: { length = " + rect.a + ", width = " + rect.b + " }");
            return sb.ToString();
        }

        public static explicit operator Rectangle(String strRectangle)
        {

            String[] numbers = Regex.Split(strRectangle, @"\D+");
            int[] arr = new int[2]; // array that contains values for Rectangle
            int j = 0;
            for(int i = 0; i < numbers.Length; ++i)
            {
                if (!String.IsNullOrEmpty(numbers[i]))
                {
                    arr[j] = int.Parse(numbers[i]);
                    ++j;
                }
            }
            return new Rectangle(arr[0], arr[1]);
        }
    }
}
