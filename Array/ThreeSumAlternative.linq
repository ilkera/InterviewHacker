<Query Kind="Program" />

void Main()
{
	int[] array = {2, 5, 1, 7, 11, 6, 0};
	ThreeSum(array, 18).Dump();
}

public static List<List<int>> ThreeSum(int[] array, int k)
{
	List<List<int>> result = new List<List<int>>();
	
	if (array != null && array.Length > 2)
	{
		Dictionary<int, int> map = PutAllIndex(array);
		
		for (int i = 0; i < array.Length - 2; i++)
		{
			List<List<int>> indexes = null;
			
			if (TwoSum(array, i + 1, array.Length - 1, k - array[i], map, ref indexes))
			{
				foreach (var indexPair in indexes)
				{
					indexPair.Add(i);
					result.Add(indexPair);
				}
			}
		}
	}
	
	return result;
}

private static bool TwoSum(int[] array, int start, int end, int k, Dictionary<int, int> map, ref List<List<int>> result)
{
	bool hasAnyFound = false;
	result = new List<List<int>>();
	
	for (int i = start; i <= end; i++)
	{
		if (map.ContainsKey(k - array[i]) && map[k - array[i]] > i)
		{
			result.Add(new List<int>() { i, map[k-array[i]]});
			hasAnyFound = true;
		}
	}
	
	return hasAnyFound;
}

private static Dictionary<int, int> PutAllIndex(int[] array)
{
	Dictionary<int, int> map = new Dictionary<int, int>();
	
	for (int i = 0; i < array.Length; i++)
	{
		map.Add(array[i], i);
	}
	
	return map;
}

// Define other methods and classes here
