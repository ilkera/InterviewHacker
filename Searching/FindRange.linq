<Query Kind="Program" />

void Main()
{
	int[] array = {1,2,4,4,5,8,12,15,15,23,54};
	
	List<int> result = FindRange(array, 4, 15);
	
	result.Dump();
}

public static List<int> FindRange(int[] array, int lowerBound, int upperBound)
{
	List<int> result = new List<int>();
	 
	if (array == null || array.Length < 1)
	{
		return result;
	}
	
	int leftIndex = SearchOccurrence(array, lowerBound, true);
	int rightIndex = SearchOccurrence(array, upperBound, false);
	
	
	for (int i = leftIndex; i <= rightIndex; i++)
	{
		result.Add(array[i]);
	}
	
	return result;
}

private static int SearchOccurrence(int[] array, int target, bool firstOccurence)
{
	int low = 0;
	int high = array.Length - 1;
	
	while (low <= high)
	{
		int mid = low + (high - low) / 2;
		
		if (array[mid] == target)
		{
			if (firstOccurence)
			{
				if (mid - 1 >= 0 && array[mid-1] < target)
				{
					return mid;
				}
				else
				{
					high = mid - 1;
				}
			}			
			else
			{
				if (mid + 1 < array.Length && array[mid+1] > target)
				{
					return mid;
				}
				else
				{
					low = mid + 1;
				}
			}
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
	
	return -1;
}

// Define other methods and classes here
