using System;
using System.Threading;
using System.Threading.Tasks;

public partial class MapReduce<T>
{
	public delegate T Work(T x);
	public void Map(Work w)
	{
        if(mCount == 0)
            return default(T);
        Parallel.For(1, mCount, I =>{
             mList[(int)I] = w(mList[(int)I]);
        });
	}
}
