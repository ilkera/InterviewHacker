<Query Kind="Program" />

void Main()
{
	IsPalindrome("a").Dump();
	IsPalindrome("ab").Dump();
	IsPalindrome("aba").Dump();
	IsPalindrome("abba").Dump();
	IsPalindrome("aabc").Dump();
	IsPalindrome("racecar").Dump();
}

public static bool IsPalindrome(string str)
{
	if (string.IsNullOrEmpty(str) || str.Length < 2)
	{
		return true;
	}
	
	if (str[0] != str[str.Length - 1])
	{
		return false;
	}
	
	return IsPalindrome(str.Substring(1, str.Length - 2));
}

// Define other methods and classes here
