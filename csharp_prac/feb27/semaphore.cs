using System;
using System.Threading;

class sems
{
    private static Semaphore mSemaphore;
    static void Func(object thread_num)
    {
        var tnum = thread_num as int?;
        
        if(thread_num != null)
        {
            Console.WriteLine($"Thread {tnum} waiting for semaphore.");
            //down()
            mSemaphore.WaitOne();
            Console.WriteLine($"Thread {tnum} got semaphore.");
            Thread.Sleep(100);
            Console.WriteLine($"Thread {tnum} releasing semaphore.");
            //up()
            int pcount = mSemaphore.Release();
            Console.WriteLine($"Thread {tnum} sempahore previous count was {pcount}");
        }
    }

    static void Main()
    {
        mSemaphore = new Semaphore(0, 3);
        for ( int i = 0; i < 9; i++)
        {
            var thread = new Thread(new ParameterizedThreadStart(func));
            thread.Start(i);
        }
        mSemaphore.Release(3);
        mSemaphore.join();
    }
}
