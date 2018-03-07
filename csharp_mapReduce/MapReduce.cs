using System;
using System.Collections.Generic;

/*
Author: Kirolos Shahat
Course: CS 365 -- Programming Languages and Systems
Course Instructor: Dr. Stephen Marz
Due Date: March 8th, 2018

Description:
    - Partial definition of MapReduce class which is Generic

Methods: 
    - MapReduce() -- No argument constructor. Creates an empty list 
    
    - Count property -- readonly. Gets the current number of elements in the list
    
    - Add(T) -- Adds to the end of the list the new parameter

    - indexer[int] -- readonly. Returns the element of the list at the integer
*/

//Partial implementation of MapReduce
public partial class MapReduce<T>
{
    //Member variables
    private List<T> mList;
    private uint mCount = 0;

    //constructor -- 0 arguments
    public MapReduce(){ mList = new List<T>(); }
    
    //Count property
    public uint Count
    {
        get{ return mCount; }
    }

    //Add(T) -- Append to the list and increment the count
    public void Add(T toAdd)
    {
        mList.Add(toAdd);
        mCount++;
    }

    //indexer -- return the element at this index of the list
    public T this[int i]
    {
        get{ return mList[i]; }
    }
}
