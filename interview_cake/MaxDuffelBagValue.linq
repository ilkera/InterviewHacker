<Query Kind="Program" />

void Main()
{
	List<Tuple<int,int>> input = new List<Tuple<int,int>>();
	input.Add(new Tuple<int,int>(2, 15));
	input.Add(new Tuple<int,int>(7, 160));
	input.Add(new Tuple<int,int>(3, 90));
	input.Add(new Tuple<int,int>(1, 30));
	input.Add(new Tuple<int,int>(0, 0));
	
	MaxDuffelBagValue(input, 20).Dump();
	
	List<Tuple<int,int>> test2 = new List<Tuple<int,int>>();
	test2.Add(new Tuple<int,int>(1, 30));
	test2.Add(new Tuple<int,int>(50, 200));
	
	MaxDuffelBagValue(test2, 100).Dump();	

	List<Tuple<int,int>> test3 = new List<Tuple<int,int>>();
	test3.Add(new Tuple<int,int>(7, 160));
	test3.Add(new Tuple<int,int>(3, 65));
	test3.Add(new Tuple<int,int>(2, 30));
	
	MaxDuffelBagValue(test3, 16).Dump();	
}

public static int MaxDuffelBagValue(List<Tuple<int,int>> cake_tuples, int capacity)
{
	int[] max_values_at_capacities = new int[capacity + 1];
	
	for (int current_capacity = 0; current_capacity < max_values_at_capacities.Length; current_capacity++)
	{
		int current_max_value = 0;
		for (int i = 0; i < cake_tuples.Count; i++)
		{
			int cake_weight = cake_tuples[i].Item1;
			int cake_value = cake_tuples[i].Item2;
			
			if (cake_weight == 0 && cake_value != 0)
			{
				// Edge case
				return int.MaxValue;
			}
			
			if (cake_weight <= current_capacity)
			{
				int max_value_using_cake = cake_value + max_values_at_capacities[current_capacity - cake_weight];
				current_max_value = Math.Max(current_max_value, max_value_using_cake);
			}
			
			max_values_at_capacities[current_capacity] = current_max_value;
		}
	}
	
	return max_values_at_capacities[capacity];
}

// Define other methods and classes here