<Query Kind="Program" />

void Main()
{
	FindPeak_Linear(new int[] {1, 2, 3, 1}).Dump();	
	FindPeak_Linear(new int[] {1, 2, 3, 4}).Dump();
	FindPeak(new int[] {1, 2, 3, 1}).Dump();
	FindPeak(new int[] {1, 2, 3, 4}).Dump();
	FindPeak(new int[] {1, 2, 3, 4, 5, 0, 0, 0}).Dump();
}

public static int FindPeak(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return -1;
	}
	
	int low = 0;
	int high = array.Length - 1;
	
	while (low <= high)
	{
		int mid = low + (high - low) / 2;
		
		if (low == high)
		{
			return low;
		}
		
		if (mid + 1 <= high && array[mid + 1] > array[mid])
		{
			low = mid + 1;
		}
		else
		{
			high = mid;
		}
	}
	
	return low;
}

public static int FindPeak_Linear(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return -1;
	}
	
	for (int i = 1; i < array.Length; i++)
	{
		if (array[i] < array[i-1])
		{
			return i - 1;
		}
	}
	return array.Length - 1;
}

// Define other methods and classes here
