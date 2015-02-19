<Query Kind="Program" />

void Main()
{
	ConvertToString(123).Dump();
	ConvertToString(-123).Dump();
	
	for (int i = 0; i < 150; i++)
	{
		ConvertToString(i).Dump();	
	}
}

public static string ConvertToString(int number)
{
	bool isNegative = number < 0;
	
	if (isNegative) 
	{
		number *= -1;
	}
	
	StringBuilder result = new StringBuilder();
	
	do
	{
		int lastDigit = number % 10;
		result.Append(lastDigit);
		number /= 10;
		
	} while (number != 0);
	
	if (isNegative)
	{
		result.Append("-");
	}
	
	return result.Reverse();
}

public static class StringBuilderExtension
{
	public static string Reverse(this StringBuilder str)
	{
		if (str == null || str.Length < 1)
		{
			return string.Empty;
		}
		
		char[] toArray = str.ToString().ToCharArray();
		Array.Reverse(toArray);
		
		return new string(toArray);
	}
}

// Define other methods and classes here
