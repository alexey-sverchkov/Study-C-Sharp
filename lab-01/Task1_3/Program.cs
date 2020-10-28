using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_3
{
    class Program
    {
        static void Main(string[] args)
        {         
            Console.WriteLine("Please, enter size of square matrix");
            int size = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[size, size];

            // fill matrix;
            Random random = new Random();
            for(int i = 0; i < size; ++i)
            {
                for(int j = 0; j < size; ++j)
                {
                    matrix[i, j] = random.Next(-100, 100);
                }
            }
            Console.WriteLine("Matrix:");
            Print(matrix);

            double mean = GetArithmeticMeanOfUpperElements(matrix);
            Console.WriteLine("Arithmetic mean of elements, which located upper the main diagonal is: " + mean);
        }

        // returns arithmetic mean of elements which located upper the main diagonal
        static double GetArithmeticMeanOfUpperElements(int[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int colums = matrix.Length / rows;
            int sum = 0;
            int numberOfElems = 0;
            for(int i = 0; i < rows; ++i)
            {
                for(int j = i + 1; j < colums; ++j)
                {
                    sum += matrix[i, j];
                    ++numberOfElems;
                }
            }
            double mean = (double)(sum) / numberOfElems;
            return mean;
        }

        static void Print(int[,] matrix)
        {
            int numberOfRows = matrix.GetUpperBound(0) + 1;
            int numberOfColumns = matrix.Length / numberOfRows;
            for (int i = 0; i < numberOfRows; ++i)
            {
                for (int j = 0; j < numberOfColumns; ++j)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
