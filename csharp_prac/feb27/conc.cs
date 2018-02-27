using System;
using System.Threading;

class threading
{
    public static void SomeFunc()
    {   
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Thread: Executed iteration {i}");
            Thread.Sleep(1); //sleep 1/1000 of sec
        }
    }
    static void Main()
    {
        var t = new Thread(new ThreadStart(SomeFunc));

        t.Start();
        Thread.Sleep(1);
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Main: Executed iteration {i}");
            Thread.Sleep(1);
        }
        t.Join();
    }
}
