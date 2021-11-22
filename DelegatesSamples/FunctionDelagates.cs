using System;

namespace MessyExample.DelegatesSamples
{
    public class FunctionDelagates
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader(HeaderName: "Function Delegates sample");
            Func<int> func1 = () => 1;
            Func<int, int> func2 = (i) => i * 10;
            Func<int, int, float> func3 = (a, b) => (float)(a / b);
            
            
            Console.WriteLine(value: $"func1: {func1.Invoke()}; func2: {func2(arg: 10)}; func3: {func3.Invoke(arg1: 1, arg2: 2):f}");
            

            ConsoleHelper.CreateFooter();
        }
    }
}