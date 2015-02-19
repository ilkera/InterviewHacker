<Query Kind="Program" />

void Main()
{
	int[] array = new int[] { 1, 2, 3, 4, 5 };
	
	Shuffle(array);
	
	array.Dump();
}

public static void Shuffle(int[] array)
{
	if (array == null || array.Length < 2)
	{
		return;
	}
	
	Random rnd = new Random();
	
	for (int i = array.Length - 1; i > 1; i--)
	{
		int rndIndex = rnd.Next(0, i + 1);
		Swap(array, rndIndex, i);
	}
}

private static void Swap(int[] array, int src, int dest)
{
	int temp = array[src];
	array[src] = array[dest];
	array[dest] = temp;
}

// Define other methods and classes here
