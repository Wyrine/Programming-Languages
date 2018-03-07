using System;
using System.Collections;
using System.Collections.Generic;


public class DataReaderEnum : IEnumerator
{
    private double[] mArr;
    private int mIndex = -1;

    object IEnumerator.Current
    {
        get{ return Current; }
    }

    public double Current{
        get{ return mArr[mIndex]; }
    }

    public DataReaderEnum(ref double[] arr)
    {
        mArr = arr;
    }

    public void Reset(){ mIndex = -1; } 

    public bool MoveNext()
    {
        mIndex++;
        return (mIndex < mArr.Length);
    }

}
