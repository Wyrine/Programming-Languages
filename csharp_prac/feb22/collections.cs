using System.Collections.Generic;

//c++ templates = c# generics
class MyGenericClass<T>// : IEnumerable<T>
{
    protected T mData;
    /*
    public MyGenericClass(T initializer)
    {
            T sum = default(T);
            //check type is a certain type
            //if (T is some_type)
    }*/
}

class myClass
{
    static void Main()
    {
        //var mgc = new MyGenericClass<double>)();
        //var mgci = new MyGenericClass<int>)();
        var mylist = new List<double>();
        mylist.Add(2.3);
        //Add == push_back
        mylist.Add(4.4);
        //need to make IComparable
        mylist.Sort();
        foreach (double d in mylist)
        {
            Console.WriteLine(d);
        }
        mylist.ForEach(d => {
            Console.WriteLine(d);
        });
        var mc = new myClass();
        double result = mc.Work(d => {
            return d * 2.0;
        }, 15.0);
    }
    //delegate is a function prototype essentially
    public delegate double DoWork(double k);
    //Work needs DoWork function as first argument
    public double Work(DoWork dw, double k)
    {
        return dw(k);
    }
}


