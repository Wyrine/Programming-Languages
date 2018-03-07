using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public partial class MapReduce<T>
{
    public delegate T ReduceWork(T left, T right);
    
   /* private async Task<T> ReduceHelper(ReduceWork rw)
    {

    }*/

    public T Reduce(ReduceWork rw)
    {
       return default(T); 
    }

    public async Task<T> ReduceAsync(ReduceWork rw)
    {
       return await Task.Run(() => { return Reduce(rw); }); 
    }
}
