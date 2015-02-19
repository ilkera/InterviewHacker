<Query Kind="Program" />

void Main()
{
	Shuffle(new int[]{1, 2, 3, 4 ,5});
}

public static void Shuffle(int[] array)
{
	if (array == null || array.Length < 2)
	{
		return;
	}
	
	Random rnd = new Random();
	
	for (int i = 0; i < array.Length; i++)
	{
		int rndIndex = rnd.Next(0, i + 1);
		Swap(array, i, rndIndex);
	}
}

private static void Swap(int[] array, int src, int dest)
{
	int temp = array[src];
	array[src] = array[dest];
	array[dest] = temp;
}

// Define other methods and classes here
