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
    - delegate T Work(T) -- Worker function of Map

    - Map(Work) -- Iterate through the list and modify it's contents using the Work
                    function. This is done in parallel.
*/

//MapReduce class which is generic
public partial class MapReduce<T>
{
    //delegate for the parameter function of Map
    public delegate T Work(T x);
    //Map function, returns nothing and takes Work parameter
    public void Map(Work w)
    {
        //Parallel for loop through the elements of mList to alter them
        Parallel.For(0, mCount, I =>{
            //Update the list element using Work function
            mList[(int)I] = w(mList[(int)I]);
        });
    }
}
