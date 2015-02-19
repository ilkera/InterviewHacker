<Query Kind="Program" />

void Main()
{
	GetPermutations("abc").Dump();
}

public static List<string> GetPermutations(string str)
{
	List<string> result = new List<string>();
	
	if (!string.IsNullOrEmpty(str))
	{
		bool[] visited = new bool[str.Length];
		GetPermutationsHelper(str, 0, "", visited, result);
	}
	
	return result;
}

private static void GetPermutationsHelper(string str, int step, string current, bool[] visited, List<string> result)
{
	if (step == str.Length)
	{
		result.Add(current);
		return;
	}
	
	for (int i = 0; i < str.Length; i++)
	{
		if(!visited[i])
		{
			visited[i] = true;
			GetPermutationsHelper(str, step + 1, current + str[i], visited, result);
			visited[i] = false;
		}
	}
}
// Define other methods and classes here
