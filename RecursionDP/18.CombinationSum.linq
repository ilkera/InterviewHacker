<Query Kind="Program" />

void Main()
{
	FindCombinationSum(new int[] {7, 3, 2, 6}, 7).Dump();
}

public static List<List<int>> FindCombinationSum(int[] array, int target)
{
	List<List<int>> result = new List<List<int>>();
	
	if (array == null || array.Length < 1)
	{
		return result;	
	}
	
	List<int> sorted = array.ToList();
	sorted.Sort();
	
	GetCombinations(sorted, 0, target, 0, new List<int>(), result);
	
	return result;
}

private static void GetCombinations(
								List<int> sorted, 
								int currentIndex,
								int target,
								int currentSum,
								List<int> solution,
								List<List<int>> result)
{
	if (currentSum > target)
	{
		return;
	}
	
	if (currentSum == target)
	{
		result.Add(new List<int>(solution));
		return;
	}
	
	for (int i = currentIndex; i < sorted.Count; i++)
	{
		currentSum += sorted[i];
		solution.Add(sorted[i]);
		
		GetCombinations(sorted, i, target, currentSum, solution, result);
		
		solution.RemoveAt(solution.Count - 1);
		currentSum -= sorted[i];
	}
}

// Define other methods and classes here
