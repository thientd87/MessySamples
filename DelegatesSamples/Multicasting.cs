using System;

namespace MessyExample.DelegatesSamples
{
    public class Greetings
    {
        // Kiểu hàm: (String) -> ()
        public static void Hello(String name)
        {
            Console.WriteLine("Hello " + name);
        }

        // Kiểu hàm: (String) -> ()
        public static void Bye(string name)
        {
            Console.WriteLine("Bye " + name);
        }

        // Kiểu hàm: (String) -> ()
        public static void Hi(string name)
        {
            Console.WriteLine("Hi " + name);
        } 
    }
    
    public class MyMulticastingDelegate
    {
        // Khai báo một Delegate.
            public delegate void Greeting(string name);
            
            public static void DoSomething()
            {
                
                ConsoleHelper.CreateHeader("Multicasting Delegate sample");

                // Tạo các đối tượng Delegate.
                Greeting hello = Greetings.Hello;
                Greeting bye = Greetings.Bye;
                Greeting hi = Greetings.Hi;
            
                // Tạo một Delegate là hợp của 3 đối tượng trên.
                Greeting greeting = hello + bye;
           
                // Bạn cũng có thể sử dụng toán tử +=
                greeting += hi;

                // Thực thi greeting.
                greeting("Tom");

                ConsoleHelper.CreateFooter();


            }
    }
}