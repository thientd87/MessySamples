using System;
using System.Threading.Tasks;

namespace MessyExample.DesignPatterns.Creation.Factory
{
    public class MyPointAsync : Point
    {
        private MyPointAsync(double x, double y):base(x,y)
        {
            
        }

        private async Task<MyPointAsync> InitAsync(double x, double y)
        {
            await Task.Delay(2000);
            return new MyPointAsync(x,y);
        }

        public static Task<MyPointAsync> CreateAsync(double x, double y)
        {
            var result = new MyPointAsync(x, y);
            return result.InitAsync(x, y);
        }
    }
    
    public class MyAsynchronousFactorySample
    {
        public static async Task DoSomething()
        {
            
            ConsoleHelper.CreateHeader("Design Pattern - Creation - Factory - AsyncChronous Factory"); 
           
            var point = await MyPointAsync.CreateAsync(1, Math.PI / 2);
            
            Console.WriteLine(point);
            
            ConsoleHelper.CreateFooter();
        }
    }
}