using System;
using System.Threading.Tasks;

public partial class MapReduce<T>
{
	public delegate T Work(T x);
	public void Map(Work w)
	{
        Parallel.For(0, mCount, I =>{
             mList[(int)I] = w(mList[(int)I]);
        });
	}
}
