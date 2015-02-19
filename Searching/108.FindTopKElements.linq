<Query Kind="Program" />

void Main()
{
	int[] array = new int[]{4,9,20, 12, 7, 11, 15, 16};
	
	QuickSelect.FindKthSmallest(array, 1).Dump();
	QuickSelect.FindKthSmallest(array, 2).Dump();
	QuickSelect.FindKthSmallest(array, 3).Dump();
	QuickSelect.FindKthSmallest(array, 4).Dump();
	QuickSelect.FindKthSmallest(array, 5).Dump();
	
	Console.WriteLine("\n Largest");
	QuickSelect.FindKthLargest(array, 1).Dump();
	QuickSelect.FindKthLargest(array, 2).Dump();
	QuickSelect.FindKthLargest(array, 3).Dump();
	QuickSelect.FindKthLargest(array, 4).Dump();
	QuickSelect.FindKthLargest(array, 5).Dump();
}

public class QuickSelect
{
	public static int FindKthSmallest(int[] items, int k)
	{
		if (items == null || items.Length < 1 || items.Length < k || k < 1 || k > items.Length)
		{
			throw new Exception("invalid");
		}
		
		int left = 0;
		int right = items.Length - 1;
		int pivotIndex = RandomizedPartition(items, left, right);
		
		while (pivotIndex + 1 != k)
		{	
			if (pivotIndex + 1 > k)
			{
				right = pivotIndex - 1;
			}
			else
			{
				left = pivotIndex + 1;
			}
			
			pivotIndex = RandomizedPartition(items, left, right);
		}
		
		return items[pivotIndex];
	}
	
	public static int FindKthLargest(int[] items, int k)
	{
		if (items == null || items.Length < 1 || items.Length < k || k < 1 || k > items.Length)
		{
			throw new Exception("invalid");
		}
		
		int left = 0;
		int right = items.Length - 1;
		int pivotIndex = RandomizedPartition(items, left, right, true);
		
		while (pivotIndex + 1 != k)
		{	
			if (pivotIndex + 1 > k)
			{
				right = pivotIndex - 1;
			}
			else
			{
				left = pivotIndex + 1;
			}
			
			pivotIndex = RandomizedPartition(items, left, right, true);
		}
		
		return items[pivotIndex];
	}
	
	public static int Partition(int[] items, int left, int right, bool partitionByLargest)
	{
		int pivot = items[right];
		int pivotIndex = left;
		
		for (int i = left; i < right; i++)
		{
			if (partitionByLargest)
			{
				if (items[i] >= pivot)
				{
					Swap(items, i, pivotIndex++);
				}
			}
			else
			{
				if (items[i] <= pivot)
				{
					Swap(items, i, pivotIndex++);
				}	
			}
		}
		
		Swap(items, pivotIndex, right);
		
		return pivotIndex;
	}
	
	private static void Swap(int[] array, int source, int dest)
	{
		int temp = array[source];
		array[source] = array[dest];
		array[dest] = temp;
	}
	
	private static int RandomizedPartition(int[] items, int left, int right, bool partitionByLargest = false)
	{
		Random rnd = new Random();
		
		int randomIndex = (int) Math.Round(left + rnd.NextDouble()*(right - left));
		
		Swap(items, randomIndex, right);
		
		return Partition(items, left, right, partitionByLargest);
	}
}

// Define other methods and classes here