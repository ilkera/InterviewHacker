<Query Kind="Program" />

void Main()
{
	ReverseWords("This is a test").Dump();
}

public static string ReverseWords(string sentence)
{
	if (string.IsNullOrEmpty(sentence) || sentence.Length < 2)
	{
		return sentence;
	}
	
	StringBuilder result = new StringBuilder(sentence);
	Reverse(result, 0, result.Length - 1);
	
	int index = 0;
	int start = 0;
	
	while (index < result.Length)
	{
		if(result[index] == ' ')
		{
			Reverse(result, start, index - 1);
			start = index + 1;
		}
		index++;
	}
	
	Reverse(result, start, result.Length -1);
	
	return result.ToString();
}

private static void Reverse(StringBuilder str, int start, int end)
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
	

// Define other methods and classes here
