import java.util.List;
import java.util.ArrayList;
/*
 * Kirolos Shahat
 * 4/23/18
 * Lab 7 -- CS 365
 * 
 * Program to generate permutations and combinations
 * of six variables and 4 operations to attempt to attain
 * a target. This is executed in parallel.
 */

//interface Operation that is to be used as anonymous inner class
interface Operation { int op(int a, int b); }

class Solver extends Thread
{
	public static void main(String[] args)
	{
		//Create threads for the 6 arguments
		List<Solver> solvers = new ArrayList<>();
		for(int i=0; i< args.length-1; i++)
		{
			//pass in the current variable that is the leading variable
			Solver solve = new Solver(args, i);
			solvers.add(solve);
			//start the thread
			solve.start();
		}
	
		//print out the leading line
		System.out.printf("Target = %s [%s", args[args.length-1], args[0]);
		for(int i = 1; i < args.length-1; i++) System.out.printf(", %s", args[i]);
		System.out.printf("]\n");
		
		//join the threads and print their results
		for(Solver solve : solvers)
		{
			try{ solve.join(); solve.print(); }
			catch (InterruptedException ie) 
			{ System.out.println("Unable to join thread: " + ie.getMessage()); }
		}
	}

	//the string version of the operation performed
	protected static final String[] s_ops = new String[] {
		"+", "-", "*", "/"};

	protected static final Operation[] ops = new Operation[]
	{
		((a,b) -> { return a+b; }), //0 is addition
		((a,b) -> { return a-b; }), //1 is subtraction
		((a,b) -> { return a*b; }), //2 is multiplication
		((a,b) -> { return a/b; })	//3 is division
	};

	protected int[] mRem; //The remaining values in the list
	public final int target;
	public final int start;
	//The string results
	protected List<String> results = new ArrayList<>();

	//2 argument constructor 
	public Solver(String[] args, int idx)
	{
		//put the leading variable as args[idx]
		start = Integer.parseInt(args[idx]);
		//and get the target
		target = Integer.parseInt(args[args.length-1]);
		//create an array of the remaining elements to permute excluding the target
		mRem = new int[args.length-2];
		int j = 0;
		//fill the mRem array
		for(int i = 0; i < args.length-1; i++)
			if(i != idx) mRem[j++] = Integer.parseInt(args[i]);
	}

	//prints the solutions generated from this thread
	public void print(){ for(String s : results) System.out.println(s); }

	//swap the elements i, j in mRem array
	protected void swap(int i, int j)
	{
		int tmp = mRem[i];
		mRem[i] = mRem[j];
		mRem[j] = tmp;
	}	
	
	//run calls recurse with (string(start), (start), index=0)
	public void run(){ recurse(String.format("%d", start), start, 0); }
	
	//recurse does the different permutations and combinations
	//and executes the math operation on the values
	protected void recurse(String s_cur, int total, int idx)
	{
		//if the idx is the same as mRem.lenght then I'm done
		if(idx == mRem.length)
		{
			//add to result the string that is the current 'solution'
			results.add(String.format("%s=%d%s", s_cur,total,((total==target) ? "@" : ".")));
			return;
		}
		//iterate through the mRem list starting from idx
		for(int i = idx; i < mRem.length; i++)
		{
			//swap i and idx 
			swap(i, idx);
			//iterate through the operations
			for(int j=0; j<s_ops.length;j++)
			{
				// create a new string that is s_cur + operation + mRem[idx]
				String s = String.format("%s%s%d", s_cur, s_ops[j], mRem[idx]);
				//try block in case divide by 0
				try{
					//recurse with those new parameters with idx + 1 for the next element
					recurse(s, ops[j].op(total, mRem[idx]), idx+1);
				}
				//catch divide by zero and ignore it, won't print it as a solution
				catch(Exception e){ }
			}
			//swap back i and idx
			swap(i,idx);
		}
	}
}
