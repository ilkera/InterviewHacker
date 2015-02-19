<Query Kind="Program" />

void Main()
{
	ReverseWords("This is a test").Dump();
	ReverseWords("Test").Dump();
	ReverseWords("TEst haha").Dump();
	
}

public static string ReverseWords(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		return str;
	}
	
	StringBuilder reversed = new StringBuilder(str);
	
	Reverse(reversed, 0, reversed.Length - 1);
	
	int start = 0;
	
	for (int i = 0; i < reversed.Length; i++)
	{
		if (reversed[i] == ' ')
		{
			Reverse(reversed, start, i - 1);
			start = i + 1;
		}
	}
	
	Reverse(reversed, start, reversed.Length - 1);
	
	return reversed.ToString();
}

private static void Reverse(StringBuilder str, int start, int end)
{
	if (str != null && str.Length > 1)
	{
		while (start < end)
		{
			char temp = str[start];
			str[start] = str[end];
			str[end] = temp;
			start++;
			end--;
		}	
	}
}

// Define other methods and classes here
