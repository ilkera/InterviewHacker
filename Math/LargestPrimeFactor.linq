<Query Kind="Program" />

void Main()
{
	LargestPrimeFactor(712).Dump();
	LargestPrimeFactor(51).Dump();
}

public static int LargestPrimeFactor(int number)
{
	List<int> factors = new List<int>();
	int current = 2;
	
	while (number > 1)
	{
		while (number % current == 0)
		{
			factors.Add(current);
			number /= current;
		}
		
		if (current > 2)
		{
			current += 2;	
		}
		else
		{
			current += 1;
		}
	}
	
	return factors.Max();
}

// Define other methods and classes here
