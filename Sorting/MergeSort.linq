<Query Kind="Program" />

void Main()
{
	int[] array = {5, 6, 1, 2, 0, 8, 9, 3, 0, 7, 4};
		
	MergeSort(array, 0, array.Length-1);
	
	array.Dump();
}

public static void MergeSort(int[] array, int start, int end)
{	
	if (start >= end)
	{
		return;
	}
	
	int mid = start + (end - start)/2;
	
	MergeSort(array, start, mid);
	MergeSort(array, mid + 1, end);
	Merge(array, start, mid, end);
}

private static void Merge(int[] array, int start, int mid, int end)
{
	int[] left = new int[mid - start + 1];
	int[] right = new int[end - mid];
	
	for (int i = start; i <= mid; i++)
	{
		left[i - start] = array[i];
	}
	
	for (int i = mid + 1; i <= end; i++)
	{
		right[i - (mid + 1)] = array[i];
	}
	
	int iLeft = 0;
	int iRight = 0;
	int current = start;
	
	while (iLeft < left.Length && iRight < right.Length)
	{
		if (left[iLeft] < right[iRight])
		{
			array[current] = left[iLeft];
			iLeft++;
		}
		else
		{
			array[current] = right[iRight];
			iRight++;
		}
		current++;
	}
	
	while (iLeft < left.Length)
	{
		array[current++] = left[iLeft++];
	}
	
	while (iRight < right.Length)
	{
		array[current++] = right[iRight++];
	}	
}

// Define other methods and classes here