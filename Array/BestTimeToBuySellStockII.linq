<Query Kind="Program" />

void Main()
{
	FindMaxProfit(new int[] {3, -2, 1, 4, 5, -8, -2}).Dump();
}

public static int FindMaxProfit(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return 0;
	}
	
	int sum = 0;
	
	for (int i = 1; i < array.Length; i++)
	{
		int diff = array[i] - array[i-1];
		if (diff > 0)
		{
			sum += diff;
		}		
	}
	
	return sum;
}

// Define other methods and classes here
