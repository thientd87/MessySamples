using System;
using System.Collections.Generic;

namespace MessyExample.DesignPatterns.Creation.Builder
{
    public class FunctionalPerson: Person
    {
        
    }

    public class FunctionalPersonBuilder
    {
        public readonly List<Action<Person>> Actions = new List<Action<Person>>();

        public FunctionalPersonBuilder Called(string name)
        {
            Actions.Add(p => { p.Name = name;});
            return this;
        }

        public FunctionalPersonBuilder WorkAsA(string position)
        {
            Actions.Add(p => { p.Position = position;});
            return this;
        }

        public FunctionalPerson Build()
        {
            var person = new FunctionalPerson();
            Actions.ForEach( a => a(person));
            return person;
        }
    }

    public class MyFunctionBuilderSample
    {
        public static void  DoSomething()
        {
             ConsoleHelper.CreateHeader("Design Pattern  - Creation - Builder : Function builder");
            
            var personBuilder = new FunctionalPersonBuilder();
            var person = personBuilder.Called("Thien Trinh").WorkAsA("Developer").Build();
            Console.WriteLine(person.ToString());
            ConsoleHelper.CreateFooter();
        }
    }
   
}