using System;
//
using System.Collections.Generic;

//IMyName is convention
interface IMyInterface
{
    int Get();
    void Set(int i);
    //accessor and mutator
    int MyProperty { get; set; }
}

abstract class AbstractClass : IMyInterface
{
    //allows for overriding
    public virtual int Get()
    {
        return 122;
    }
    public void Set(int i)
    {
        //do nothing
    }

    public virtual int MyProperty
    {
        get {return 88;}
        set { throw new FileNotFoundException(); }
    }
}

class somechild : AbstractClass
{
    //overrides previous 
    public override int Get()
    {

    }
    //doesn't override, creates a second Set
    public new void Set(int i)
    {

    }
    public override int MyProperty
    {

    }
}

//inheriting an interface
class interfaces : IMyInterface
{
    public int DoSomething(DoWork w)
    {
        return w(mValue);
    }
    public interfacces()
    {
        Set(-1111);
    }
    public int Get()
    {
        return mValue;
    }

    public void Set(int v)
    {
        mValue = v;
    }
    



}
