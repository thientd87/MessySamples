using System;
using System.Threading.Tasks;

namespace MessyExample.DesignPatterns.Creation.Factory
{
    public class MyPointAsync : Point
    {
        private MyPointAsync(double x, double y):base(x: x,y: y)
        {
            
        }

        private async Task<MyPointAsync> InitAsync(double x, double y)
        {
            await Task.Delay(millisecondsDelay: 2000);
            return new MyPointAsync(x: x,y: y);
        }

        public static Task<MyPointAsync> CreateAsync(double x, double y)
        {
            var result = new MyPointAsync(x: x, y: y);
            return result.InitAsync(x: x, y: y);
        }
    }
    
    public class MyAsynchronousFactorySample
    {
        public static async Task DoSomething()
        {
            
            ConsoleHelper.CreateHeader(HeaderName: "Design Pattern - Creation - Factory - AsyncChronous Factory"); 
           
            var point = await MyPointAsync.CreateAsync(x: 1, y: Math.PI / 2);
            
            Console.WriteLine(value: point);
            
            ConsoleHelper.CreateFooter();
        }
    }
}