<Query Kind="Program" />

void Main()
{
	PrimeUtil.Generate(30);
	
	for (int i = 0; i < 100; i++)
	{
		Console.WriteLine("IsPrime({0}) = {1}", i, PrimeUtil.IsPrime(i));
	}
}

public class PrimeUtil
{
	public static bool IsPrime(int n)
	{
		if (n <= 3)
		{
			return n >= 2;
		}
		
		if (n % 2 == 0	|| n % 3 == 0)
		{
			return false;
		}
		else
		{
			for (int i = 3; i <= (int)Math.Sqrt(n); i += 2)
			{
				if (n % i == 0)
				{
					return false;
				}
			}
			
			return true;
		}
		
	}
	public static void Generate(int n)
	{
		if (n >= 2)
		{
			bool[] marked = new bool[n];
			
			for (int i = 2; i < n; i++)
			{
				if (!marked[i])
				{
					Console.Write("{0} ", i);
					MarkMultiples(marked, i, n);
				}
			}
		}
	}
	
	private static void MarkMultiples(bool[] array, int start, int end)
	{
		for (int i = 2; i < end; i++)
		{
			if ( i * start < end)
			{
				array[i * start] = true;	
			}
		}
	}
}

// Define other methods and classes here
