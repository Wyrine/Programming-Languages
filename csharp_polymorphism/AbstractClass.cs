/*
Author: Kirolos Shahat
Due Date: March 1, 2018
AbstractClass implementation which inherits ICompValue
*/
using System;

//AbstractClass inherits ICompValue
public abstract class AbstractClass : ICompValue
{
    protected uint mRaw;
    public AbstractClass()
    {
        mRaw = 0;    
    }
    //Raw gets uncoverted value 
    public uint Raw
    {
        get { return mRaw; }
        set 
        { 
            mRaw = value; 
//            mRaw = (mRaw << 24) | (mRaw >> 24) |
//                ((mRaw & (0xff << 8)) << 8) | ((mRaw & (0xff << 16)) >> 8) ;
            mRaw = (mRaw << 24) | (mRaw >> 24) | 
                    ((mRaw << 8) & 0xff0000) | ((mRaw >> 8) & 0xff00);
        }
    }
    //Val is virtual and should be overridden when inherited
    public virtual uint Val { get; }
    protected string getBCDString(uint x)
    {
        uint tmp;
        string rv = "";
        if( x == 0) x = mRaw;
        for(int i =0; i < 32; i+=4)
        {
            tmp = (x >> i) & (uint) 0xf;
            rv = tmp.ToString() + rv;
        } 
        return rv;
    }

    //Implementation of CompareTo for List 
    public int CompareTo(object rhs)
    {
        if (Val < ((AbstractClass) rhs).Val)
            return -1;
        if (Val > ((AbstractClass) rhs).Val)
            return 1;
        return 0;
    }
}
