using System;

namespace MessyExample.DelegatesSamples
{
    public class ActionDelegates
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader(HeaderName: "Action Delegate");
            Action action1 = () => { Console.WriteLine(value: $"Action 1 - Hello world"); };
            action1.Invoke();
            
            Action<string> action2 = (s) => { Console.WriteLine(value: $"Action 2 - {s}"); };
            action2.Invoke(obj: "Bye world");
            
            Action<string, int> action3 = (s, i) =>
            {
                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine(value: $"{s} - {j}");
                }
            };
            action3.Invoke(arg1: "Hi world",arg2: 3);
            

            ConsoleHelper.CreateFooter();
        }
    }
}