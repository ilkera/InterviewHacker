<Query Kind="Program" />

void Main()
{	
	ProductArray(new int[] {1, 7, 3, 4}).Dump();
	ProductArray(new int[] {1, 0, 3, 4}).Dump();
	ProductArray(new int[] {1, 0, 3, 0}).Dump();
}

public int[] ProductArray(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return null;
	}
	
	int[] result = new int[array.Length];
	
	int product = 1;	
	for (int i = 0; i < array.Length; i++)
	{
		result[i] = product;
		product *= array[i];
	}
	
	product = 1;
	for (int i = array.Length - 1; i >= 0; i--)
	{
		result[i] *= product;
		product *= array[i];
	}

	return result;
}

// Define other methods and classes here
