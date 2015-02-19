<Query Kind="Program" />

void Main()
{
	SingleNumber(new int[] {2, 3, 1, 1, 3}).Dump();
}

public static int SingleNumber(int[] array)
{
	if (array == null || array.Length < 1)
	{
		throw new ArgumentNullException("invalid array");
	}
	
	int left = array[0];
	
	for (int i = 1; i < array.Length; i++)
	{
		left = left ^ array[i];
	}
	
	return left;
}

// Define other methods and classes here
