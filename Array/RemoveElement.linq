<Query Kind="Program" />

void Main()
{
	RemoveElement(new int[] {1, 2, 3, 3}, 3).Dump();
	RemoveElement(new int[] {3, 3, 3, 3}, 3).Dump();
	RemoveElement(new int[] {1, 2, 3, 4}, 5).Dump();
}

public static int RemoveElement(int[] array, int target)
{
	if (array == null || array.Length < 1)
	{
		return 0;
	}
	
	int current = 0;
	for (int i = 0; i < array.Length; i++)
	{
		if (array[i] == target)
		{
			continue;
		}
		
		array[current++] = array[i];
	}
	
	return current;
}

// Define other methods and classes here