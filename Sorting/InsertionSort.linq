<Query Kind="Program" />

void Main()
{
	int[] array = {5, 6, 1, 2, 0, 8, 9, 3, 0, 7, 4};
		
	InsertionSort(array);
	
	array.Dump();
}

public static void InsertionSort(int[] array)
{
	if (array == null || array.Length < 2)
	{
		return;
	}
	
	for (int i = 1; i < array.Length; i++)
	{
		int j = i - 1;
		int key = array[i];
		
		while (j >= 0 && array[j] > key)
		{
			array[j+1] = array[j];
			j--;
		}
		
		array[j + 1] = key;
	}
}

// Define other methods and classes here
