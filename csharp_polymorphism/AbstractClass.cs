using System;
/*
    Author: Kirolos Shahat
    Course: CS365 -- Programming Languages and Systems
    Professor: Dr. Stephen Marz
    abstract class AbstractClass
        inherited by BCD and DPD
*/

//AbstractClass inherits ICompValue
public abstract class AbstractClass : ICompValue
{
    protected uint mRaw;
    //Constructor -- init mRaw to 0
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
            //swap endiannes
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
