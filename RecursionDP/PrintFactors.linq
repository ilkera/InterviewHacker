<Query Kind="Program" />

void Main()
{
	List<List<int>> result = new List<List<int>>();
	PrintFactors(12).Dump();
}

public static List<List<int>> PrintFactors(int number)
{
	List<List<int>> result = new List<List<int>>();
	
	if (number > 1)
	{
		result.Add(new List<int>{number, 1});
	}
	
	PrintFactors(number, new List<int>(), result);
	
	return result;
}

private static void PrintFactors(int number, List<int> current, List<List<int>> resultSet)
{	
	for (int factor = number - 1; factor >= 2 ; factor--)
	{
		if (number % factor == 0)
		{
			int result = number / factor;
			current.Add(result);			
			current.Add(factor);
						
			if (!resultSet.Any(set => current.All(item => set.Contains(item))))
			{
				resultSet.Add(new List<int>(current));
			}
			
			current.RemoveAt(current.Count - 1);
			PrintFactors(factor, current, resultSet);
			current.RemoveAt(current.Count - 1);
		}
	}
}

public static void PrintFactors_v2(string expression, int dividend, int previous)
{
	if (expression == "")
	{
		Console.WriteLine(dividend + " * 1");
	}
	
	for (int factor = dividend - 1 ; factor >=2; factor--)
	{
		if (dividend % factor == 0 && factor <= previous)
		{
			int next = dividend / factor;
			if (next <= factor && next <= previous)
			{
				Console.WriteLine(expression + factor + " * " + next);
			}
			
			PrintFactors_v2(expression + factor + " * ", next, factor);
		}
	}
}

// Define other methods and classes here
