<Query Kind="Program" />

void Main()
{
	IsIsomorphic("foo","app").Dump();
	IsIsomorphic("bar","foo").Dump();
	IsIsomorphic("turtle","tletur").Dump();
	IsIsomorphic("tletur","turtle").Dump();
	IsIsomorphic("ab","ca").Dump();	
	IsIsomorphic("axy","boo").Dump();	
}

public static bool IsIsomorphic(string first, string second)
{	
	if (first.Length != second.Length)
	{
		return false;
	}
	
	Dictionary<char, char> map_first = new Dictionary<char, char>();
	Dictionary<char, char> map_second = new Dictionary<char, char>();
	
	for (int i = 0; i < first.Length; i++)
	{
		if (map_first.ContainsKey(first[i]))
		{
			if (map_first[first[i]] != second[i])
			{
				return false;
			}
		}
		else
		{
			if (map_second.ContainsKey(second[i]))
			{
				return false;
			}
			
			map_first.Add(first[i], second[i]);
			map_second.Add(second[i], first[i]);
		}
	}
	
	return true;
}

// Define other methods and classes here
