<Query Kind="Program" />

void Main()
{
	GroupAnagrams(new string[]{"cat","dog","tac","god","act"}).Dump();
}

public static List<string> GroupAnagrams(string[] words)
{
	List<string> result = new List<string>();
	
	if (words != null && words.Length > 0)
	{
		Dictionary<string, List<string>> anagramMap = new Dictionary<string, List<string>>();
		
		foreach (var word in words)
		{
			var key = word.Sort();
			
			if (!anagramMap.ContainsKey(key))
			{	
				anagramMap.Add(key, new List<string>());
			}
			anagramMap[key].Add(word);
		}
		
		foreach (KeyValuePair<string, List<string>> anagram in anagramMap)
		{
			foreach (var word in anagram.Value)
			{
				result.Add(word);
			}
		}
	}
	
	return result;
}

public static class StringExtension
{
	public static string Sort(this string str)
	{
		char[] toArray = str.ToCharArray();
		Array.Sort(toArray);
		
		return new string(toArray);
	}
}

// Define other methods and classes here
