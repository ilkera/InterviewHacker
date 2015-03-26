<Query Kind="Program" />

void Main()
{
	char[] array  = {'B', 'G', 'B', 'W', 'B', 'W', 'G', 'W', 'G'};
	array.Dump();
	
	Sort(array);
	array.Dump();
}

public static void Sort(char[] colors)
{
	if (colors == null || colors.Length < 2)
	{
		return;
	}
	
	int current = 0;
	int left = 0;
	int right = colors.Length - 1;
	
	while (current <= right)
	{
		char currentColor = colors[current];
		if (currentColor == 'B')
		{
			Swap(colors, current, left);
			left++;
			current++;
		}
		else if (currentColor == 'W')
		{
			Swap(colors, current, right);
			right--;
		}
		else if (currentColor == 'G')
		{
			current++;
		}
		else
		{
			throw new Exception("Invalid character");
		}
	}
}

private static void Swap(char[] array, int src, int dest)
{
	char temp = array[src];
	array[src] = array[dest];
	array[dest] = temp;
}

// Define other methods and classes here