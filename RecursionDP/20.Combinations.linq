<Query Kind="Program" />

void Main()
{
	GetCombinations(4, 2).Dump();
}

public static List<List<int>> GetCombinations(int numTotal, int setSize)
{
	List<List<int>> result = new List<List<int>>();
	
	if (numTotal < 1)
	{
		return result;
	}
	
	GetCombinations(1, numTotal, new List<int>(), setSize, result);
	
	return result;
}

private static void GetCombinations(int currentItem, int numTotal, List<int> solution, int setSize, List<List<int>> result)
{
	if (solution.Count == setSize)
	{
		result.Add(new List<int>(solution));
		return;
	}
	
	for (int i = currentItem; i <= numTotal; i++)
	{
		solution.Add(i);
		
		GetCombinations(i + 1, numTotal, solution, setSize, result);
		
		solution.RemoveAt(solution.Count -1);
	}
}

// Define other methods and classes here
