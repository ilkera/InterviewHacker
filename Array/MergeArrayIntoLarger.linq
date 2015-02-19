<Query Kind="Program" />

void Main()
{
	int[] small = {1, 4, 7};
	int[] large = {2, 3, 8, 12, 14, 0, 0, 0, 0};
	
	MergeArray(large, small, 4);
	
	large.Dump();
}

public static void MergeArray(int[] large, int[] small, int largeEndIndex)
{
	if (large.Length == largeEndIndex + 1 || small.Length + largeEndIndex > large.Length)
	{
		throw new Exception("No empty spot left");
	}
	
	int currentEnd = largeEndIndex + small.Length;
	int currentLarge = largeEndIndex;
	int currentSmall = small.Length - 1;
	
	while (currentSmall >= 0 && currentLarge >= 0)
	{
		if (large[currentLarge] < small[currentSmall])
		{
			large[currentEnd] = small[currentSmall--];
		}
		else
		{
			large[currentEnd] = large[currentLarge--];
		}
		currentEnd--;
	}
	
	while (currentSmall >= 0)
	{
		large[currentEnd--] = small[currentSmall--];
	}
}

// Define other methods and classes here
