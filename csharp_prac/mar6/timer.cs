using System;
using System.Threading;

class timer
{
    static void Main()
    {
        //              function, function param, initial wait time, wait time
        using (new Timer(TimerWork, null, 0, 500)){
            Thread.Sleep(2500);
        }
    }

    static void TimerWork(object state)
    {
        Console.WriteLine("Timer!");
    }
}
