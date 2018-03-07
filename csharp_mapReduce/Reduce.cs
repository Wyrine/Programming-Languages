using System;
using System.Threading.Tasks;

/*
Author: Kirolos Shahat
Course: CS 365 -- Programming Languages and Systems
Course Instructor: Dr. Stephen Marz
Due Date: March 8th, 2018

Description:
    - Map.cs -- Partial Implementation of MapReduce class which is Generic.

Methods: 
    - delegate ReduceWork(T, T) -- delegate for the Reduce worker function

    - Reduce(ReduceWork) -- implementation of Reduce synchronously

    - ReduceAsync(ReduceWork) -- implementation of Reduce using TAP(async and await).
                                    Returns a Task<T>
*/

//Partial implemention of MapReduce
public partial class MapReduce<T>
{
    //delegate for Reduce and ReduceAsync parameter
    public delegate T ReduceWork(T left, T right);

    //Reduce -- done synchronously
    public T Reduce(ReduceWork rw)
    {
        //if mCount is 0 then throws IndexOutOfRangeException
        if(mCount == 0) throw new IndexOutOfRangeException();

        //initial value is the first element
        var cur = mList[0];
        //loop through the other elements, if there are any
        for(int i = 1; i < mCount; i++)
            //update the accumulator using rw
            cur = rw(cur, mList[i]);
        //return the accumulation
        return cur;
    }

    //Reduce -- done asynchronously
    public async Task<T> ReduceAsync(ReduceWork rw)
    {   
        //do reduce asynchronously and return the Task<T> that belongs to it
        return await Task.Run(() => { return Reduce(rw); }); 
    }
}
