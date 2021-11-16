using System;

namespace MessyExample.DesignPatterns.Creation.Builder
{
    public class FacadePerson : Person
    {
        // Job fields
         public string Company, AnnualInCome;

        //Address fields
        public string Address, PostalCode;

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Company)}: {Company}, {nameof(AnnualInCome)}: {AnnualInCome}, {nameof(Address)}: {Address}, {nameof(PostalCode)}: {PostalCode}";
        }
    }

    public class FacadePersonBuilder
    {
        protected FacadePerson person = new FacadePerson();

        public FacadePersonInfoBuilder Info => new FacadePersonInfoBuilder(person);
        public FacadePersonJobBuilder Work => new FacadePersonJobBuilder(person);
        public FacadePersonAddressBuilder Address => new FacadePersonAddressBuilder(person);

        public FacadePerson Build()
        {
            return person;
        }
    }
    public class FacadePersonInfoBuilder : FacadePersonBuilder
    {
        public FacadePersonInfoBuilder(FacadePerson facadePerson)
        {
            this.person = facadePerson;
        }

        public FacadePersonInfoBuilder Called(string name)
        {
            person.Name = name;
            return this;
        }
       
        
    }
    public class FacadePersonAddressBuilder : FacadePersonBuilder
    {
        public FacadePersonAddressBuilder(FacadePerson facadePerson)
        {
            this.person = facadePerson;
        }

        public FacadePersonAddressBuilder WithAddress(string address)
        {
            person.Address = address;
            return this;
        }
        public FacadePersonAddressBuilder WithPostalCode(string postalCode)
        {
            person.PostalCode = postalCode;
            return this;
        }
        
    }
    
    public class FacadePersonJobBuilder : FacadePersonBuilder
    {
        public FacadePersonJobBuilder(FacadePerson facadePerson)
        {
            this.person = facadePerson;
        }

        public FacadePersonJobBuilder WorkAt(string companyName)
        {
            person.Company = companyName;
            return this;
        }
        public FacadePersonJobBuilder WorkAs(string position)
        {
            person.Position = position;
            return this;
        }
        public FacadePersonJobBuilder AnnualIncome(string salary)
        {
            person.AnnualInCome = salary;
            return this;
        }
    }

    public class MyFacadeBuilderSample
    {
        public static void DoSomething()
        {
            
            ConsoleHelper.CreateHeader("Design Pattern  - Creation - Builder : Facade builder");
            var personBuilder = new FacadePersonBuilder();
            var person = personBuilder
                .Address
                    .WithAddress("HCM")
                    .WithPostalCode("700000")
                .Work
                    .WorkAt("Happy Coding DotNet")
                    .WorkAs("Developer")
                    .AnnualIncome("10k")
                .Info.Called("Thien Trinh")
                .Build();
            
            Console.WriteLine(person.ToString());
            
            ConsoleHelper.CreateFooter();
        }
    }
}