using System;
/*
    Author: Kirolos Shahat
    Course: CS365 -- Programming Languages and Systems
    Professor: Dr. Stephen Marz
    class BCD -- Binary Coded Decimal
        stores 8 decimals into a 32-bit unsigned int 
*/

public class BCD : AbstractClass
{
    //Constructor -- Does nothing
    public BCD() : base() { }
    public override uint Val
    {
        get
        {
            //Converting
            uint tmp;
            string rv = "";
            for(int i =0; i < 32; i+=4)
            {
                //getting next 4 bits
                tmp = (mRaw >> i) & (uint) 0xf;
                //added it to string
                rv = tmp.ToString() + rv;
            } 
            //make string uint
            return uint.Parse(rv);
        }
    }
}
