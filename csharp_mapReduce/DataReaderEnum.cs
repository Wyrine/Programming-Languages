using System;
using System.Collections;

/*
Author: Kirolos Shahat
Course: CS 365 -- Programming Languages and Systems
Course Instructor: Dr. Stephen Marz
Due Date: March 8th, 2018

Description:
DataReaderEnum.cs -- Definition of DataReaderEnum class which implements IEnumerator
for DataReader class

Methods:
    - DataReaderEnum constructor(ref double[]) -- points to the same data as DataReader

    - IEnumerator.Current.get -- returns mArr at the current index

    - Reset -- Sets the current index back to the start point

    - MoveNext -- increments the current index and true if it is still less than the size
                    of the Array
 */

//DataReaderEnum class definition which implements IEnumerator
public class DataReaderEnum : IEnumerator
{
    //the data reference
    private double[] mArr;
    //Start is -1 and MoveNext is called before Current
    private int mIndex = -1;

    //one argument constructor which is a reference to the double
    //only copies the address and not the elements
    public DataReaderEnum(ref double[] arr){ mArr = arr; }

    //returns the element at mIndex
    object IEnumerator.Current
    {
        get{ return mArr[mIndex]; }
    }

    //Reset implementation of IEnumerator
    public void Reset(){ mIndex = -1; } 

    //MoveNext of IEnumerator -- Returns true if still in bound of mArr.Length
    public bool MoveNext()
    {
        mIndex++;
        return (mIndex < mArr.Length);
    }
}
