class Solve extends Thread
{
	/*
	protected static final Integer[] ops = new Integer[] {
		(int a,int b) ->  a+b,
		(int a,int b) -> a-b,
		(int a,int b) -> a*b,
		(int a,int b) -> a/b};
	*/
	protected static final String[] s_ops = new String[] {
		"+", "-", "*", "/"};
	protected int[] mRem; //The remaining values in the list
	public final int target;
	public final int start;
	public Solve(String[] args, int idx)
	{
		start = Integer.parseInt(args[idx]);
		target = Integer.parseInt(args[args.length-1]);
		mRem = new int[args.length-1];
		int j = 0;
		for(int i = 0; i < args.length; i++)
			if(i != idx) mRem[j++] = Integer.parseInt(args[i]);
	}
	public static void main(String[] args)
	{


	}
	protected void swap(int i, int j)
	{
		int tmp = mRem[i];
		mRem[i] = mRem[j];
		mRem[j] = tmp;
	}
	public void run() { recurse(String.format("%d", start), start, 0); }
	protected void recurse(String s_cur, int i_cur, int idx)
	{
		if(idx== mRem.length)
		{
			System.out.println(String.format("%s=%d%s", s_cur,target,((i_cur==target) ? "@" : ".")));
			return;
		}
		for(int i = idx; i < mRem.length; i++)
		{
			swap(i, idx);
			for(int j=0; j<s_ops.length;j++)
			{
				String s = String.format("%s%s%d", s_cur, s_ops[j], mRem[idx]);
				//recurse(s, ops[j](i_cur, mRem[idx]), idx+1);
			}
			swap(i,idx);
		}
	}
}
