<Query Kind="Program" />

void Main()
{
	MinEditDistance("INTENTION","EXECUTION").Dump();
	MinEditDistance("CAT","DOG").Dump();
	MinEditDistance("CAT","").Dump();
	MinEditDistance("","CAT").Dump();
}

public static int MinEditDistance(string s1, string s2)
{
	int[,] distance = new int[s1.Length + 1, s2.Length + 1];
	
	for (int i = 0; i <= s1.Length; i++)
	{
		distance[i, 0] = i;
	}
	
	for (int i = 0; i <= s2.Length; i++)
	{
		distance[0, i] = i;
	}
	
	for (int i = 1; i <= s1.Length; i++)
	{
		for (int j = 1; j <= s2.Length; j++)
		{
			int replacement =  distance[i-1, j-1] + (s1[i-1] == s2[j-1] ? 0 : 1);
			int deletion = distance[i - 1, j] + 1;
			int insertion = distance[i, j-1] + 1;
			distance[i,j] = Math.Min(deletion, Math.Min(insertion, replacement));
		}
	}
	
	return distance[s1.Length, s2.Length];
}

// Define other methods and classes here
