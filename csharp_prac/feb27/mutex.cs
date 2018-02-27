using System;
using System.Threading;

class mutex
{
    static Mutex mMutex;
    static Random mRandom;
    static void Main()
    {
        for  ( int i = 0; i < 9; i++)
        {
            var t = new Thread(new ParameterizedThreadStart(Func));
            t.Start(i+1);
        }
        Thread.Sleep(1000);
    }
    
    static void Func(object num)
    {
        int tnum = (int)num;
        Console.WriteLine($"Thread {tnum}...waiting for mutex.");
        while (mMutex.WaitOne(500) == false)
        {
            Console.WriteLine($"Thread {tnum}...still waiting for mutex.");
        }
        Thread.Sleep(mRandom.Next(800, 1500));
        

    }

}
