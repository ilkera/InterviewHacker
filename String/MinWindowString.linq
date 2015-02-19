<Query Kind="Program" />

void Main()
{
	MinWindowString("ADOBECODEBANC", "ABC").Dump();
	MinWindowString("ACBBACA", "ABA").Dump();
	MinWindowString("ACBADBACAD", "CD").Dump();
}

public static string MinWindowString(string source, string target)
{
	int[] needToFind = new int[256];
	int[] hasFound = new int[256];

	foreach (var element in target)
	{
		needToFind[element]++;
	}
	
	int minWindowLen = int.MaxValue;
	int count = 0;	
	int minStart = 0;
	int minEnd = 0;
	int start = 0;

	for (int i = 0; i < source.Length; i++)
	{
		if (needToFind[source[i]] == 0)
		{
			continue;
		}
		
		hasFound[source[i]]++;
		if (hasFound[source[i]] <= needToFind[source[i]])
		{
			count++;
		}
		
		if (count == target.Length)
		{
			while (needToFind[source[start]] == 0 || hasFound[source[start]] > needToFind[source[start]])
			{
				if (hasFound[source[start]] > needToFind[source[start]])
				{
					hasFound[source[start]]--;
				}
				start++;
			}
			
			int windowLen = i - start + 1;			
			if (windowLen < minWindowLen)
			{
				minStart = start;
				minEnd = i;
				minWindowLen = windowLen;
			}
		}
	}
	
	if (minWindowLen != 0)
	{
		return source.Substring(minStart, minWindowLen);
	}
	
	return null;
}

// Define other methods and classes here