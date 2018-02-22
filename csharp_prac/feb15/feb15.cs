using System;
using System.IO;
/*
class Chat
{
    static public void Main(string[] args)
    {
        string x;
        x = Console.ReadLine();
        while(x != "quit")
        {
            Console.WriteLine($"You said: {x}");
            x = Console.ReadLine();
        }
    }
}
*/

/*
class something
{
    public static void Main()
    {
        var s = new something();
        Console.WriteLine(s.Member);
        s.Member = 22;
        Console.WriteLine(s.Member);
    }
    
    public something()
    {
        mMember = 123456;
    }

    //8 bytes
    protected long mMember;

    //makes it's own variable
    //uses default getter and setter
    public int CheatProperty
    {
        get;
        //set;
    }

    //property -- no parenth
    public long Member
    {
        get
        {
            return mMember;
        }
        //to make read only, don't make a set
        set
        {
            if( value >= -100 && value <= 100)
            {
                mMember = value;
            }
        }
    }
    

}*/

/*
class something
{
    public static void Main()
    {
        var s = new something();
        
    }

    public something()
    {
        i = 123;
    }
    //set once and only once
    public readonly int i;
}
*/

/*
class someExcept
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine(args[0]);
        }
        //Exception class catches all errors
        catch(Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
        //always runs whether an exception was thrown or not
        finally
        {
            Console.WriteLine("Finally Block");
        }
    }
}
*/

//BinaryReader || BinaryWriter for reading and writing binary files respectively
//              belongs to System.IO
//StreamReader || StreamWriter for reading and writing text files respectively
//              belongs to System.IO



//class is stored on heap // stack is stored on stack
class binary_write
{
    public static void Main()
    {
        using (var bw = new BinaryWriter(File.OpenWrite("test.bin")))
        {
            bw.Write(912L);
            bw.Write(21.2);
            bw.Write(71.4f);
            bw.Write(712);
        }
    }
}


//everything inherits object

