<Query Kind="Program" />

void Main()
{
	for (int i = 0; i < 10; i++)
	{
		Console.WriteLine("Fibonacci recursive {0} is {1}", i, Fibo_Recursive(i));
	}
	
	int[] cache;
	for (int i = 2; i < 10; i++)
	{
		cache = new int[i + 1];
		cache[0] = 0;
		cache[1]= 1;
		cache[2]= 1;
		Console.WriteLine("Fibonacci recursive optimized {0} is {1}", i, Fibo_Recursive_Optimized(i, cache));
	}
	
	for (int i = 2; i < 10; i++)
	{
		Console.WriteLine("Fibonacci iterative {0} is {1}", i, Fibo(i));
	}
	
	Fibo(47).Dump();
	int.MaxValue.Dump();
}

public static int Fibo(int n)
{
	if (n < 0)
	{
		return -1;
	}
	
	if (n == 0)
	{
		return 0;
	}
	
	if (n < 3)
	{
		return 1;
	}
	
	if (n > 46)
	{
		throw new OverflowException("overflow");
	}
	
	int prev = 1;
	int prev_prev = 1;
	int current = 0;
	
	for (int i = 3; i <= n; i++)
	{
		current = prev + prev_prev;
		prev_prev = prev;
		prev = current;
	}
	
	return current;
}

public static int Fibo_Recursive_Optimized(int n, int[] cache)
{
	if (n < 0)
	{
		return -1;
	}
	
	if (cache[n] != 0)
	{
		return cache[n];
	}
	
	cache[n] = Fibo_Recursive_Optimized(n-2, cache) + Fibo_Recursive_Optimized(n-1, cache);
	
	return cache[n];
}

public static int Fibo_Recursive(int n)
{
	if (n < 0)
	{
		return -1;
	}
	
	if (n == 0)
	{
		return 0;
	}
	
	if (n < 3)
	{
		return 1;
	}
	
	return Fibo_Recursive(n-2) + Fibo_Recursive(n-1);
}

// Define other methods and classes here