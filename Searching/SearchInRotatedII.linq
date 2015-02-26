<Query Kind="Program" />

void Main()
{
	SearchRotated(new int[] {4, 5, 6, 2, 3}, 5).Dump();
	SearchRotated(new int[] {4, 5, 6, 2, 3}, 2).Dump();
	SearchRotated(new int[] {5, 0, 1, 2, 3}, 3).Dump();
	SearchRotated(new int[] {5, 0, 1, 2, 3}, 0).Dump();
	SearchRotated(new int[] {1, 3, 1, 1, 1}, 3).Dump();
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
		
		if (array[mid] > array[low])
		{
			if (array[low] <= target && target < array[mid])
			{
				high = mid - 1;	
			}
			else
			{
				low = mid + 1;
			}
		}
		else if (array[mid] < array[low])
		{
			if (target > array[mid] && target <= array[high])
			{
				low = mid + 1;
			}
			else
			{
				high = mid -1;
			}
		}
		else
		{
			low++;
		}
	}
	
	return -1;
}

// Define other methods and classes here