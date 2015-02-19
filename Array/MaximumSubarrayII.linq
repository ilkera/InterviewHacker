<Query Kind="Program" />

void Main()
{
	GetMaxSubArray(new int[] {-2, 11, -4, 13, -5, -2}).Dump();
	GetMaxSubArray(new int[] {1, -3, 4, -2, 1, 6}).Dump();
}

public static List<int> GetMaxSubArray(int[] array)
{
	List<int> result = new List<int>();
	
	if (array == null || array.Length < 1)
	{
		return result;	
	}
	
	int currentSum = 0;
	int previousSum = 0;
	int maxSoFar = int.MinValue;
	int start = 0;
	int end = 0;
	
	for (int i = 0; i < array.Length; i++)
	{
		currentSum = Math.Max(array[i], array[i] + currentSum);
		
		if (currentSum > 0)
		{
			if (previousSum < 0)
			{
				start = i;
				end = i;
			}
			else
			{
				if (currentSum > maxSoFar)
				{
					end = i;
				}
			}
		}
		
		maxSoFar = Math.Max(currentSum, maxSoFar);
		previousSum = currentSum;		
	}
	
	for (int i = start; i <= end; i++)
	{
		result.Add(array[i]);
	}
	
	return result;
}

// Define other methods and classes here
