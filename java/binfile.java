import java.io.*;
import java.util.*;

class binfile
{
	public binfile(String filename)
	{
		DataInputStream dis;
		FileInputStream fis;

		try
		{
			fis = new FileInputStream(filename);
			dis = new DataInputStream(fis);
		}
		catch (FileNotFoundException ex)
		{
			System.out.println("bad");
			return;
		}
	}

	public static void main(String[] args)
	{
		if(args.length < 1)
		{
			System.out.println("Please provide a filename.");
			return;
		}
		binfile b = new binfile(args[0]);

	}
}
