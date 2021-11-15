using System;

namespace MessyExample.DelegatesSamples
{
    public class FunctionDelagates
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader("Function Delegates sample");
            Func<int> func1 = () => 1;
            Func<int, int> func2 = (i) => i * 10;
            Func<int, int, float> func3 = (a, b) => (float)(a / b);
            
            
            Console.WriteLine($"func1: {func1.Invoke()}; func2: {func2(10)}; func3: {func3.Invoke(1, 2):f}");
            

            ConsoleHelper.CreateFooter();
        }
    }
}