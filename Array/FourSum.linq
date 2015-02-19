<Query Kind="Program" />

void Main()
{
	Find4Sum(new int[] {1, 0, -1, 0, -2, 2}, 0).Dump();
	Find4Sum(new int[] {1, 0, -1, 0, -2, 2}, 3).Dump();
}

public static List<List<int>> Find4Sum(int[] array, int target)
{
	List<List<int>> result = new List<List<int>>();
	
	if (array == null || array.Length < 4)
	{
		return result;
	}
	
	HashSet<List<int>> hashSet = new HashSet<List<int>>();
	List<int> sorted = array.ToList();
	sorted.Sort();
	
	for (int i = 0; i < sorted.Count; i++)
	{
		for (int j = i + 1; j < sorted.Count; j++)
		{
			int start = j + 1;
			int end = sorted.Count - 1;
			
			while (start < end)
			{
				int currentSum = sorted[i] + sorted[j] + sorted[start] + sorted[end];
				
				if (currentSum == target)
				{
				 	List<int> temp = new List<int>();
					temp.Add(sorted[i]);
					temp.Add(sorted[j]);
					temp.Add(sorted[start]);
					temp.Add(sorted[end]);
					
					if (!hashSet.Contains(temp))
					{
						result.Add(temp);
					}
					
					start++;
					end--;
				}
				else if (currentSum > target)
				{
					end--;
				}
				else
				{
					start++;
				}
			}
		}
	}
	
	return result;
}