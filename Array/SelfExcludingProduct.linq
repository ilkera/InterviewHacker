<Query Kind="Program" />

void Main()
{
	SelfExcludingProduct(new int[] {3, 1, 4, 2}).Dump();	
}

public static int[] SelfExcludingProduct(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return array;
	}
	
	int[] result = new int[array.Length];
	int[] left = new int[array.Length];
	int[] right = new int[array.Length];
	
	int product = 1;
	for (int i = 0; i < left.Length; i++)
	{
		left[i] = product;
		product *= array[i];
	}
	
	product = 1;
	for (int i = right.Length - 1; i >= 0; i--)
	{
		right[i] = product;
		product *= array[i];
	}
	
	for (int i = 0; i < result.Length; i++)
	{
		if (left[i] * right[i] > int.MaxValue)
		{
			throw new OverflowException("overflow");
		}
		
		result[i] = left[i] * right[i];
	}
	
	return result;
}

// Define other methods and classes here
