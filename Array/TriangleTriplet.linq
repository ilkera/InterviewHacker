<Query Kind="Program" />

void Main()
{
	FindTriplets(null).Dump();
	FindTriplets(new int[] {3, 1, 2}).Dump();
	FindTriplets(new int[] {7, 2, 11, 4, 6}).Dump();
}

public static List<List<int>> FindTriplets(int[] array)
{
	List<List<int>> result = new List<List<int>>();
	
	if (array == null || array.Length < 3)
	{
		return result;
	}
	
	int[] copy = array.ToArray();
	Array.Sort(copy);
	
	for (int i = copy.Length - 1; i >= 2; i--)
	{
		List<List<int>> sumGreaterThanCurrent = FindTwoSumGreaterThan(copy, 0, i-1, copy[i]);
		
		foreach (var set in sumGreaterThanCurrent)
		{
			set.Add(copy[i]);
			result.Add(set);
		}
	}
	
	return result;
}

private static List<List<int>> FindTwoSumGreaterThan(int[] array, int start, int end, int target)
{
	List<List<int>> result = new List<List<int>>();
	
	if (array == null || array.Length < 2)
	{
		return result;	
	}
	
	while (start < end)
	{
		if (array[start] + array[end] >= target)
		{
			List<int> solution = new List<int>();
			solution.Add(array[start]);
			solution.Add(array[end]);
			result.Add(solution);
		}
		start++;
	}
	
	return result;
}

// Define other methods and classes here
