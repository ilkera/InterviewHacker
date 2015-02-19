<Query Kind="Program" />

void Main()
{
	GetPermutations("abc").Dump();
}

public static List<string> GetPermutations(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		return new List<string>(); // return empty
	}
	
	return PermutationsHelper(str);
}

private static List<string> PermutationsHelper(string str)
{
	if (str.Length <= 1)
	{
		return new List<string>() { str };
	}
	
	List<string> permutations = new List<string>();
	char lastChar = str[str.Length - 1];
	string all_chars_except_last = str.Substring(0, str.Length - 1);
	List<string> permutations_except_last = PermutationsHelper(all_chars_except_last);
	
	foreach (var permutation_except_last in permutations_except_last)
	{
		for (int position = 0; position <= all_chars_except_last.Length; position++)
		{
			string permutation = permutation_except_last.Insert(position, lastChar.ToString()); 
			permutations.Add(permutation);
		}
	}
	
	return permutations;
}

// Define other methods and classes here
