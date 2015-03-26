<Query Kind="Program" />

void Main()
{
	int[] array = {0,1,0,2,1,0,1,3,2,1,2,1};
	Trap(array).Dump();
	Trap_Alternative(array).Dump();
}	

public static int Trap_Alternative(int[] array)
{
	if (array == null || array.Length < 2)
	{
		return 0;
	}
	
	int indexMaxHeight = FindMaxHeight(array);
	
	int height = 0;
	int left = 0;
	
	for (int i = 1; i < indexMaxHeight; i++)
	{
		if (array[i] >= array[left])
		{
			left = i;
		}
		else
		{
			height += Math.Abs(array[left] - array[i]);
		}
	}
	
	int right = array.Length - 1;
	for (int i = array.Length - 2; i > indexMaxHeight; --i)
	{
		if (array[i] >= array[right])
		{
			right = i;
		}
		else
		{
			height += Math.Abs(array[right] - array[i]);
		}
	}
	
	return height;
}

private static int FindMaxHeight(int[] array)
{
	int maxIndex = 0;
	
	for (int i = 1; i < array.Length; i++)
	{
		if (array[i] > array[maxIndex])
		{
			maxIndex = i;
		}
	}
	
	return maxIndex;
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