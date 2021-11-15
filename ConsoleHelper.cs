using System;

namespace MessyExample
{
    public class ConsoleHelper
    {
        public static void CreateHeader(string HeaderName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------------------");
            Console.WriteLine(HeaderName);
            Console.WriteLine("++++++++++++++++++++++++++++");
            Console.ResetColor();
        }

        public static void CreateFooter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------------------");
            Console.ResetColor();
        }
    }
}