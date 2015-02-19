<Query Kind="Program" />

void Main()
{
	AllPermutations("abc").Dump();
}

public static List<string> AllPermutations(string str)
{
	List<string> result = new List<string>();
	
	if (!string.IsNullOrEmpty(str))
	{
		bool[] visited = new bool[str.Length];
		GeneratePermutations(str, 0, "", visited, result);
	}
	
	return result;
}

// abc
public static void GeneratePermutations(string str, int index, string current, bool[] visited, List<string> result)
{
	if (index == str.Length)
	{
		result.Add(current);
		return;
	}
	
	for (int i = 0; i < str.Length; i++)
	{
		if (!visited[i])
		{
			visited[i] = true;
			GeneratePermutations(str, index + 1, current + str[i], visited, result);
			visited[i] = false;
		}
	}
}

// Define other methods and classes here
