<Query Kind="Program" />

void Main()
{
	PushZerosToRight(new int[] {1, 0, 3, 2, 1,0, 0}).Dump();
	PushZerosToRight(new int[] {1, 5, 3, 2, 1,2, 6}).Dump();
	PushZerosToRight(new int[] {0, 0, 0, 0, 0,0, 0}).Dump();
	PushZerosToRight(new int[] {1}).Dump();
	PushZerosToRight(new int[] {}).Dump();
	PushZerosToRight(new int[] {0,0,0,0,1,2,3,4}).Dump();
	PushZerosToRight(new int[] {0, 1, 3, 0, 2, 0, 4, 1, 0, 0, 2}).Dump();
	PushZerosToRight(new int[] {1, 2, 3, 0, 4}).Dump();
}

public static int PushZerosToRight(int[] array)
{
	if (array == null)
	{
		return 0;
	}
	
	int left = 0;
	for (int i = 0; i < array.Length; i++)
	{
		if (array[i] != 0)
		{
			Swap(array, i, left++);
		}
	}
	
	return left;
}

private static void Swap(int[] array, int src, int dest)
{
	int temp = array[src];
	array[src] = array[dest];
	array[dest] = temp;
}

// Define other methods and classes here