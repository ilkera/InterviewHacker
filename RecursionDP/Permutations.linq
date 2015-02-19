<Query Kind="Program" />

void Main()
{
	int[] array = new int[]{1, 2, 3};
	
	GetPermutations(array).Dump();
	
}

public static List<List<int>> GetPermutations(int[] array)
{
	List<List<int>> result = new List<List<int>>();
	
	if (array == null || array.Length < 1)
	{	
		return result;
	}
	
	List<int> solution = new List<int>();
	bool[] visited = new bool[array.Length];
	
	GetPermutationsHelper(array, 0, solution, visited, result);
	
	return result;
}

private static void GetPermutationsHelper(int[] array, int step, List<int> solution, bool[] visited, List<List<int>> result)
{
	if (step == array.Length)
	{
		result.Add(new List<int>(solution));
		return;
	}
	
	for (int i = 0; i < array.Length; i++)
	{
		if (!visited[i])
		{	
			solution.Add(array[i]);
			visited[i] = true;
			GetPermutationsHelper(array, step + 1, solution, visited, result);
			solution.RemoveAt(solution.Count - 1);
			visited[i] = false;
		}
	}
}

// Define other methods and classes here
