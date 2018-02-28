using System;
using System.IO;


/*
read in each byte, convert to binary, left shift by 4 * (4-index)
and bitwise or with val
*/
public class BCD : AbstractClass
{
    public BCD() : base() { 
    }
    public override uint Val
    {
        get
        {
            uint rv;
            string tmp = "";
            for( int i = 0; i < 32; i+= 4)
            {
                rv =  (mRaw >> i) & (uint) 0xf ;
                tmp = rv.ToString() + tmp;
            }
            return uint.Parse(tmp);
        }
    }

}
