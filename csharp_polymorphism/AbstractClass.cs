using System;

public abstract class AbstractClass : ICompValue
{
    public virtual uint Raw
    {
        get;
        set;
    }
    public virtual uint Val
    {
        get;
    }
    public virtual int CompareTo(Object rhs)
    {
        if (Val < ((AbstractClass) rhs).Val)
            return -1;
        if (Val > ((AbstractClass) rhs).Val)
            return 1;
        return 0;
    }
}
