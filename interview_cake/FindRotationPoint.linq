<Query Kind="Program" />

void Main()
{
	FindRotationPoint(new int[] {5, 6, 7, 8, 1, 2, 3}).Dump();
	FindRotationPoint(new int[] {5, 6, 7, 8, 9, 10, 3}).Dump();
	FindRotationPoint(new int[] {5, 1, 2, 3, 4}).Dump();
	FindRotationPoint(new int[] {5, 6, 7, 8, 9, 10, 11}).Dump();
}

public static int FindRotationPoint(int[] array)
{
	int low = 0;
	int high = array.Length - 1;
	int first = array[0];
	
	while (low <= high)
	{
		int mid = low + (high - low) / 2;
		
		if (array[mid] >= first)
		{
			low = mid + 1;
		}
		else
		{
			high = mid - 1;
		}

		if (low + 1 == array.Length && array[low] > first)
		{
			return 0;
		}
	}
	
	return low;
}

// Define other methods and classes here
