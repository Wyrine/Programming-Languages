using System;

public class BCD : AbstractClass
{
    public BCD() : base() { }
    public override uint Val
    {
        get
        {
            uint tmp;
            string rv = "";
            for(int i =0; i < 32; i+=4)
            {
                tmp = (mRaw >> i) & (uint) 0xf;
                rv = tmp.ToString() + rv;
            } 
            return uint.Parse(rv);
        }
    }
}
