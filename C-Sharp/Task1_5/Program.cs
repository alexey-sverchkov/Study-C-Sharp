using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string");
            String message = Console.ReadLine();
            Console.WriteLine("Please enter substring");
            String substr = Console.ReadLine();
            PrintWordsWithGivenSubstring(message, substr);
        }

        static void PrintWordsWithGivenSubstring(String message, String substr)
        {
            String pattern = @"\W+";
            String[] words = System.Text.RegularExpressions.Regex.Split(message, pattern);
            Console.WriteLine("Words which contains substring: {0}", substr);
            foreach(String word in words){
                if (word.Contains(substr))
                {
                    Console.Write(word + "\t");
                }
            }
        }
    }
}
