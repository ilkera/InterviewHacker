<Query Kind="Program" />

void Main()
{
	MinWindowString("ADOBECODEBANC", "ABC").Dump();
	MinWindowString("ACBBACA", "ABA").Dump();
	MinWindowString("ACBADBACAD", "CD").Dump();
}

public static string MinWindowString(string source, string target)
{
	Dictionary<char, int> needed = new Dictionary<char, int>();
	
	for (int i = 0; i < target.Length; i++)
	{
		if (!needed.ContainsKey(target[i]))
		{
			needed.Add(target[i], 1);
		}
		else
		{
			++needed[target[i]];
		}
	}
	
	Dictionary<char, int> found = new Dictionary<char, int>();
	int min = int.MaxValue;
	int foundWindow = 0;	
	int minStart = 0;
	int minEnd = 0;
	int start = 0;

	for (int i = 0; i < source.Length; i++)
	{
		if (needed.ContainsKey(source[i]))
		{
			if (!found.ContainsKey(source[i]))
			{
				found.Add(source[i], 1);
				++foundWindow;
			}
			else
			{
				if (found[source[i]] < needed[source[i]])
				{
					++foundWindow;
				}
				++found[source[i]];
			}
		}
		
		if (foundWindow == target.Length)
		{
			char current = source[start];
			while (!found.ContainsKey(current) || found[current] > needed[current])
			{
				if (found.ContainsKey(current) && found[current] > needed[current])
				{
					--found[current];
				}
				++start;
				current = source[start];
			}
			
			int windowLength = i - start + 1;
			
			if (min > windowLength)
			{
				min = windowLength;
				minStart = start;
				minEnd = i;
			}
		}
		
	}
	
	if (min != int.MaxValue)
	{
		return source.Substring(minStart, minEnd - minStart + 1);
	}
	
	return null;
}

// Define other methods and classes here