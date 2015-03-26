<Query Kind="Program" />

void Main()
{
	int[] test1= {5, 6, 1, 2, 3, 4};
	int[] test2 = {1, 2, 3, 4, 5};
	int[] test3 = {2, 1};
	int[] test4 = {5,6,7,8,9,1};
	int[] test5 = {5,1, 2, 3, 4};
	
	int[] test6 = {3, 4, 7, 7, 9, 1, 2, 2};
	int[] test7 = {3, 4, 7, 7, 9, 1, 1, 2, 2};
	int[] test8 = {1, 2, 2, 3, 3, 4, 7, 7, 9};
	int[] test9 = {5, 6, 3, 4, 4};
	int[] test10 = {5, 5, 5, 5, 5};
	int[] test11 = {1,8,8,8,8};
		
	FindMinElement(test1).Dump();
	FindMinElement(test2).Dump();
	FindMinElement(test3).Dump();
	FindMinElement(test4).Dump();
	FindMinElement(test5).Dump();	
	
	Console.WriteLine("With Duplicates");
	FindMinElement(test6).Dump();
	FindMinElement(test7).Dump();
	FindMinElement(test8).Dump();
	FindMinElement(test9).Dump();
	FindMinElement(test10).Dump();
	FindMinElement(test11).Dump();
	
	FindMinElement(new int[] {8,1,8,8,8}).Dump();
	FindMinElement(new int[] {8,8,1,8,8}).Dump();
	FindMinElement(new int[] {8,8,8,8,1}).Dump();
	FindMinElement(new int[] {2, 2, 2, 2, 0, 1, 1, 2}).Dump();
	FindMinElement(new int[] {1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1}).Dump();
}

public static int FindMinElement(int[] array)
{
	int low = 0;
	int high = array.Length - 1;
	int min =  array[0];
	
	while (low < high)
	{
		int mid = low + (high - low) / 2;
		
		if (array[mid] > array[high])
		{
			min = Math.Min(min, array[high]);
			low = mid + 1;
		}
		else if (array[mid] < array[high])
		{	
			min = Math.Min(min, array[mid]);
			high = mid;
		}	
		else
		{
		 	--high;
		}
	}
	
	min = Math.Min(min, array[low]);
	min = Math.Min(min, array[high]);
	
	return min;
}

// Define other methods and classes here