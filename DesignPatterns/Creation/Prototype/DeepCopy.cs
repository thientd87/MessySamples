using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MessyExample.DesignPatterns.Creation.Prototype
{
    public static class ExtensionMethods
    {
        // To use this extension, you have mark your object with [Serializable] attribute
        // This exteions uses BinaryFormatter which obsoleted by MS's recommendation
        public static T DeepCopy<T>(this T self)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(serializationStream: stream, graph: self);
            stream.Seek(offset: 0, loc: SeekOrigin.Begin);
            object copy = formatter.Deserialize(serializationStream: stream);
            stream.Close();
            return (T)copy;
        }

        // To use this extension, your class has to implemented parameterless constructor.
        public static T DeepCopyXML<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(type: typeof(T));
                s.Serialize(stream: ms, o: self);
                ms.Position = 0;
                return (T)s.Deserialize(stream: ms);
            }
        }

        // To use this extension, your class has to implemented parameterless constructor.
        public static T DeepCopyJson<T>(this T self)
        {
            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(objA: self, objB: null))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(value: JsonConvert.SerializeObject(value: self));
        }
    }

    [Serializable]
    public class Address
    {
        public string StreetAddress, City, Country;

        public Address()
        {
            
        }
        public Address(string streetAddress, string city, string country)
        {
            StreetAddress = streetAddress ?? throw new ArgumentNullException(paramName: nameof(streetAddress));
            City = city ?? throw new ArgumentNullException(paramName: nameof(city));
            Country = country ?? throw new ArgumentNullException(paramName: nameof(country));
        }

      

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(City)}: {City}, {nameof(Country)}: {Country}";
        }
    }

    [Serializable]
    public class Employee
    {
        public string Name;
        public Address Address;

        public Employee()
        {
            
        }
        public Employee(string name, Address address)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Address = address ?? throw new ArgumentNullException(paramName: nameof(address));
        }

        

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }

    public class MyPrototypeSample
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader(HeaderName: "Design Pattern - Creation - Prototype - Deep Copy extention");
            
            var john = new Employee(name: "John", address: new Address(streetAddress: "123 London Road", city: "London", country: "UK"));
            //var chris = john;
            var chris = john;
            chris.Name = "Chris";
            Console.WriteLine(value: john); // oops, john is called chris
            Console.WriteLine(value: chris);

            var jane = john.DeepCopy();
            jane.Name = "jane";
            Console.WriteLine(value: jane);

            var mr8X = john.DeepCopyJson();
            mr8X.Name = "mr8x";
            Console.WriteLine(mr8X);
            
            var jim = john.DeepCopyXML();
            jim.Name = "jim";
            Console.WriteLine(jim);
            
            ConsoleHelper.CreateFooter();  
        }
    }
}