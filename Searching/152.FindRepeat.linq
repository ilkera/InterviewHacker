<Query Kind="Program" />

void Main()
{
	FindRepeat(new int[] {2, 2, 4, 1, 3}).Dump();
	FindRepeat_Hashing(new int[] {2, 2, 4, 1, 3}).Dump();	
	FindRepeat_Sorting(new int[] {2, 2, 4, 1, 3}).Dump();
	FindRepeat_BruteForce(new int[] {2, 2, 4, 1, 3}).Dump();
}

// Using binary search
// O(nlogn) , O(1)
public static int FindRepeat(int[] array)
{
	if (array == null || array.Length < 1)
	{	
		throw new Exception("null array");
	}
	
	int floor = 1;
	int ceiling = array.Length - 1;
	
	while (floor < ceiling)
	{
		int mid = floor + (ceiling - floor) / 2;
		
		int lower_range_floor = floor;
		int lower_range_ceiling = mid;
		int upper_range_floor = mid + 1;
		int upper_range_ceiling = ceiling;
		
		int items_in_lower_range = 0;
		
		foreach (var item in array)
		{
			if (item >= lower_range_floor && item <= lower_range_ceiling)
			{
				items_in_lower_range++;
			}
		}
		
		int distinct_possible_integers_in_lower_range = lower_range_ceiling - lower_range_floor + 1;
		
		if (items_in_lower_range > distinct_possible_integers_in_lower_range)
		{
			floor = lower_range_floor;
			ceiling = lower_range_ceiling;
		}
		else
		{
			floor = upper_range_floor;
			ceiling = upper_range_ceiling;
		}
	}
	
	return floor;
}

// Brute force O(n^2) O(1)
public static int FindRepeat_BruteForce(int[] array)
{
	if (array == null || array.Length < 1)
	{	
		throw new Exception("null array");
	}
	
	for (int i = 0; i < array.Length - 1; i++)
	{
		for (int j =  i + 1; j < array.Length; j++)
		{
			if (array[i] == array[j])
			{
				return array[i];
			}
		}
	}
	
	throw new Exception("Not repeated");
}

// O(nlogn) O(n) or O(1) - in-place merge 
// Modifies input
public static int FindRepeat_Sorting(int[] array)
{
	if (array == null || array.Length < 1)
	{	
		throw new Exception("null array");
	}
	
	Array.Sort(array);
	int previous = array[0];
	
	for (int i = 1; i < array.Length; i++)
	{
		if (previous == array[i])
		{
			return array[i];
		}
		previous = array[i];
	}
	
	throw new Exception("no duplicate");
}

// O(n) , O(n)
public static int FindRepeat_Hashing(int[] array)
{
	if (array == null || array.Length < 1)
	{
		throw new ArgumentException("null array");
	}
	
	HashSet<int> seenNumbers = new HashSet<int>();
	
	foreach (var number in array)
	{
		if (seenNumbers.Contains(number))
		{
			return number;
		}
		seenNumbers.Add(number);
	}
	
	throw new Exception("Does not exist");
}

// Define other methods and classes here
