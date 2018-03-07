using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

/*
    Author: Kirolos Shahat
    Course: CS 365 -- Programming Languages and Systems
    Course Instructor: Dr. Stephen Marz
    Due Date: March 8th, 2018

    Description:

    DataReader.cs -- definition of DataReader class which implements IEnumerable

    Methods: 
        - DataReader(string) -- takes a string which is a filename representing a binary file
                                containing only 8 byte doubles and internally stores them.

        - property Count(readonly) -- returns the number of doubles stored
                    
        - Implements IEnumerable.GetEnumerator() -- creates a DataReaderEnum instance
                                                    and returns it
        
        - indexer[int] -- returns element of the array at that index, throws IndexOutOfRangeException
                            if the index is out of range
*/


public class DataReader : IEnumerable
{
    //member variables
	private double[] mArr;
	private readonly int mCount;
    
    //member property for mCount
	public int Count
	{
		get { return mCount; }
	}
	
    IEnumerator IEnumerable.GetEnumerator()
	{
        return (IEnumerator) new DataReaderEnum(ref mArr);
	}

    //indexer for the double[]
	public double this[int i]
	{
		get
		{
			if(i < 0 || i >= mCount)
				throw new IndexOutOfRangeException();
			return mArr[i];
		}
	}

    //one argument string constructor
	public DataReader(string fName)
	{
		//automatically throws FileNotFoundException if fName doesn't exist
		using(BinaryReader br = new BinaryReader(File.Open(fName, FileMode.Open)))
		{
			List<double> tmp = new List<double>();
			//throw EndofStreamException if can't read a single double
			tmp.Add(br.ReadDouble());
			try
            {
				while(true) //will break when eof is found
					tmp.Add(br.ReadDouble());
            }
			//catch when loop ends
            /*
                originally had catch(EndOfStreamException eof){} but was getting warning so 
                did this to remove warning even though this isn't good
            */
			catch{}
			finally //this works because there is at least one element in tmp
			{
                //update mCount and mArr
				mCount = tmp.Count;
				mArr = new double[mCount];
				for(int i = 0; i < mCount; i++)
					mArr[i] = tmp[i];
			}
		}
	}
}
