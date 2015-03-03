<Query Kind="Program" />

void Main()
{
	GetFirstMissingPositive(new int[] {1, 2, 0}).Dump();
	GetFirstMissingPositive(new int[] {3, 4, 1, -1}).Dump();
	GetFirstMissingPositive(new int[] {3, 2, 5, 1, 7}).Dump();
}

public static int GetFirstMissingPositive(int[] array)
{
	if (array == null || array.Length < 1)
	{
		throw new Exception("null array");
	}
	
	int length = array.Length;
	for (int i = 0; i < length; i++)
	{
		if (array[i] > 0 && array[i] <= length)
		{
			while (array[i] != i + 1)
			{
				Swap(array, array[i] - 1, i);
				
				if (array[i] <= 0 || array[i] > length)
				{
					break;
				}
			}
		}
	}
	
	int current = 0;
	while (current < length)
	{
		if (array[current] != current + 1)
		{
			return current + 1;
		}
		++current;
	}
	
	return current + 1;
}

private static void Swap(int[] array, int src, int dest)
{
	int temp = array[src];
	array[src] = array[dest];
	array[dest] = temp;
}

// Define other methods and classes here
