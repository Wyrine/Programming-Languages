using System;

static class StringExtender
{
    public static int Find(this string s, string needle)
    {
        return s.IndexOf(needle);
    }
    //now have string.toInt
    public static int toInt(this string s)
    {
        return int.Parse(s);
    }
    public static void DeleteAll(this List<double> s)
    {
        //...
    }
}


class ExtensionTest
{
    public static void Main(string[] args)
    {
        if(args.Length < 2)
        {
            Console.WriteLine("Specify a haystack and a needle.");
            return;
        }
        int v = args[0].Find(args[1]);
        Console.WriteLine(v);
    }
}
