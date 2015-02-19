<Query Kind="Program" />

void Main()
{
	Max(10,20).Dump();
	Max(20,10).Dump();
	Max(20,20).Dump();
}

public int Max(int a, int b)
{
	int c = a - b;
	int k = c >> 31 & 0x1;
	int max = a - k*c;
	
	return max;
}

// Define other methods and classes here
