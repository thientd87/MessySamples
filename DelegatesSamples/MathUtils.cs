using System;

namespace MessyExample.DelegatesSamples
{
    public class MathUtils
    {
        // (int, int) -> (int)
        public static int Sum(int a, int b)
        {
            return a + b;
        }

        // (int, int) -> (int)
        public static int Minus(int a, int b)
        {
            return a - b;
        }

        // (int, int) -> (int)
        public static int Multiple(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            return b != 0 ? a / b : 0;
          
        }
    }

    public class MyMathDelegate
    {
        delegate int IntIntToInt(int a, int b);

        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader(HeaderName: "Delegate Int-Int-To-Int sample");
           
            
            IntIntToInt intIntToInt = new IntIntToInt(MathUtils.Sum);
            int value1 = intIntToInt(a: 10, b: 20);
            Console.WriteLine(value: $"Sum Value = {value1}");

            intIntToInt = new IntIntToInt(MathUtils.Minus);
            int value2 = intIntToInt(a: 10, b: 20);
            Console.WriteLine(value: $"Minus Value = {value2}");
            
            intIntToInt = new IntIntToInt(MathUtils.Multiple);
            int value3 = intIntToInt(a: 10, b: 20);
            Console.WriteLine(value: $"Minus Value = {value3}");

            // non static method
            MathUtils math = new MathUtils();
            intIntToInt = new IntIntToInt(math.Divide);
            int value4 = intIntToInt(a: 20, b: 10);
            Console.WriteLine(value: $"Divide Value = {value4}");
            
           ConsoleHelper.CreateFooter();
        }
    }
}