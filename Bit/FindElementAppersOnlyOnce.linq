<Query Kind="Program" />

void Main()
{
	FindSingle(new int[]{12, 1, 12, 3, 12, 1, 1, 2, 3, 2, 2, 3, 7}).Dump();
}

public static int FindSingle(int[] array)
{
	if (array == null || array.Length < 1)
	{
		throw new Exception("Exception");
	}
	
	int result = 0;
	int sum = 0;
	int pos = 0;
	
	for (int i = 0; i < 32; i++)
	{
		sum = 0;
		pos = 1 << i;
		for (int index = 0; index < array.Length; index++)
		{
			if((array[index] & pos) != 0)
			{
				sum++;
			}
		}
		if (sum % 3 != 0)
		{
			result |= pos;
		}
	}
	
	return result;
	
}
// Define other methods and classes here
