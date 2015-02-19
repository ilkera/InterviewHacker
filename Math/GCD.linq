<Query Kind="Program" />

void Main()
{
	ComputeGCD(24, 6).Dump();
	ComputeGCD(5, 12).Dump();
	ComputeGCD(180, 35).Dump();
	
	ComputeGCD_Iterative(24, 6).Dump();
	ComputeGCD_Iterative(5, 12).Dump();
	ComputeGCD_Iterative(180, 35).Dump();
}

public int ComputeGCD(int a, int b)
{
	if (b == 0)
	{
		return a;
	}
	
	return ComputeGCD(b, a % b);
}

public int ComputeGCD_Iterative(int a, int b)
{	
	while (b != 0)
	{
		int temp = b;
		b = a % b;
		a = temp;
	}
	
	return a;
}

// Define other methods and classes here
