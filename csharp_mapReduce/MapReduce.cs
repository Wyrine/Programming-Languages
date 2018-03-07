using System;
using System.Collections.Generic;

public partial class MapReduce<T>
{
    private List<T> mList;
    private uint mCount;
    public MapReduce()
    {
        mList = new List<T>();
        mCount = 0;
    }
    public uint Count
    {
        get{ return mCount; }
    }

    public void Add(T toAdd)
    {
        mList.Add(toAdd);
        mCount++;
    }

    public T this[int i]
    {
        get{ return mList[i]; }
    }
}
