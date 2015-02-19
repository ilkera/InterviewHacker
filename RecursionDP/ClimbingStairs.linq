<Query Kind="Program" />

void Main()
{
	for (int i = 1; i < 5; i++)
	{
		Console.WriteLine("Recursive(" + i.ToString() + ") :"+ FindWays(i));	
		Console.WriteLine("Iterative(" + i.ToString() + ") :"+ FindWays_iterative(i));
	}
	
	Console.WriteLine("\nExhaustive:\n");
	for (int i = 1; i < 20; i++)
	{
		Console.WriteLine("Iterative(" + i.ToString() + ") :"+ FindWays_iterative(i));
	}
	
}

public static int FindWays(int n)
{
	if (n < 0)
	{
		throw new Exception("invalid number");
	}
	
	if (n < 2)
	{
		return 1;
	}
	
	return FindWays(n - 1) + FindWays(n-2);
}

// Same as fibonacci
public static int FindWays_iterative(int n)
{
	if (n < 0)
	{
		throw new Exception("Invalid number");
	}
	
	int fibo_1 = 2;
	int fibo_2 = 1;
	
	if (n < 3)
	{
		return n == 2 ? fibo_1 : fibo_2;
	}
	
	int fibo = 0;
	
	for (int i = 3; i <= n; i++)
	{
		fibo = fibo_1 + fibo_2;
		fibo_2 = fibo_1;
		fibo_1 = fibo;
	}
	
	return fibo;
}
// Define other methods and classes here
