<Query Kind="Program" />

void Main()
{
	MaxValue_Recursive(new int[] {20, 10, 50, 5, 1 }).Dump();
	MaxValue_Recursive(new int[] {20, 50, 10, 1, 5 }).Dump();
	
	MaxValue(new int[] {20, 10, 50, 5, 1 }).Dump();
	MaxValue(new int[] {20, 50, 10, 1, 5 }).Dump();
}

/*

This is a Dynamic Programming problem. Here is the formula

MaxValueDP = { 			if n < 2, return array[n]
						Otherwise, Max(array[n] + MaxValueDP(n-2), array[n-1] + MaxValueDP(n-3))

Basically, the idea is that the solution to the problem will include either selecting the last house (n-1) or the previous (n-2).

Then, we can recursively find optimal solution comparing the subsequent items.

We can cache the maximum stolen value using a bottom-up approach. It means that values[i] where i>0 will be the maximum value can be collected
so far. 

The result will be values[n-1]

O(n) for the iterative version running time, O(n) for the space.
*/

public static int MaxValue_Recursive(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return 0;
	}
	
	return MaxValueHelper(array, array.Length - 1);
}

private static int MaxValueHelper(int[] array, int current)
{
	if (current < 0)
	{
		return 0;
	}
	
	if (current < 2)
	{
		return array[current];	
	}
	
	return Math.Max(array[current] + MaxValueHelper(array, current - 2),
				    array[current - 1] + MaxValueHelper(array, current - 3));
}

public static int MaxValue(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return 0;
	}
	
	int[] values = new int[array.Length];
	values[0] = array[0];
	values[1] = array[1];
 	
	for (int i = 2; i < array.Length; i++)
	{
		values[i] = Math.Max(array[i] + values[i-2], array[i-1] + (i < 3 ? 0 : values[i-3]));	
	}
	
	return values[values.Length - 1];
}

// Define other methods and classes here
