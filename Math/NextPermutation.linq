<Query Kind="Program" />

void Main()
{
	NextPermutation(new int[] {1, 2, 3}).Dump();
	NextPermutation(new int[] {1, 2, 3, 4}).Dump();
	NextPermutation(new int[] {1, 3, 4, 2}).Dump();
	NextPermutation(new int[] {1, 3, 5, 2}).Dump();
	NextPermutation(new int[] {3, 2, 1}).Dump();
	NextPermutation(new int[] {3,8,2,7,6}).Dump();
}

public static int[] NextPermutation(int[] input)
{
	int[] array = input.ToArray();
	int k = -1;
	int l = -1;
	
	// Find the largest index k such that a[k+1] > a[k]. If no such index, thats the last permutation
	for (int i = array.Length -2; i >= 0; i--)
	{
		if (array[i + 1] >  array[i])
		{
			k = i;
			break;
		}
	}
	
	// no permutation if k==-1, reverse the input (for this problem)
	if (k == -1)
	{
		array.Reverse(0, array.Length - 1);
		return array;
	}

	// find the largest index l where a[l] > a[k]
	for (int i = array.Length - 1; i > k; i--)
	{
		if (array[i] > array[k])
		{
			l = i;
			break;
		}
	}
	
	// Swap l and k
	Swap(array, k, l);
	
	// Reverse elements after k to n
	array.Reverse(k+1, array.Length - 1);
	
	return array;
}

// Define other methods and classes here

private static void Swap(int[] array, int src, int dest)
{
	int temp = array[src];
	array[src] = array[dest];
	array[dest] = temp;
}

public static class ArrayExtension
{
	public static void Reverse(this int[] array, int start, int end)
	{	
		while (start < end)
		{
			int temp = array[start];
			array[start] = array[end];
			array[end] = temp;
			start++;
			end--;
		}
	}
}
