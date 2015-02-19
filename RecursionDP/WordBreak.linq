<Query Kind="Program" />

void Main()
{
	HashSet<string> dict = new HashSet<string>();
	dict.Add("leet");
	dict.Add("code");
	dict.Add("is");
	dict.Add("great");
	
	WordBreak("leetcodeisgreat", dict).Dump();
}

public static bool WordBreak(string str, HashSet<string> dict)
{
	return WordBreakHelper(str, dict);
}

private static bool WordBreakHelper(string str, HashSet<string> dict)
{
	if (str.Length == 0)
	{
		return true;
	}
	
	for (int i = 0; i <= str.Length; i++)
	{
		string prefix = str.Substring(0, i);
		
		if (dict.Contains(prefix))
		{
			return WordBreakHelper(str.Substring(i), dict);
		}
	}
	
	return false;
}

// Define other methods and classes here