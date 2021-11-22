using System;

namespace MessyExample.DesignPatterns.Creation.Factory
{
    public class MyPoint1 : Point
    {
        public MyPoint1(double x, double y) : base(x: x,y: y)
        {
           
        }
        // Factory Method1  
        public static MyPoint1 NewCartesianPoint(double x, double y)
        {
            return new MyPoint1(x: x, y: y);
        }

        //Factory Method 2, same arguments type with method factory 1
        public static MyPoint1 NewPolarPoint(double rho, double theta)
        {
            return new MyPoint1(x: Math.Cos(d: rho), y: Math.Sin(a: theta));
        }
    }
    
    public class MyFactoryMethodSample
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader(HeaderName: "Design Pattern - Creation - Factory - Method Factory");

            var point1 = MyPoint1.NewCartesianPoint(x: 1, y: Math.PI / 2);
            var point2 = MyPoint1.NewPolarPoint(rho: 1, theta: Math.PI / 2);
            
            Console.WriteLine(value: point1);
            Console.WriteLine(value: point2);
            
            ConsoleHelper.CreateFooter();
        }
    }
}