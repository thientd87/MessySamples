using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq.Extensions;
using NUnit.Framework;

namespace MessyExample.DesignPatterns.Creation.Singleton
{
    public interface ICapitalRepository
    {
        int GetPopulation(string cityName);
    }

    public class CapitalRepository : ICapitalRepository
    {
        private Dictionary<string, int> _capital;

        private static int _instanceCount;
        public static int InstanceCount => _instanceCount;

        public CapitalRepository()
        {
            _instanceCount++;
            Console.WriteLine(value: "Initialize database - get data from File");
            // should setting copy file as CONTENT when COMPILE
            _capital = File.ReadAllLines(path: "DesignPatterns/Creation/Singleton/Capitals.txt")
                // using MoreLinQ
                .Batch(size: 2).ToDictionary(
                    keySelector: list => list.ElementAt(index: 0).Trim(),
                    elementSelector: list => Int32.Parse(s: list.ElementAt(index: 1).Trim())
                );
        }
        
        public int GetPopulation(string cityName)
        {
            if (_capital != null && _capital.Any())
                return _capital[key: cityName];

            return 0;
        }

        // Create a static private and lazy object to get only one instance object when needed
        private static Lazy<CapitalRepository> _instance = new Lazy<CapitalRepository>(valueFactory: ()=> new CapitalRepository());
        public static CapitalRepository Instance => _instance.Value ;
    }

    public class CitiFinder
    {
        public int GetTotalCitiPopulation(string[] cityNames)
        {
            int result = 0;
            if (cityNames != null && cityNames.Length > 0)
            {
                foreach (var cityName in cityNames)
                {
                    result += CapitalRepository.Instance.GetPopulation(cityName);
                }
            }
           
            return result;
        }
    }

    [TestFixture]
    public class TestMySingleton
    {
        [Test]
        public void IsSingletonTest()
        {
            var repo1 = CapitalRepository.Instance;
            var repo2 = CapitalRepository.Instance;
            Assert.That(repo1, Is.SameAs(repo2));
            Assert.That(CapitalRepository.InstanceCount, Is.EqualTo(1));
        }
    }
    
    public class MySingletonSample
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader(HeaderName: "Design Pattern - Creation - Singleton - Simple");
            var capitalRepository = CapitalRepository.Instance;
            Console.WriteLine(value: $"Population of Tokyo is: {capitalRepository.GetPopulation(cityName: "Tokyo")}");

            var cityNames = new string[] { "Tokyo", "Seoul", "Osaka" };
            Console.WriteLine($"Total population of  Tokyo, Seoul, Osaka is: {new CitiFinder().GetTotalCitiPopulation(cityNames)}");
            
            ConsoleHelper.CreateFooter();
        }
    }
}