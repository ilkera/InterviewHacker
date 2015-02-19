<Query Kind="Program" />

void Main()
{
	(FindMaxProfit(new int[] {}) == 0).Dump();
	(FindMaxProfit(new int[] {3, -2, 1, 4, 5, 8, -2})).Dump();
}

public static int FindMaxProfit(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return 0;
	}
	
	int minPriceSoFar = int.MaxValue;
	int maxProfit = int.MinValue;
	
	for (int i = 0; i < array.Length; i++)
	{
		minPriceSoFar = Math.Min(minPriceSoFar, array[i]);
		maxProfit = Math.Max(maxProfit, array[i] - minPriceSoFar);
	}
	
	return maxProfit;
}

// Define other methods and classes here
