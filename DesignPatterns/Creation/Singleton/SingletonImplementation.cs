using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq.Extensions;

namespace MessyExample.DesignPatterns.Creation.Singleton
{
    public interface ICapitalRepository
    {
        int GetPopulation(string cityName);
    }

    public class CapitalRepository : ICapitalRepository
    {
        private Dictionary<string, int> _capital;

        public CapitalRepository()
        {
            Console.WriteLine("Initialize database - get data from File");
            // should setting copy file as CONTENT when COMPILE
            _capital = File.ReadAllLines("DesignPatterns/Creation/Singleton/Capitals.txt")
                // using MoreLinQ
                .Batch(2).ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => Int32.Parse(list.ElementAt(1).Trim())
                );
        }
        
        public int GetPopulation(string cityName)
        {
            if (_capital != null && _capital.Any())
                return _capital[cityName];

            return 0;
        }

        // Create a static private and lazy object to get only one instance object when needed
        private static Lazy<CapitalRepository> _instance = new Lazy<CapitalRepository>(()=> new CapitalRepository());

        public static CapitalRepository Instance => _instance.Value ;
    }
    
    public class MySingletonSample
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader("Design Pattern - Creation - Singleton - Simple");
            var capitalRepository = CapitalRepository.Instance;
            Console.WriteLine($"Population of Tokyo is: {capitalRepository.GetPopulation("Tokyo")}");
            
            ConsoleHelper.CreateFooter();
        }
    }
}