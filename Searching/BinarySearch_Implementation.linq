<Query Kind="Program" />

void Main()
{
	(BinarySearch.Search(null, 4) == false).Dump();
	(BinarySearch.GetIndex(null, 4) == -1).Dump();
	
	(BinarySearch.Search(new int[] {}, 4) == false).Dump();
	(BinarySearch.GetIndex(new int[] {}, 4) == -1).Dump();
		
	(BinarySearch.Search(new int[] {3}, 4) == false).Dump();
	(BinarySearch.GetIndex(new int[] {3}, 4) == -1).Dump();
	
	(BinarySearch.Search(new int[] {4}, 4) == true).Dump();	
	(BinarySearch.GetIndex(new int[] {4}, 4) == 0).Dump();
	
	(BinarySearch.Search(new int[] {1,2,3,4,5,6}, 4) == true).Dump();
	(BinarySearch.GetIndex(new int[] {1,2,3,4,5,6}, 4) == 3).Dump();
		
	(BinarySearch.Search(new int[] {1,2,3,4,5,6}, 6) == true).Dump();
	(BinarySearch.GetIndex(new int[] {1,2,3,4,5,6}, 6) == 5).Dump();
	
	(BinarySearch.Search(new int[] {1,2,3,4,5,6}, 1) == true).Dump();
	(BinarySearch.GetIndex(new int[] {1,2,3,4,5,6}, 1) == 0).Dump();

	(BinarySearch.Search(new int[] {1,2,3,4,5,6}, 10) == false).Dump();
	(BinarySearch.GetIndex(new int[] {1,2,3,4,5,6}, 10) == -1).Dump();

	(BinarySearch.Search(new int[] {1,2,2,2,3,3,3,4}, 3) == true).Dump();
	(BinarySearch.GetIndex(new int[] {1,2,2,2,3,3,3,4}, 3) == 5).Dump();
}

public class BinarySearch
{
	public static bool Search(int[] array, int key)
	{
		if (array == null)
		{
			return false;
		}
		
		int low = 0;
		int high = array.Length - 1;
		
		while (low <= high)
		{
			int mid = low + (high - low) / 2;
			
			if (array[mid] == key)
			{
				return true; // or return the mid index
			}
			else if (array[mid] < key)
			{
				low = mid + 1;
			}
			else
			{
				high = mid - 1;
			}			
		}
		
		return false;
	}
	
	public static int GetIndex(int[] array, int key)
	{
		if (array == null)
		{
			return -1;
		}
		
		int low = 0;
		int high = array.Length - 1;
		
		while (low <= high)
		{
			int mid = low + (high - low) / 2;
			
			if (array[mid] == key)
			{
				return mid; 
			}
			else if (array[mid] < key)
			{
				low = mid + 1;
			}
			else
			{
				high = mid - 1;
			}			
		}
		
		return -1;
	}
	
}
// Define other methods and classes here
