<Query Kind="Program" />

void Main()
{
	int[] array = {3, 7, 9 , 1, 10};
	TwoSum(array, 13, 0).Dump();
	ThreeSum(array, 26).Dump();
	ThreeSum(array, 27).Dump();
}

public static bool ThreeSum(int[] array, int target)
{	
	for (int i = 0; i < array.Length; i++)
	{
		if (TwoSum(array, target - array[i], i + 1))
		{
			return true;
		}
	}
	
	return false;
}

public static bool TwoSum(int[] array, int target, int start)
{	
	HashSet<int> seen = new HashSet<int>();
	
	for (int i = start; i < array.Length; i++)
	{
		if (seen.Contains(target - array[i]))
		{
			return true;
		}
		seen.Add(array[i]);
	}
	
	return false;
}

// Define other methods and classes here