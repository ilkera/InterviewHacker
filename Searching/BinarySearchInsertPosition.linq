<Query Kind="Program" />

void Main()
{
	Insert(new int[] {1, 2, 3}, 4).Dump();	
	Insert(new int[] {1, 2, 3}, 0).Dump();	
	Insert(new int[] {1, 3, 4}, 2).Dump();
	Insert(new int[] {1, 1, 2}, 2).Dump();
	Insert(new int[] {1, 1, 2}, 1).Dump();
	Insert(new int[] {1, 1, 2}, 0).Dump();
}

public static int Insert(int[] array, int target)
{
	if (array == null)
	{
		return -1;
	}
	
	if (array.Length < 1)
	{
		return 0;
	}
	
	int low = 0;
	int high = array.Length - 1;
	
	while (low <= high)
	{
		int mid = low + (high - low) / 2;
		
		if (array[mid] == target)
		{
			return mid;
		}
		else if (mid > 0 && array[mid] > target && array[mid - 1] < target)
		{
			return mid;
		}
		else if (array[mid] > target)
		{
			high = mid - 1;
		}
		else
		{
			low = mid + 1;
		}
	}
	
	return low;
}

// Define other methods and classes here