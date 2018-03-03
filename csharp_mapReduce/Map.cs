using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


public partial class MapReduce<T>
{
	public delegate T Work(T x);
	public T Map(Work w)
	{
		T result = default(T);
		Parallel.For(0, mCount, I => {
			result += w(mList[I]);
		});
		return result;
	}
}
