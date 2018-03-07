using System;
using System.IO;
using System.Collections.Generic;

public class DataReader
{
    static void Main(string[] args)
    {
        DataReader dr = new DataReader(args[0]);
    }
    private double[] mArr;
    private readonly int mCount;
    public int Count{
        get { return mCount; }
    }
    public double this[int i]
    {
        get
        {
            if(i < 0 || i >= mCount)
                throw new IndexOutOfRangeException();
            return mArr[i];
        }
    }
    public DataReader(string fName = "test.10000")
    {
        BinaryReader br;
        //automatically throws FileNotFoundException if fName doesn't exist
        using(br = new BinaryReader(File.Open(fName, FileMode.Open)))
        {
            List<double> tmp = new List<double>();
            //throw EndofStreamException if can't read a single element
            tmp.Add(br.ReadDouble());
            try{
                //will break when eof is found
                while(true)
                    tmp.Add(br.ReadDouble());
            }
            //catch when loop ends
            catch(EndOfStreamException eof){}
            finally //this works because there is at least one element in tmp
            {
                mCount = tmp.Count;
                mArr = new double[mCount];
                for(int i = 0; i < mCount; i++)
                    mArr[i] = tmp[i];
            }
        }
    }
}
