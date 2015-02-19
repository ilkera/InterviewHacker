<Query Kind="Program" />

void Main()
{
	IsScramble("great", "rgeat").Dump();	
}

public static bool IsScramble(string s1, string s2)
{
	if (s1 == null && s2 == null)
	{	
		return true;
	}
	
	if (s1.Length != s2.Length)
	{
		return false;
	}
	
	if (s1 == s2)
	{
		return true;
	}
	
	bool containsAllChars = HasContainAllCharacters(s1, s2);
	
	if (!containsAllChars)
	{
		return false;
	}
	
	return IsScrambleHelper(s1, s2);
}

private static bool IsScrambleHelper(string s1, string s2)
{
	if (s1.Length != s2.Length)
	{
		return false;
	}
	
	if (s1.Length == 1 && s2.Length == 1)
	{
		return true;
	}
	
	for (int i = 0; i < s1.Length; i++)
	{
		bool result = IsScrambleHelper(s1.Substring(0, i), s2.Substring(0, i)) && 
					  IsScrambleHelper(s1.Substring(i, s1.Length - i), s2.Substring(i, s2.Length - i));
					  
		result = result || (IsScrambleHelper(s1.Substring(0, i), s2.Substring(i, s2.Length - i)) && IsScrambleHelper(s1.Substring(i, s1.Length - i), s2.Substring(0, i)));

		if (result)
		{
			return true;
		}
	}
	
	return false;
}

private static bool HasContainAllCharacters(string s1, string s2)
{
	Dictionary<char, int> charMap = new Dictionary<char, int>();
	
	foreach (var item in s1)
	{
		if (!charMap.ContainsKey(item))
		{
			charMap.Add(item, 1);
		}
		else
		{
			charMap[item] += 1;
		}
	}
	
	foreach (var item in s2)
	{
		if (!charMap.ContainsKey(item))
		{
			return false;
		}
		
		charMap[item] -= 1;
	}
	
	return charMap.All(pair => pair.Value == 0);
}

// Define other methods and classes here