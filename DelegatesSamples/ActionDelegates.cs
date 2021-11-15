using System;

namespace MessyExample.DelegatesSamples
{
    public class ActionDelegates
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader("Action Delegate");
            Action action1 = () => { Console.WriteLine($"Action 1 - Hello world"); };
            action1.Invoke();
            
            Action<string> action2 = (s) => { Console.WriteLine($"Action 2 - {s}"); };
            action2.Invoke("Bye world");
            
            Action<string, int> action3 = (s, i) =>
            {
                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine($"{s} - {j}");
                }
            };
            action3.Invoke("Hi world",3);
            

            ConsoleHelper.CreateFooter();
        }
    }
}