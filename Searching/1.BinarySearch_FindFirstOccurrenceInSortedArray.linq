<Query Kind="Program" />

void Main()
{	
	Console.WriteLine("Find First");
	(FindFirst(null, 4) == -1).Dump();
	(FindFirst(new int[] {}, 4) == -1).Dump();
	(FindFirst(new int[] {4}, 4) == 0).Dump();
	(FindFirst(new int[] {1,2,3,4,5}, 3) == 2).Dump();
	(FindFirst(new int[] {1,2,3,4,5}, 5) == 4).Dump();
	(FindFirst(new int[] {1,2,3,4,5}, 10) == -1).Dump();
	
	// Duplicates
	(FindFirst(new int[] {1,2,3,4,4,4,4,4,4,5}, 4) == 3).Dump();
	(FindFirst(new int[] {1,4,4,4,4,4,4,5}, 4) == 1).Dump();
	(FindFirst(new int[] {1,4,4,4,4,5,6,7,7,8,9,9,9}, 7) == 7).Dump();
	(FindFirst(new int[] {1,4,4,4,4,5,6,7,7,8,9,9,9}, 9) == 10).Dump();
	
	Console.WriteLine("\nFind First_v2");
	(FindFirst_v2(null, 4) == -1).Dump();
	(FindFirst_v2(new int[] {}, 4) == -1).Dump();
	(FindFirst_v2(new int[] {4}, 4) == 0).Dump();
	(FindFirst_v2(new int[] {1,2,3,4,5}, 3) == 2).Dump();
	(FindFirst_v2(new int[] {1,2,3,4,5}, 5) == 4).Dump();
	(FindFirst_v2(new int[] {1,2,3,4,5}, 10) == -1).Dump();
	
	// Duplicates
	(FindFirst_v2(new int[] {1,2,3,4,4,4,4,4,4,5}, 4) == 3).Dump();
	(FindFirst_v2(new int[] {1,4,4,4,4,4,4,5}, 4) == 1).Dump();
	(FindFirst_v2(new int[] {1,4,4,4,4,5,6,7,7,8,9,9,9}, 7) == 7).Dump();
	(FindFirst_v2(new int[] {1,4,4,4,4,5,6,7,7,8,9,9,9}, 9) == 10).Dump();
	
	Console.WriteLine("\nFind Last");
	(FindLast(null, 4) == -1).Dump();
	(FindLast(new int[] {}, 4) == -1).Dump();
	(FindLast(new int[] {4}, 4) == 0).Dump();
	(FindLast(new int[] {1,2,3,4,5}, 3) == 2).Dump();
	(FindLast(new int[] {1,2,3,4,5}, 5) == 4).Dump();
	(FindLast(new int[] {1,2,3,4,5}, 10) == -1).Dump();
		
	// Duplicates
	(FindLast(new int[] {1,2,3,4,4,4,4,4,4,5}, 4) == 8).Dump();
	(FindLast(new int[] {1,4,4,4,4,4,4,5}, 4) == 6).Dump();
	(FindLast(new int[] {1,4,4,4,4,5,6,7,7,8,9,9,9}, 7) == 8).Dump();
	(FindLast(new int[] {1,4,4,4,4,5,6,7,7,8,9,9,9}, 9) == 12).Dump();
}

public static int FindFirst(int[] array, int key)
{
	if (array == null || array.Length < 1)
	{
		return -1;
	}
	
	if (array[0] == key)
	{
		return 0;
	}
	
	int low = 0;
	int high = array.Length -1;
	
	while (low <= high)
	{
		int mid = low + (high - low)/2;
		
		if (array[mid] == key)
		{
			if (mid > 0 && array[mid - 1] != key)
			{
				return mid;
			}
			else
			{
				high = mid - 1;
			}
		}
		else if (array[mid] > key)
		{
			high = mid -1;
		}
		else
		{
			low = mid + 1;
		}
	}
	
	return -1;
}

public static int FindFirst_v2(int[] array, int key)
{
	if (array == null || array.Length < 1)
	{
		return -1;
	}
		
	int low = 0;
	int high = array.Length -1;
	
	while (low < high && array[low] != key)
	{
		int mid = low + (high - low)/2;
		
		if (array[mid] >= key)
		{
			high = mid;
		}
		else
		{
			low = mid + 1;
		}
	}
	
	if (array[low] == key)
	{
		return low;
	}
	
	return -1;
}

public static int FindLast(int[] array, int key)
{
	if (array == null || array.Length < 1)
	{
		return -1;
	}
	
	if (array[array.Length -1] == key)
	{
		return array.Length - 1;
	}
		
	int low = 0;
	int high = array.Length -1;
	
	while (low <= high)
	{
		int mid = low + (high - low)/2;
		
		if (array[mid] == key)
		{
			if (mid + 1 != array.Length && array[mid + 1] != key)
			{
				return mid;
			}
			else
			{
				low = mid + 1;
			}
		}
		else if (array[mid] > key)
		{
			high = mid -1;
		}
		else
		{
			low = mid + 1;
		}
	}
	
	return -1;
}

// Define other methods and classes here
