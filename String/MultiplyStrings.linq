<Query Kind="Program" />

void Main()
{
	Multiply("12", "10").Dump();
	Multiply("43", "98").Dump();
	Multiply("120", "1000").Dump();
}

public static string Multiply(string s1, string s2)
{
	if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
	{
		return null;
	}
	
	string first = s1.Reverse();
	string second = s2.Reverse();
	
	int[] result = new int[first.Length + second.Length + 1];
	
	for (int i = 0; i < first.Length; i++)
	{
		int digit_first = Convert.ToInt32(first[i]) - '0';
		int carry = 0;
		
		for (int j = 0; j < second.Length; j++)
		{
			int digit_second = Convert.ToInt32(second[j]) - '0';
			int product = digit_first * digit_second + carry + result[i + j];
			result[i+j] = product % 10;
			carry = product / 10;
		}
		
		if (carry > 0)
		{
			result[i + second.Length] = carry;
		}
	}
	
	int end = result.Length - 1;
	while (end > 0 && result[end] == 0)
	{
		end--;
	}

	return result.SliceToString(0, end).Reverse();
}

public static class ListExtensions
{
	public static string SliceToString(this int[] source, int start, int end)
	{
		StringBuilder result = new StringBuilder();
		
		for (int i = start; i <= end; i++)
		{
			result.Append(source[i]);	
		}
		
		return result.ToString();
	}
}

public static class StringExtensions
{
	public static string Reverse(this string str)
	{
		char[] charArray = str.ToCharArray();
		Array.Reverse(charArray);
		
		return new string(charArray);
	}
}

// Define other methods and classes here