<Query Kind="Program" />

void Main()
{
	Anagrams(new List<string>() { "abc", "cab", "cat", "bac", "tac", "bca", "act"}).Dump();	
}

public List<string> Anagrams(List<string> words, bool groupWithSorted = false)
{
	List<string> anagrams = new List<string>();
	
	if (words == null || words.Count < 1)
	{
		return anagrams;
	}
	
	if (groupWithSorted)
	{
		words.Sort();
	}
	
	Dictionary<string, List<string>> anagram_buckets = new Dictionary<string, List<string>>();
	
	foreach (var word in words)
	{
		string sorted = word.Sort();
		if(!anagram_buckets.ContainsKey(sorted))
		{
			anagram_buckets.Add(sorted, new List<string>());
		}
		anagram_buckets[sorted].Add(word);
	}
	
	foreach (KeyValuePair<string, List<string>> bucket in anagram_buckets)
	{
		foreach (var anagram in bucket.Value)
		{
			anagrams.Add(anagram);
		}
	}
	
	return anagrams;
}


static class StringExtensions
{
    public static string Sort(this string input)
    {
		char[] inputArray = input.ToCharArray();
		Array.Sort(inputArray);
        return new string(inputArray);
    }
}
// Define other methods and classes here