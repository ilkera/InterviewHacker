<Query Kind="Program" />

void Main()
{
	int[] array = {5, 6, 1, 2, 0, 8, 9, 3, 7, 4};
		
	SelectionSort(array);
	
	array.Dump();
}

public static void SelectionSort(int[] array)
{
	if (array == null || array.Length < 2)
	{
		return;
	}
	
	for (int i = 0; i < array.Length; i++)
	{
		int minIndex = FindMin(array, i, array.Length - 1);
		Swap(array, i, minIndex);
	}
}

private static int FindMin(int[] array, int start, int end)
{
	int minValue = array[start];
	int minIndex = start;
	
	for (int i = start + 1; i <= end; i++)
	{
		if (minValue > array[i])
		{
			minValue = array[i];
			minIndex = i;
		}
	}	
	return minIndex;
}

private static void Swap(int[] array, int src, int dest)
{
	int temp = array[src];
	array[src] = array[dest];
	array[dest] = temp;
}

// Define other methods and classes here