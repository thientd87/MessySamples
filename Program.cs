using System;
using System.Threading.Tasks;
using MessyExample.DelegatesSamples;
using MessyExample.DesignPatterns.Creation.Builder;
using MessyExample.DesignPatterns.Creation.Factory;
using MessyExample.DesignPatterns.Creation.Prototype;
using MessyExample.DesignPatterns.Creation.Singleton;
using MessyExample.DesignPatterns.Structural.Adapter;

namespace MessyExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(value: "Hello World! This is My C# Samples");
            var userSelection = BuildMenu();
            if (userSelection != null)
                switch (int.Parse(s: userSelection))
                {
                    case 1:
                        DelegateSampleMethods();
                        break;
                    case 2:
                        await DesignPatternSamples();
                        break;
                    default:
                        Console.WriteLine(value: "Wrong choosen! Choice again.");
                        BuildMenu();
                        break;
                }
            Console.ReadKey();
        }

        private static string BuildMenu()
        {
            Console.WriteLine(value: "Please chose 1:");
            Console.WriteLine(value: "1. Delegate Samples");
            Console.WriteLine(value: "2. Design Pattern samples");
            Console.Write(value: "Your choosen:");
            return Console.ReadLine();
        }

        private static async Task DesignPatternSamples()
        {
            //1. Creation - Builder
            MyFunctionBuilderSample.DoSomething();
            MyFluentBuilderInheritanceWithRecursiveGenericsSample.DoSomething();
            MyFacadeBuilderSample.DoSomething();
            
            //2.Creation - Factory
            MyFactoryMethodSample.DoSomething();
            await  MyAsynchronousFactorySample.DoSomething();
            MyAbstractFactorySample.DoSomething();
            
            //3. Creation - Prototype
            MyPrototypeSample.DoSomething();
            
            //4.Creation - Singleton
            MySingletonSample.DoSomething();
            MyMonoStateTest.DoSomething();
            
            //5. Structural - Adapter
            MyVectorSample.Draw();
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
