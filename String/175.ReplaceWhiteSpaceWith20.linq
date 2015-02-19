<Query Kind="Program" />

void Main()
{
	ReplaceEmpty("This is a test string").Dump();	
}

public static string ReplaceEmpty(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		return str;
	}
	
	StringBuilder newStr = new StringBuilder();
	
	foreach (var ch in str)
	{
		if (ch == ' ')
		{
			newStr.Append("%20");
		}
		else
		{
			newStr.Append(ch);
		}
	}
	
	return newStr.ToString();
}

// Define other methods and classes here
