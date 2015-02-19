<Query Kind="Program" />

void Main()
{
	LengthOfLastWord("This is a text").Dump();	
	LengthOfLastWord("text").Dump();	
	LengthOfLastWord("        text").Dump();
	LengthOfLastWord("        text    ").Dump();
	LengthOfLastWord("text     ").Dump();
	LengthOfLastWord("        ").Dump();
}

public static int LengthOfLastWord(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		return 0;
	}
	
	int left = 0;
	
	while (left < str.Length && str[left] == ' ')
	{
		left++;
	}
	
	if (left == str.Length)
	{
		return 0;
	}
	
	int right = str.Length - 1;
	
	while (right >= 0 && str[right] == ' ')
	{
		right--;
	}
	
	int start = left;
	
	while (left < right)
	{
		if (str[left] == ' ')
		{
			start = left + 1;
		}
		left++;
	}
	
	return right - start + 1;
}

// Define other methods and classes here
