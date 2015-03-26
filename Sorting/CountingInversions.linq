<Query Kind="Program" />

void Main()
{
	CountInversions_BruteForce(new int[] {1, 3, 5, 2, 4, 6}).Dump();
	CountInversions(new int[] {1, 3, 5, 2, 4, 6}).Dump();
}

public int CountInversions(int[] array)
{
	if (array == null || array.Length < 2)
	{
		return 0;
	}
	
	return CountInversionsHelper(array, 0, array.Length - 1);
}

private int CountInversionsHelper(int[] array, int low, int high)
{
	if (low >= high)
	{
		return 0;
	}
	
	int mid = low + (high - low) / 2;
	int leftInversion = CountInversionsHelper(array, low, mid);
	int rightInversion = CountInversionsHelper(array, mid + 1, high);
	int splitInversion = CountSplitInversion(array, low, mid, high);
	
	return leftInversion + rightInversion + splitInversion;
}

private static int CountSplitInversion(int[] array, int leftStart, int leftEnd, int rightEnd)
{
	int[] left = new int[leftEnd - leftStart + 1];
	int[] right = new int[rightEnd - leftEnd];
	
	// Copy left
	for (int i = leftStart; i <= leftEnd; i++)
	{
		left[i - leftStart] = array[i];
	}
	
	// Copy right
	for (int i = leftEnd + 1; i <= rightEnd; i++)
	{
		right[i - (leftEnd + 1)] = array[i];
	}
	
	int inversionCount = 0;
	int iLeft = 0;
	int iRight = 0;
	int current = leftStart;
	
	while (iLeft < left.Length && iRight < right.Length)
	{
		if (left[iLeft] <= right[iRight])
		{
			array[current++] = left[iLeft++];
		}
		else
		{
			inversionCount += left.Length - iLeft;
			array[current++] = right[iRight++];
		}
	}
	
	while (iLeft < left.Length)
	{
		array[current++] = left[iLeft++];
	}
	
	while (iRight < right.Length)
	{
		array[current++] = right[iRight++];
	}
	
	return inversionCount;
}

public int CountInversions_BruteForce(int[] array)
{
	if (array == null || array.Length < 2)
	{
		return 0;
	}
	
	int count = 0;
	
	for (int i = 0; i < array.Length; i++)
	{
		for (int j = i + 1; j < array.Length; j++)
		{
			if (array[i] > array[j])
			{
				count++;
			}
		}
	}
	
	return count;
}

// Define other methods and classes here