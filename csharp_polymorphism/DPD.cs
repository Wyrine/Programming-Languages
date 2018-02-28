using System;

public class DPD : AbstractClass
{
    public DPD() : base(){
        Console.Write("DPD: ");    
    }
	public override uint Val
	{
		get{ return mVal; }
	}
}
