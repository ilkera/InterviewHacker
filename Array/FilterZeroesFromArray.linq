<Query Kind="Program" />

void Main()
{
	FilterZeroes(new int[] {0, 1, 3, 0, 2, 0, 4, 1, 0, 0, 2}).Dump();
}

public static int FilterZeroes(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return -1;
	}
	
	int zeroEnd = 0;
	
	for (int i = 0; i < array.Length; i++)
	{
		if (array[i] != 0)
		{
			array[zeroEnd] = array[i];
			zeroEnd++;
			array[i] = 0;
		}
	}
	
	return zeroEnd;
}

// Define other methods and classes here
