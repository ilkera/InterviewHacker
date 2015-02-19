<Query Kind="Program" />

void Main()
{
	HashSet<string> dict = new HashSet<string>();
	dict.Add("leetcoder");
	dict.Add("leet");
	dict.Add("code");
	
	CanWordBreak("leetcode", dict).Dump();
	CanWordBreak("leet", dict).Dump();
	CanWordBreak("code", dict).Dump();
	
	CanWordBreak("leetcodee", dict).Dump();
	CanWordBreak("leetc", dict).Dump();
	CanWordBreak("testmystuff", dict).Dump();

}
public static bool CanWordBreak(string str, HashSet<string> dict)
{
	if (dict.Contains(str))
	{
		return true;
	}
	else
	{
		for (int i = 0; i < str.Length; i++)
		{
			string prefix = str.Substring(0, i);		
			if (dict.Contains(prefix))
			{		
				return CanWordBreak(str.Substring(i), dict);
			}
		}
		return false;
	}
}

// Define other methods and classes here
