<Query Kind="Program" />

void Main()
{
	int[] array = {1, 100, 2, 105, -10, 30, 100};	
	MaxDifference(array).Dump();
}

public static int MaxDifference(int[] array)
{
	if (array == null || array.Length < 1)
	{
		throw new ArgumentException("invalid array");
	}
	
	int minElement = array[0];
	int maxDiff = int.MinValue;
	
	for (int i = 1; i < array.Length; i++)
	{
		int currentDiff = array[i] - minElement;
		maxDiff = Math.Max(maxDiff, currentDiff);
		minElement = Math.Min(minElement, array[i]);		
	}
	
	return maxDiff;	
}
// Define other methods and classes here
