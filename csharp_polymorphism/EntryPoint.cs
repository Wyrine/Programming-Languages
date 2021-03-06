using System;
using System.IO;
using System.Collections.Generic;


class EntryPoint
{
    private BinaryReader br;
    public EntryPoint(string fName)
    {
        if(File.Exists(fName))
        {
            br = new BinaryReader(File.Open(fName, FileMode.Open));
        }
        else
        {
            Console.Error.WriteLine($"{fName} does not exist."); 
            br = default(BinaryReader);
        }
    }

    public List<ICompValue> ReadFile()
    {
        List<ICompValue> icv = new List<ICompValue>();
        DPD d;
        BCD b;
        while( br.BaseStream.Position != br.BaseStream.Length)
        {
            byte mode = br.ReadByte();
            uint data = br.ReadUInt32();
            if(mode == 1)//DPD
            {
                d =  new DPD();  
                d.Raw = data;
                icv.Add(d);
            }
            else //BCD
            {
                b = new BCD();
                b.Raw = data;
                icv.Add(b);
            }
        }
        icv.Sort();
        return icv;
    }

    ~EntryPoint()
    {
        br.Close();
    }

    static void Main(string[] args)
    {
        EntryPoint ep;
        if(args.Length < 2)
        {
            Console.Error.WriteLine("Expected arguments: InputFileName OutputFileName");
            return;
        }
        ep = new EntryPoint(args[0]);
        var ics = ep.ReadFile();
        using (StreamWriter sr = new StreamWriter(args[1]))
        {
            ics.ForEach(v => {
                sr.WriteLine(v.Val);
            });
        }
    }
}
