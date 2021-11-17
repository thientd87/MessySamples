using System;
using System.Collections.Generic;

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
            Console.WriteLine("This is a cup of Hot Tea.");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This is a cup of Coffee.");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
    
    internal class HotTeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Preparing {amount} cup of tea");
            return new Tea();
        }
    }

    internal class HotCoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Preparing {amount} cup of tea");
            return new Coffee();
        }
    }
    
    
    // this way will violated Open-Close principle when you need add more available drink. You have to  modify AvailableDrink enum
    public class VendingMachine
    {
        public enum AvailableDrink
        {
            Tea, Coffee
        }
        private Dictionary<AvailableDrink, IHotDrinkFactory> _factories =  new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public VendingMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory =  (IHotDrinkFactory)Activator.CreateInstance(Type.GetType($"MessyExample.DesignPatterns.Creation.Factory.Hot{Enum.GetName(typeof(AvailableDrink),value: drink)}Factory")!);
                _factories.Add(drink,factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink,int amount)
        {
            return _factories[drink].Prepare(amount); 
        }
    }

    public class MyAbstractFactorySample
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader("Design Pattern - Creation - Factory - Abstract Factory");

            VendingMachine vendingMachine = new VendingMachine();
            var drinkForCus1 = vendingMachine.MakeDrink(VendingMachine.AvailableDrink.Tea, 2);
            var drinkForCus2 = vendingMachine.MakeDrink(VendingMachine.AvailableDrink.Coffee, 1);
            drinkForCus1.Consume();
            drinkForCus2.Consume();
            
            ConsoleHelper.CreateFooter();
        }
    }
}