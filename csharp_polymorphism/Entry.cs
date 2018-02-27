using System;
using System.IO;


class EntryPoint
{
    static void Main(string[] args)
    {
        BCD bcd = new BCD(1);        
        Console.WriteLine(bcd.Raw);

    }
}
