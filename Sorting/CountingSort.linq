<Query Kind="Program" />

void Main()
{
	/*
	
	min = 0
	max = 4
	count = [0,0,0,0,0]
	
	item = 4
	count = [0,0,0,0,1]
	
	item = 1
	count = [0,1,0,0,1]
	
	item = 2
	count = [0,1,1,0,1]
	
	item = 3
	count = [0,1,1,1,1]
	
	item = 2
	count = [0,1,2,1,1]
	
	item = 3
	count = [0,1,2,2,1]
	
	item = 0
	count = [1,1,2,2,1]
	
	item = 1
	count = [1,2,2,2,1]
	
	
	i = 0 to 4
	  i = 0
	  count[0] = 1
	  array[0] = 0 (CHECK)
	  count[0] = 0
	  
	  i = 1
	  count[1] = 2
	  array[1] = 1 (CHECK)
	  count[1] = 1
	  array[2] = 1 (CHECK)
	  count[1] = 0
	  
	  i = 2
	  count[2] = 2
	  array[3] = 2 (CHECK)
	  count[2] = 1
	  array[4] = 2 (CHECK)
 	  count[2] = 0
	  
	  i = 3
	  count[3] = 2
	  array[5] = 3 (CHECK)
	  count[3] = 1
	  array[6] = 3 (CHECK)
	  count[3] = 0
	  
	  i = 4
	  count[4] = 1
	  array[7] = 4 (CHECK)
	  count[4] = 0
	*/
	int[] test = {4, 1, 2, 3, 2, 3, 0, 1};
	CountingSort(test, 0, 4);
	test.Dump();
}

public static void CountingSort(int[] array, int minValue, int maxValue)
{
	int[] count = new int[maxValue-minValue+1];
	
	// count
	foreach (var number in array)
	{
		count[number - minValue] += 1;
	}
	
	int current = 0;
	for (int i = minValue; i <= maxValue; i++)
	{
		while (count[i - minValue]-- > 0)
		{
			array[current++] = i;
		}
	}
}

// Define other methods and classes here
