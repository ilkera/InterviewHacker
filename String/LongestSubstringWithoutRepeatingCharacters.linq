<Query Kind="Program" />

void Main()
{
	GetLengthOfLongestSubstring("abcabcbb").Dump();
	GetLengthOfLongestSubstring("abcd").Dump();
	GetLengthOfLongestSubstring("bbbbbbbbbb").Dump();
}

public static int GetLengthOfLongestSubstring(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		return 0;
	}
	
	if (str.Length == 1)
	{
		return 1;
	}
	
	Dictionary<char, int> charMap = new Dictionary<char, int>();
	int currentLength = 0;
	int maxLength = 0;
	
	for (int i = 0; i < str.Length; i++)
	{	
		if (!charMap.ContainsKey(str[i]))
		{
			charMap.Add(str[i], i);
			currentLength++;
		}
		else
		{
			maxLength = Math.Max(maxLength, currentLength);
			currentLength = 0;
			i = charMap[str[i]] + 1;
			charMap.Clear();
		}
	}
	
	return Math.Max(currentLength, maxLength);
}

// Define other methods and classes here
