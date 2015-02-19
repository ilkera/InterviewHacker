<Query Kind="Program" />

void Main()
{
	TwoSum(new int[] { 4, 9, -1, 2, 3, -5, -2}).Dump();	
	TwoSum(new int[] {4, -2147483648, -2147483648}).Dump();
	TwoSum(new int[] {4, 2147483647, 2147483647}).Dump();	
}

public static bool TwoSum(int[] array)
{
	if (array == null || array.Length < 2)
	{
		return false;
	}
	
	HashSet<int> seenNumbers = new HashSet<int>();
	
	for (int i = 0; i < array.Length; i++)
	{	
		if (seenNumbers.Contains(-array[i]))
		{
			return -array[i] != int.MinValue;
		}
		else
		{
			seenNumbers.Add(array[i]);	
		}
	}
	
	return false;
}

// Define other methods and classes here
