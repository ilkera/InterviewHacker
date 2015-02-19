<Query Kind="Program" />

void Main()
{
	for (int i = 1; i < 10; i++)
	{
		CountAndSay(i).Dump();
	}
}

public static string CountAndSay(int n)
{
	if (n < 1)
	{
		throw new Exception("Invalid number");
	}
	
	int current = 1;
	StringBuilder result = new StringBuilder("1");
	
	while (current < n)
	{
		result = CountAndGenerate(result.ToString());
		current++;
	}
	
	return result.ToString();
}

private static StringBuilder CountAndGenerate(string str)
{
	StringBuilder output = new StringBuilder();
	int currentIndex = 1;
	int count = 1;
	
	while (currentIndex < str.Length)
	{
		if (str[currentIndex - 1] == str[currentIndex])
		{
			count++;
		}
		else
		{
			output.Append(count);
			output.Append(str[currentIndex-1].ToString());
			count = 1;
		}
		
		currentIndex++;
	}
	
	output.Append(count);
	output.Append(str[str.Length -1].ToString());
	
	return output;
}

// Define other methods and classes here
