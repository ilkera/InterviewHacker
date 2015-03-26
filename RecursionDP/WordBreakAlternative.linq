<Query Kind="Program" />

void Main()
{
 	string[] dictionary = {"mobile","samsung","sam","sung","man","mango",
                           "icecream","and","go","i","like","ice","cream"};
	HashSet<string> dict = new HashSet<string>();
	
	foreach (var word in dictionary)
	{
		dict.Add(word);
	}
	
	WordBreak("ilikeicecreamandmango", dict).Dump();
}

public static HashSet<string> WordBreak(string word, HashSet<string> dict)
{
	HashSet<string> result = new HashSet<string>();
	
	if (!string.IsNullOrEmpty(word))
	{
		WordBreakHelper(0, "", word, result, dict);	
	}
	
	return result;
}

private static void WordBreakHelper(int current, string prefix, string word, HashSet<string> result, HashSet<string> dict)
{
	if (current == word.Length)
	{
		return;	
	}
	
	prefix += word[current];
	
	if (dict.Contains(prefix))
	{
		result.Add(prefix);
		
		WordBreakHelper(current + 1, "", word, result, dict);
	}
	
	WordBreakHelper(current + 1, prefix, word, result, dict);
}
// Define other methods and classes here
