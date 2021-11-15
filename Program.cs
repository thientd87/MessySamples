using System;
using MessyExample.DelegatesSamples;

namespace MessyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is My C# Samples");
            var userSelection = BuildMenu();
            if (userSelection != null)
                switch (int.Parse(userSelection))
                {
                    case 1:
                        DelegateSampleMethods();
                        break;
                    default:
                        Console.WriteLine("Wrong choosen! Choice again.");
                        BuildMenu();
                        break;
                }
            Console.ReadKey();
        }

        private static string BuildMenu()
        {
            Console.WriteLine("Please chose 1:");
            Console.WriteLine("1. Delegate Samples");
            Console.WriteLine("2. Design Pattern samples");
            Console.Write("Your choosen:");
            return Console.ReadLine();
        }

        private static void DelegateSampleMethods()
        {
            MyMathDelegate.DoSomething();
            
            MyTaxDelegate.DoSomething();
            
            MyAnynomousDelegate.DoSomething();
            
            MyMulticastingDelegate.DoSomething();
            
            MyDelegateAsParameter.DoSomething();
            
            ActionDelegates.DoSomething();
            
            FunctionDelagates.DoSomething();
        }
    }
}
