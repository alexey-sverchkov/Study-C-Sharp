using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;
            Console.WriteLine("Please enter size of array");
            size = Convert.ToInt32(Console.ReadLine());

            // create array
            int[] arr = new int[size];
            Random random = new Random();

            // fill array
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = random.Next(-10, 10);
            }

            Console.WriteLine("Array: ");
            Print(arr);
            ulong maxElements = countNumberOfMaxElements(arr);
            Console.WriteLine("Number of max elements in array: " + maxElements);
            ulong numberOfIncreases = countNumberOfIncreases(arr);
            Console.WriteLine("Number of elements, which value is greater than the value of the previous element: " + numberOfIncreases);

        }

        static ulong countNumberOfMaxElements(int[] arr)
        {
            ulong counter = 0;
            int max = Int32.MinValue;

            for(int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    counter = 1;
                }
                else if (arr[i] == max)
                {
                    ++counter;
                }
            }
            return counter;
        }   

        // returns number of elements, which value is greater than the value of the previous element
        static ulong countNumberOfIncreases(int[] arr)
        {
            ulong counter = 0;
            for(int i = 0; i < arr.Length - 1; ++i)
            {
                if (arr[i + 1] > arr[i])
                {
                    ++counter;
                }
            }
            return counter;
        }

        static void Print(int[] arr)
        {
            foreach (int elem in arr)
            {
                Console.Write(elem + "\t");
            }
            Console.WriteLine();
        }
    }
}
