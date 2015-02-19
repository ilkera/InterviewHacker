<Query Kind="Program" />

void Main()
{
	Tuple<int, int> indices = TwoSum(new int[] {2, 7, 11, 15}, 9);
	(indices.Item1 == 1).Dump();
	(indices.Item2 == 2).Dump();
	
	(TwoSum(null, 4) == null).Dump(); // null
	(TwoSum(new int[] {1}, 4) == null).Dump(); // less than 2 items
	(TwoSum(new int[] {2, 7, 11, 15}, 30) == null).Dump(); // doesn't exist
	
	indices = TwoSum(new int[] {2, 7, 1, 7, 13}, 14);
	(indices.Item1 == 2).Dump();
	(indices.Item2 == 4).Dump();
	
	Console.WriteLine("\nTwo sum via sorting");
	indices = TwoSum_viaSorting(new int[] {2, 7, 11, 15}, 9);
	(indices.Item1 == 1).Dump();
	(indices.Item2 == 2).Dump();
	
	(TwoSum_viaSorting(null, 4) == null).Dump(); // null
	(TwoSum_viaSorting(new int[] {1}, 4) == null).Dump(); // less than 2 items
	(TwoSum_viaSorting(new int[] {2, 7, 11, 15}, 30) == null).Dump(); // doesn't exist
	
	indices = TwoSum_viaSorting(new int[] {2, 7, 1, 7, 13}, 14);
	(indices.Item1 == 3).Dump();
	(indices.Item2 == 5).Dump();

	
}

// Assumption each input contains only 1 solution.
public static Tuple<int,int> TwoSum(int[] array, int target)
{
	if (array == null || array.Length < 2)
	{
		return null;
	}
	
	Tuple<int, int> result = null;
	
	Dictionary<int, int> seenNumbers = new Dictionary<int, int>();
	
	for (int i = 0; i < array.Length; i++)
	{
		if (seenNumbers.ContainsKey(target - array[i]))
		{
			result = new Tuple<int, int>(seenNumbers[target - array[i]] + 1, i + 1);
			break;
		}
		else
		{
			seenNumbers.Add(array[i], i);
		}
	}
	
	return result;
}

public static Tuple<int, int> TwoSum_viaSorting(int[] array, int target)
{
	if (array == null || array.Length < 2)
	{
		return null;
	}
	
	List<Tuple<int, int>> sorted = new List<Tuple<int, int>>();
	Tuple<int, int> result = null;
	
	for (int i = 0; i < array.Length; i++)
	{
		sorted.Add(new Tuple<int, int>(array[i], i));
	}
	
	sorted.Sort((a, b) => a.Item1.CompareTo(b.Item1));
	
	int start = 0;
	int end = sorted.Count - 1;
	
	while (start < end)
	{
		int searched = sorted[start].Item1 + sorted[end].Item1;
		
		if (searched == target)
		{
			result = new Tuple<int, int>(sorted[start].Item2 + 1, sorted[end].Item2 + 1);
			break;
		}
		else if (searched > target)
		{
			end--;
		}
		else
		{
			start++;
		}
	}
	
	return result;
}

// Define other methods and classes here
