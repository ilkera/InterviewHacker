<Query Kind="Program" />

void Main()
{
	IsPalindrome("RACECAR").Dump();
	IsPalindrome("RAceCar").Dump();
	IsPalindrome("abba").Dump();
	IsPalindrome("a").Dump();
	IsPalindrome("  r  a cec .., a..!!!r").Dump();
	IsPalindrome("Sue,' Tom smiles, 'Selim smote us").Dump();
	IsPalindrome("Red rum, sir, is murder").Dump();
	IsPalindrome("A man, a plan, a canal: Panama");
	IsPalindrome(",a").Dump();
	
	IsPalindrome("Programcreek is awesome").Dump();
	IsPalindrome(" ").Dump();
	IsPalindrome(".").Dump();
	IsPalindrome("ab").Dump();
	
}

public static bool IsPalindrome(string input)
{
	if (string.IsNullOrEmpty(input))
	{
		return true;
	}
	
	if (input.Length < 2)
	{
		return char.IsLetterOrDigit(input[0]);
	}
	
	string str = input.ToLower();
	int left = 0;
	int right = str.Length - 1;
	
	while (left < right)
	{
		while (left < right && !char.IsLetterOrDigit(str[left]))
		{
			left++;
		}
		
		while (left < right && !char.IsLetterOrDigit(str[right]))
		{
			right--;
		}
		
		if (str[left] != str[right])
		{
			return false;
		}
		
		left++;
		right--;
	}
	
	return true;
}

// Define other methods and classes here