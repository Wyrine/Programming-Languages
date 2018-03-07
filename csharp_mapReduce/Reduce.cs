using System;
using System.Threading.Tasks;

public partial class MapReduce<T>
{
    public delegate T ReduceWork(T left, T right);

    public T Reduce(ReduceWork rw)
    {
        if(mCount == 0) throw new IndexOutOfRangeException();

        var cur = mList[0];
        for(int i = 1; i < mCount; i++)
            cur = rw(cur, mList[i]);
        return cur;
    }

    public async Task<T> ReduceAsync(ReduceWork rw)
    {
        return await Task.Run(() => { return Reduce(rw); }); 
    }
}
