using System;

namespace MessyExample
{
    public class ConsoleHelper
    {
        public static void CreateHeader(string HeaderName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value: "-------------------------------");
            Console.WriteLine(value: HeaderName);
            Console.WriteLine(value: "++++++++++++++++++++++++++++");
            Console.ResetColor();
        }

        public static void CreateFooter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value: "-------------------------------");
            Console.ResetColor();
        }
    }
}