/*

Author: Kirolos Shahat
Due Date: March 1, 2018
AbstractClass implementation which inherits ICompValue

*/
using System;

//AbstractClass inherits ICompValue
public abstract class AbstractClass : ICompValue
{
    AbstractClass(uint i = 0)
    {
           Val = i; 
    }
    //Raw gets uncoverted value 
    public virtual uint Raw
    {
        get;
        set;
    }
    //Val is virtual and should be overridden when inherited
    public virtual uint Val { get; }

    //Implementation of 
    public int CompareTo(Object rhs)
    {
        if (Val < ((AbstractClass) rhs).Val)
            return -1;
        if (Val > ((AbstractClass) rhs).Val)
            return 1;
        return 0;
    }
}
