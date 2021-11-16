using System;

namespace MessyExample.DesignPatterns.Creation.Factory
{
    public class MyPoint1 : Point
    {
        public MyPoint1(double x, double y) : base(x,y)
        {
           
        }
        // Factory Method1  
        public static MyPoint1 NewCartesianPoint(double x, double y)
        {
            return new MyPoint1(x, y);
        }

        //Factory Method 2, same arguments type with method factory 1
        public static MyPoint1 NewPolarPoint(double rho, double theta)
        {
            return new MyPoint1(Math.Cos(rho), Math.Sin(theta));
        }
    }
    
    public class MyFactoryMethodSample
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader("Design Pattern - Creation - Factory - Method Factory");

            var point1 = MyPoint1.NewCartesianPoint(1, Math.PI / 2);
            var point2 = MyPoint1.NewPolarPoint(1, Math.PI / 2);
            
            Console.WriteLine(point1);
            Console.WriteLine(point2);
            
            ConsoleHelper.CreateFooter();
        }
    }
}