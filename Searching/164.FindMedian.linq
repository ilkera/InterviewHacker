<Query Kind="Program" />

void Main()
{
	Median(new int[]{1, 2, 3, 4}).Dump();
	Median(new int[]{1, 2, 3, 4, 5}).Dump();
}

public static double Median(int[] array)
{
	if (array == null || array.Length < 1)
	{
		throw new Exception("empty");
	}
	
	int length = array.Length;
	
	if (length % 2 != 0)
	{
		return array[length/2];
	}
	else
	{
		return (array[length/2] + array[(length/2)-1]) / 2.0;
	}
}
// Define other methods and classes here
