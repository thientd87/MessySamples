using System;
using System.Collections.Generic;
using System.Linq;

namespace MessyExample.DesignPatterns.Creation.Factory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine(value: "This is a cup of Hot Tea.");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine(value: "This is a cup of Coffee.");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
    
    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine(value: $"Preparing {amount} cup of tea");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine(value: $"Preparing {amount} cup of tea");
            return new Coffee();
        }
    }
    
    
    // this way will violated Open-Close principle when you need add more available drink. You have to  modify AvailableDrink enum
    public class VendingMachine
    {
        // public enum AvailableDrink
        // {
        //     Tea, Coffee
        // }
        // private Dictionary<AvailableDrink, IHotDrinkFactory> _factories =  new Dictionary<AvailableDrink, IHotDrinkFactory>();
        //
        // public VendingMachine()
        // {
        //     foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
        //     {
        //         var factory =  (IHotDrinkFactory)Activator.CreateInstance(Type.GetType($"MessyExample.DesignPatterns.Creation.Factory.Hot{Enum.GetName(typeof(AvailableDrink),value: drink)}Factory")!);
        //         _factories.Add(drink,factory);
        //     }
        // }
        //
        // public IHotDrink MakeDrink(AvailableDrink drink,int amount)
        // {
        //     return _factories[drink].Prepare(amount); 
        // }

        private Dictionary<string, IHotDrinkFactory> _factories = new Dictionary<string, IHotDrinkFactory>();

        public VendingMachine()
        {
            foreach (var type in typeof(VendingMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(c: type) && !type.IsInterface)
                {
                    _factories.Add(key: type.Name.Replace(oldValue: "Factory",newValue: string.Empty),value: (IHotDrinkFactory)Activator.CreateInstance(type: type));
                }
            }
        }
        public IHotDrink MakeDrink(string drink,int amount)
        {
            if (_factories.Any() && _factories.ContainsKey(key: drink))
            {
                return _factories[key: drink].Prepare(amount: amount);
            }

            return null;
        }
    }

    public class MyAbstractFactorySample
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader(HeaderName: "Design Pattern - Creation - Factory - Abstract Factory");
            VendingMachine vendingMachine = new VendingMachine();
            var drink1 = vendingMachine.MakeDrink(drink: "Tea",amount: 1);
            drink1.Consume();
            ConsoleHelper.CreateFooter();
        }
    }
}