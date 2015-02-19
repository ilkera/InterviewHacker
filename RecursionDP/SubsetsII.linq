<Query Kind="Program" />

void Main()
{
	FindSubsets(new int[] { 1, 2, 2}).Dump();	
}

public static List<List<int>> FindSubsets(int[] array)
{
	List<List<int>> result = new List<List<int>>();
	
	if (array == null || array.Length < 1)
	{
		return result;	
	}
	
	int[] copy = array.ToArray();
	Array.Sort(copy);
	result.Add(new List<int>()); // empty
	
	GenerateSubsets(copy, 0, new List<int>(), result);
	
	return result;
}

private static void GenerateSubsets(int[] array, int current, List<int> solution, List<List<int>> result)
{
	for (int i = current; i < array.Length; i++)
	{
		solution.Add(array[i]);
		result.Add(new List<int>(solution));
		
		if (i + 1 < array.Length)
		{
			GenerateSubsets(array, i + 1, solution, result);
		}
		
		solution.RemoveAt(solution.Count - 1);
		
		while(i + 1 <array.Length && array[i] == array[i+1])
		{	
			i++;
		}
	}
}

// Define other methods and classes here
