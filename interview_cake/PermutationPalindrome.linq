<Query Kind="Program" />

void Main()
{
	IsPermutationPalindrome("civic").Dump();
	IsPermutationPalindrome("ivicc").Dump();
	IsPermutationPalindrome("civil").Dump();
	IsPermutationPalindrome("livci").Dump();
}

public static bool IsPermutationPalindrome(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		return false;
	}
	
	Dictionary<char, bool> parity_map = new Dictionary<char, bool>();
	
	foreach (char ch in str)
	{
		if (parity_map.ContainsKey(ch))
		{
			parity_map[ch] = !parity_map[ch];
		}
		else
		{
			parity_map.Add(ch, true);
		}
	}
	
	bool oddSeen = false;
	foreach (var has_odd_parity in parity_map.Values)
	{
		if (has_odd_parity)
		{
			if (oddSeen)
			{
				return false;
			}
			else
			{
				oddSeen = true;
			}
		}
	}
	
	return true;
}

// Define other methods and classes here
