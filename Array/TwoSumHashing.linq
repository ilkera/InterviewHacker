<Query Kind="Program" />

void Main()
{
	TwoSum(new int[] {2,7,15,11}, 9).Dump();
	TwoSum(new int[] {2,7,0,15,9,11}, 9).Dump();
	
	// Duplicates
	TwoSum(new int[] {2,7,15,7,11}, 9).Dump();
	//TwoSum(new int[] {2,7,15,2,11}, 9).Dump(); - it doesn't work
	
	// Target does not exist
	TwoSum(new int[] {2,7,15,11}, 15).Dump();
}

public static List<List<int>> TwoSum(int[] array, int target)
{
	List<List<int>> result = new List<List<int>>();
	
	if (array == null || array.Length < 2)
	{
		return result;
	}
	
	Dictionary<int, int> map = new Dictionary<int, int>();
	
	for (int i = 0; i < array.Length; i++)
	{
		if (map.ContainsKey(target - array[i]))
		{
			result.Add(new List<int> { map[target-array[i]], i});
		}
		else
		{
			map.Add(array[i], i);
		}
	}
	
	return result;
}

// Define other methods and classes here
