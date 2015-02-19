<Query Kind="Program" />

void Main()
{
	GetMaxSum(new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}).Dump();
	GetMaxSum(new int[] {1, 2, 3, 4}).Dump();
	GetMaxSum(new int[] {-1, 0, -2, -4}).Dump();
}

public static int GetMaxSum(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return 0;
	}
	
	int sum = 0;
	int maxSoFar = int.MinValue;
	
	for (int i = 0; i < array.Length; i++)
	{
		sum = Math.Max(sum + array[i], array[i]);
		maxSoFar = Math.Max(sum, maxSoFar);
	}
	
	return maxSoFar;
}

// Define other methods and classes here
