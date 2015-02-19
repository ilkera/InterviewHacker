<Query Kind="Program" />

void Main()
{
	int[] array = {0,1,0,2,1,0,1,3,2,1,2,1};
	Trap(array).Dump();
}	

public static int Trap(int[] array)
{
	if (array == null || array.Length < 2)
	{
		return 0;
	}
	
	int[] leftMaxSoFar = new int[array.Length];
	int[] rightMaxSoFar = new int[array.Length];
	
	int water = 0;
	for (int i = 0; i < array.Length; i++)
	{
		leftMaxSoFar[i] = i == 0 ? array[i] : Math.Max(array[i], leftMaxSoFar[i-1]);
	}
	
	for (int i = array.Length - 1; i >= 0; i--)
	{
		rightMaxSoFar[i] = i == array.Length - 1 ? array[i] : Math.Max(array[i], rightMaxSoFar[i + 1]);
	}
	
	for (int i = 0; i < array.Length; i++)
	{
		int height = Math.Min(leftMaxSoFar[i], rightMaxSoFar[i]) - array[i];
		if (height > 0)
		{
			water += height;
		}
	}
	
	return water;
}

// Define other methods and classes here
