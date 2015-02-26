<Query Kind="Program" />

void Main()
{
	int[] array = {2, 3, 6, 7};
	
	List<List<int>> result = new List<List<int>>();
	GetCombinations(array, 7, 0, new List<int>(), result);
	result.Dump();
}

public static void GetCombinations(int[] array, int target, int sum, List<int> solution, List<List<int>> result)
{
	if (sum == target)
	{
		if (!result.Any(set => solution.All(item => set.Contains(item))))
		{
			result.Add(new List<int>(solution));	
		}
		return;
	}
	
	for (int i = 0; i < array.Length; i++)
	{
		if (sum + array[i] <= target)
		{
			sum += array[i];
			solution.Add(array[i]);
			GetCombinations(array, target, sum, solution, result);
			solution.RemoveAt(solution.Count - 1);
			sum -= array[i];
		}
	}
}


// Define other methods and classes here
