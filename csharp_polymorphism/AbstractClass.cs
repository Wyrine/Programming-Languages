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
            mRaw = (mRaw << 24) | (mRaw >> 24) | 
                    ((mRaw << 8) & 0xff0000) | ((mRaw >> 8) & 0xff00);
        }
    }
    //Val is virtual and should be overridden when inherited
    public virtual uint Val { get; }

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
