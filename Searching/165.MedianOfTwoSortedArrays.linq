<Query Kind="Program" />

void Main()
{
//	MedianOfTwo_Linear(null, new int[] {4}).Dump();
//	MedianOfTwo_Linear(new int[] {4}, null).Dump();
//	MedianOfTwo_Linear(new int[] {1, 2, 3}, new int[] {4, 5, 6}).Dump();
//	MedianOfTwo_Linear(new int[] {1, 2, 3}, new int[] {4, 5, 6, 7}).Dump();
//	MedianOfTwo_Linear(new int[] {12, 13}, new int[] {4, 5, 6, 7}).Dump();
	
	Console.WriteLine("Faster");
	MedianOfTwo(null, new int[] {4}).Dump();
	MedianOfTwo(new int[] {4}, null).Dump();
	MedianOfTwo(new int[] {1, 2, 3}, new int[] {4, 5, 6}).Dump();
	MedianOfTwo(new int[] {1, 2, 3}, new int[] {4, 5, 6, 7}).Dump();
	//MedianOfTwo(new int[] {12, 13}, new int[] {4, 5, 6, 7}).Dump();
}

private static void SetMedianValue(int value, int current, int target, ref int medianValue)
{
	if (current == target)
	{
		medianValue = value;
	}
}

public static double MedianOfTwo_Linear(int[] first, int[] second)
{
	if (first == null || second == null)
	{
		return first == null ? Median(second) : Median(first);
	}
	
	int total_length = first.Length + second.Length;
	int median_index = (total_length - 1) / 2;
	int median_index_plus = median_index + 1;
	int median_index_value = -1;
	int median_index_plus_value = -1;
	int current_index = 0;
	int first_index = 0;
	int second_index = 0;
	
	int current_selected_index = -1;
	int[] current_selected_array = null;
	
	while (first_index < first.Length && second_index < second.Length)
	{
		if (first[first_index] <= second[second_index])
		{	
			current_selected_index = first_index;
			current_selected_array = first;
			first_index++;
		}
		else 
		{	
			current_selected_index = second_index;
			current_selected_array = second;
			second_index++;
		}
		
		SetMedianValue(current_selected_array[current_selected_index], current_index, median_index, ref median_index_value);
		SetMedianValue(current_selected_array[current_selected_index], current_index, median_index_plus, ref median_index_plus_value);

		current_index++;
	}
	
	while (first_index < first.Length && (current_index <= median_index || current_index <= median_index_plus))
	{
		SetMedianValue(first[first_index], current_index, median_index, ref median_index_value);
		SetMedianValue(first[first_index], current_index, median_index_plus, ref median_index_plus_value);
		first_index++;
		current_index++;
	}
	
	while (second_index < second.Length && (current_index <= median_index || current_index <= median_index_plus))
	{	
		SetMedianValue(second[second_index], current_index, median_index, ref median_index_value);
		SetMedianValue(second[second_index], current_index, median_index_plus, ref median_index_plus_value);

		second_index++;
		current_index++;
	}
	
	if (total_length % 2 != 0)
	{
		return median_index_value;
	}
	else
	{
		return (median_index_value + median_index_plus_value ) / 2.0;
	}
}

public static double MedianOfTwo(int[] first, int[] second)
{
	if (first == null && second == null)
	{
		throw new Exception("invalid input");
	}
	
	if (first == null || second == null)
	{
		return first == null ? Median(second) : Median(first);
	}
		
}


public static double Median(int[] array, int start, int end)
{
	int length = end - start + 1;
			
	if (length % 2 != 0)
	{
		return array[start + (length/2)];
	}
	else
	{
		return (array[start + (length/2)] + array[start + (length/2)-1]) / 2.0;
	}
}

public static double Median(int[] array)
{
	if (array == null || array.Length < 1)
	{
		throw new Exception("empty");
	}
	
	int length = array.Length;
	
	if (length % 2 != 0)
	{
		return array[length/2];
	}
	else
	{
		return (array[length/2] + array[(length/2)-1]) / 2.0;
	}
}

// Define other methods and classes here