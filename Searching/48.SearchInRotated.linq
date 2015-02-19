<Query Kind="Program" />

void Main()
{
	SearchRotated(new int[] {4, 5, 6, 7, 0, 1, 2}, 10).Dump();
	SearchRotated(new int[] {4, 5, 6, 7, 0, 1, 2}, 4).Dump();
	SearchRotated(new int[] {4, 5, 6, 7, 0, 1, 2}, 5).Dump();
	SearchRotated(new int[] {4, 5, 6, 7, 0, 1, 2}, 6).Dump();
	SearchRotated(new int[] {4, 5, 6, 7, 0, 1, 2}, 7).Dump();
	SearchRotated(new int[] {4, 5, 6, 7, 0, 1, 2}, 0).Dump();
	SearchRotated(new int[] {4, 5, 6, 7, 0, 1, 2}, 1).Dump();
	SearchRotated(new int[] {4, 5, 6, 7, 0, 1, 2}, 2).Dump();
	
	
	SearchRotated(new int[] {4, 5, 6, 2, 3}, 5).Dump();
	SearchRotated(new int[] {4, 5, 6, 2, 3}, 2).Dump();
	SearchRotated(new int[] {5, 0, 1, 2, 3}, 2).Dump();
	SearchRotated(new int[] {5, 0, 1, 2, 3}, 0).Dump();
	
	SearchRotated(new int[] {1, 1, 1, 1, 5, 1}, 5).Dump();
}

public static int SearchRotated(int[] array, int target)
{
	if (array == null || array.Length < 1)
	{
		return -1;
	}
	
	int low = 0;
	int high = array.Length - 1;
	
	while (low <= high)
	{
		int mid = low + (high - low)/2;
		
		if (array[mid] == target)
		{
			return mid;
		}
		
		if (array[mid] >= array[low])
		{
			if (array[low] <= target && target <= array[mid])
			{
				high = mid - 1;	
			}
			else
			{
				low = mid + 1;
			}
		}
		else
		{
			if (target >= array[mid] && target <= array[low])
			{
				low = mid + 1;
			}
			else
			{
				high = mid -1;
			}
		}
	}
	
	return -1;
}

// Define other methods and classes here
