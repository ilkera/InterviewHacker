<Query Kind="Program" />

void Main()
{
	int[] array = {5, 6, 1, 2, 0, 3, 0, 7, 4};
		
	QuickSort(array, 0, array.Length-1);
	
	array.Dump();
}

public static void QuickSort(int[] array, int left, int right)
{
    if (left < right)
	{
        int pivot = Partition(array, left, right);
		QuickSort(array, left, pivot - 1);
		QuickSort(array, pivot + 1, right);
	}
}

private static int Partition(int[] array, int left, int right)
{
	int pivot = array[right];
	int pivotIndex = left;
	
	for (int i = left; i < right; i++)
	{
		if (pivot >= array[i])
		{
			Swap(array, i, pivotIndex++);
		}
	}
	
	Swap(array, right, pivotIndex);
	
	return pivotIndex;
}

private static void Swap(int[] array, int src, int dest)
{
	int temp = array[src];
	array[src] = array[dest];
	array[dest] = temp;
}

// Define other methods and classes here