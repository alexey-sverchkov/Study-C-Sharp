using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string");
            String str = Console.ReadLine();
            String replacedStr = AppendSymbolAfterSymbol('x', 'y', str);
            Console.WriteLine("Modified string:\n{0}", replacedStr);

        }

        // appends symbol x after each occurence of symbol y in string
        static String AppendSymbolAfterSymbol(char x, char y, String str)
        {
            StringBuilder sb = new StringBuilder(str);
            String strToReplace = y.ToString() + x.ToString();
            sb.Replace(y.ToString(), strToReplace);
            return sb.ToString();
        }
    }
}
