<Query Kind="Program" />

void Main()
{
	LongestPalindrome("dabcabbaklm").Dump();
	LongestPalindrome("abacdfgdcaba").Dump();
}

public static string LongestPalindrome(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		return str;
	}
	
	string longest = string.Empty;
	for (int index = 0; index < str.Length; index++)
	{
		string odd_case_palindrome = FindPalindrome(str, index, index); 
		if (odd_case_palindrome.Length > longest.Length)
		{
			longest = odd_case_palindrome;
		}
		
		string even_case_palindrome = FindPalindrome(str, index, index + 1);
		if (even_case_palindrome.Length > longest.Length)
		{
			longest = even_case_palindrome;
		}
	}
	
	return longest;
}

private static string FindPalindrome(string str, int left, int right)
{
	while (left >= 0 && right < str.Length && str[left] == str[right])
	{
		left--;
		right++;
	}
	
	return str.Substring(left + 1, right - left - 1);
}

// Define other methods and classes here
