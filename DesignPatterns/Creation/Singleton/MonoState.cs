using System;

namespace MessyExample.DesignPatterns.Creation.Singleton
{
    public class CEO
    {
        private static string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        private static int _age;

        public override string ToString()
        {
            return ($"{nameof(Name)}:{Name} - {nameof(Age)}:{Age}");
        }
    }
    
    public class MyMonoStateTest
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader(HeaderName: "Design Pattern - Creation - Singleton - Mono state");
            var ceo1 = new CEO();
            ceo1.Name = "Pelle";
            ceo1.Age = 55;
            Console.WriteLine(ceo1);
            var ceo2 = new CEO();
            // Remember that Name and Age is static field
            // Ops: members of ceo1 = ceo2
            Console.WriteLine(ceo2);
            
            ConsoleHelper.CreateFooter();
        }
    }
}