using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* --------------------TASK 1 ----------------------  */
            Console.WriteLine("Task 1: Replace all positive elements in array/matrix with negative ones");
            Console.WriteLine("Please, enter size of array");
            int size;
            size = Convert.ToInt32(Console.ReadLine());

            // create array
            int[] arr = new int[size];
            Random random = new Random();
            
            // fill array
            for(int i = 0; i < arr.Length; ++i)
            {
                arr[i] = random.Next(-100, 100);
            }

            Console.WriteLine("Array before changing positive numbers sign:");
            Print(arr);
            ChangePositiveNumbersSign(arr);
            Console.WriteLine("Array after changing positive numbers sign:");
            Print(arr);

            Console.WriteLine("\nPlease, enter number of rows of matrix");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, enter number of columns of matrix");
            int cols = Convert.ToInt32(Console.ReadLine()); ;

            int[,] matrix = new int[rows, cols];
            for(int i = 0; i < rows; ++i)
            {
                for(int j = 0; j < cols; ++j)
                {
                    matrix[i,j] = random.Next(-100, 100); // some random initialization
                }
            }

            Console.WriteLine("\nMatrix before changing positive numbers sign:");
            Print(matrix);
            ChangePositiveNumbersSign(matrix);
            Console.WriteLine("\nMatrix after changing positive numbers sign:");
            Print(matrix);


            /* --------------------TASK 2 ----------------------  */
            Console.WriteLine("\n\nTask 2: Replace all items which get int [a, b] with zero");
            int a = -50;
            int b = 50;
            Console.WriteLine("a = {0}, b = {1}", a, b);

            Console.WriteLine("Array before replacement:");
            Print(arr);
            ReplaceWithZero(a, b, arr);
            Console.WriteLine("Array after replacement");
            Print(arr);

            Console.WriteLine("\nMatrix before replacement:");
            Print(matrix);
            ReplaceWithZero(a, b, matrix);
            Console.WriteLine("Matrix after replacement");
            Print(matrix);


            /* --------------------TASK 3 ----------------------  */
            int numberOfOddElems = getNumberOfOddElements(arr);
            Console.WriteLine("\n\nNumber of odd elements in array: " + numberOfOddElems);
            numberOfOddElems = getNumberOfOddElements(matrix);
            Console.WriteLine("Number of odd elements in matrix: " + numberOfOddElems);


        }

        static void Print(int[] arr)
        {
            foreach(int elem in arr)
            {
                Console.Write(elem + "\t");
            }
            Console.WriteLine();
        }

        static void Print(int[,] matrix)
        {
            int numberOfRows = matrix.GetUpperBound(0) + 1;
            int numberOfColumns = matrix.Length / numberOfRows;
            for(int i = 0; i < numberOfRows; ++i)
            {
                for(int j = 0; j < numberOfColumns; ++j)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void ChangePositiveNumbersSign(int[] arr)
        {
            for(int i = 0; i < arr.Length; ++i)
            {           
                if (arr[i] > 0)
                {
                    arr[i] *= -1;
                }
            }
        }

        static void ChangePositiveNumbersSign(int[,] matrix)
        {
            int numberOfRows = matrix.GetUpperBound(0) + 1;
            int numberOfColumns = matrix.Length / numberOfRows;
            for(int i = 0; i < numberOfRows; ++i)
            {
                for(int j = 0; j < numberOfColumns; ++j)
                {
                    if (matrix[i, j] > 0)
                    {
                        matrix[i, j] *= -1;
                    }
                }
            }
        }

        // replace all items which get in [a, b] with zero
        static void ReplaceWithZero(int a, int b, int[] arr)
        {
            for(int i = 0; i < arr.Length; ++i)
            {
                if (a <= arr[i] && arr[i] <= b)
                {
                    arr[i] = 0;
                }
            }
        }

        static void ReplaceWithZero(int a, int b, int[,] matrix)
        {
            int numberOfRows = matrix.GetUpperBound(0) + 1;
            int numberOfColumns = matrix.Length / numberOfRows;
            for (int i = 0; i < numberOfRows; ++i)
            {
                for (int j = 0; j < numberOfColumns; ++j)
                {
                    if (a <= matrix[i,j] && matrix[i,j] <= b)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }

        static int getNumberOfOddElements(int[] arr)
        {
            int res = 0;
            for(int i = 0; i < arr.Length; ++i)
            {               
                if (Math.Abs(arr[i]) % 2 == 1)
                {
                    ++res;
                }
            }
            return res;
        }

        static int getNumberOfOddElements(int[,] matrix)
        {
            int numberOfRows = matrix.GetUpperBound(0) + 1;
            int numberOfColumns = matrix.Length / numberOfRows;
            int res = 0;
            for(int i = 0; i< numberOfRows; ++i)
            {
                for(int j = 0; j < numberOfColumns; ++j)
                {
                    if (Math.Abs(matrix[i, j]) % 2 == 1)
                    {
                        ++res;
                    }
                }
            }
            return res;
        }
    }
}
