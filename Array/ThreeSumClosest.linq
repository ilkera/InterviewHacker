<Query Kind="Program" />

void Main()
{
	ThreeSumClosest(null, 3).Dump();
	ThreeSumClosest(new int[] {-1, 2, 1, -4}, 0).Dump();
	ThreeSumClosest(new int[] {-1, 2, 1, -4}, 1).Dump();
	ThreeSumClosest(new int[] {-1, 2, 1, -4}, 2).Dump();
	ThreeSumClosest(new int[] {-1, 2, 1, -4}, 3).Dump();
	ThreeSumClosest(new int[] {4, 8, 2, 0, 5, 12}, 3).Dump();
}

public static List<int> ThreeSumClosest(int[] array, int target)
{
	List<int> result = new List<int>();
	
	if (array == null || array.Length < 3)
	{
		return result;
	}
	
	List<int> sorted = array.ToList();
	sorted.Sort();
	
	int closest = int.MaxValue;
	
	for (int i = 0; i < sorted.Count; i++)
	{
		int start = i + 1;
		int end = sorted.Count - 1;
		
		while (start < end)
		{
			int current = sorted[start] + sorted[end] + sorted[i];
			
			if (Math.Abs(current - target) < closest)
			{
				closest = Math.Abs(current - target);
				
				result.Clear();
				result.Add(sorted[i]);
				result.Add(sorted[start]);
				result.Add(sorted[end]);
			}
			else if (current > target)
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
