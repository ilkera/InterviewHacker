<Query Kind="Program" />

void Main()
{
	(GetFirstMissingPositive(new int[] {1, 2, 0}) == 3).Dump();
	(GetFirstMissingPositive(new int[] {3, 4, -1, 1}) == 2).Dump();
	(GetFirstMissingPositive(new int[] {1, 2, 2}) == 3).Dump();
	(GetFirstMissingPositive(new int[] {5, 5, 5, 5, 5, 5}) == 1).Dump();
	(GetFirstMissingPositive(new int[] {3, 2, 1}) == -1).Dump();
	(GetFirstMissingPositive(new int[] {3, 2, 1, 0}) == 4).Dump();
}

public static int GetFirstMissingPositive(int[] array)
{
	if (array == null || array.Length < 1)
	{
		throw new Exception("Empty/null array");
	}
	
	HashSet<int> map = new HashSet<int>();
	
	for (int i = 0; i < array.Length; i++)
	{
		if (array[i] > 0)
		{
			map.Add(array[i]);
		}
	}
	
	for (int i = 1; i <= array.Length; i++)
	{
		if (!map.Contains(i))
		{
			return i;
		}
	}

	return -1;
}

// Define other methods and classes here
