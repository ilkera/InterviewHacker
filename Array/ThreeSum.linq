<Query Kind="Program" />

void Main()
{
	// -1, 0, 1, 2, -1, -4) triplet to 0
	
	// a + b = -c 
	ThreeSum(new int[] {-1, 0, 1, 2, -1, -4}).Dump();
}

public List<Tuple<int, int, int>> ThreeSum(int[] array)
{
	List<Tuple<int, int, int>> result = new List<Tuple<int, int, int>>();
	
	if (array == null || array.Length < 3)
	{
		return result;
	}
	
	List<int> sorted = array.ToList();
	sorted.Sort();
	
	for (int i = 0; i < sorted.Count; i++)
	{
		if (i > 0 && sorted[i] == sorted[i-1])
		{
			continue;
		}
		
		int start = i + 1;
		int end =  array.Length - 1;
		
		while (start < end)
		{
			int searched = sorted[start] + sorted[end] + sorted[i];
			
			if (searched == 0)
			{
				result.Add(new Tuple<int, int, int>(sorted[i], sorted[start], sorted[end]));
				start++;
				end--;
			}
			else if (searched > 0)
			{
				end--;
			}
			else
			{
				start++;
			}
		}
	}
	
	return result;
}

// Define other methods and classes here
