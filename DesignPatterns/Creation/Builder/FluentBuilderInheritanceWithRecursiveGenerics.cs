using System;

namespace MessyExample.DesignPatterns.Creation.Builder
{
    public class FluentPerson : Person
    {
        public string Company { get; set; }

        public class Builder : FluentPersonJobBuilder<Builder>
        {
            
        }

        public static Builder New => new Builder();
        public override string ToString()
        {
            return ($"{nameof(Name)}:{Name} - {nameof(Position)}:{Position} - {nameof(Company)}:{Company}");
        }
    }

    public abstract class FluentPersonBuilder
    {
        protected FluentPerson person = new FluentPerson();

        public FluentPerson Build()
        {
            return person;
        }
    }

    // class Foo : Bar<Foo>
    // inheritance from Self recursive
    public class FluentPersonInfoBuilder<T> : FluentPersonBuilder where T : FluentPersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            person.Name = name;
            return (T)this;
        }
    }

    public class FluentPersonJobBuilder<T> :  FluentPersonInfoBuilder<T> where T : FluentPersonJobBuilder<T>
    {
        public T WorkAsA(string position)
        {
            this.person.Position = position;
            return (T)this;
        }
        public T At(string company)
        {
            this.person.Company = company;
            return (T)this;
        }
    }
    
    
    public class MyFluentBuilderInheritanceWithRecursiveGenericsSample
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader(HeaderName: "Design Pattern  - Creation - Builder : Fluent builder inheritance with recursive generics");
            var person = FluentPerson.New.Called(name: "Thien Trinh").WorkAsA(position: "Developer").At(company: "Happy Coding DotNet").Build();
            Console.WriteLine(value: person);
            ConsoleHelper.CreateFooter();
        }
    }
}