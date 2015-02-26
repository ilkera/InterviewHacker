<Query Kind="Program" />

void Main()
{
	Multiply("3","4").Dump();
	Multiply("242","85").Dump();
	Multiply("999","123").Dump();
	Multiply("23","185").Dump();
	Multiply("2311","1").Dump();
	Multiply("2311","0").Dump();
}

public static string Multiply(string s1, string s2)
{
	if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
	{
		throw new Exception("Invalid argument");
	}
	
	StringBuilder sb = new StringBuilder(s1.Length + s2.Length + 1);
	for (int i = 0; i < s1.Length + s2.Length + 1; i++)
	{
		sb.Append(' ');
	}
	
	for (int i = s1.Length - 1; i >= 0; i--)
	{
		int carry = 0;
		for (int j = s2.Length - 1; j >= 0; j--)
		{
			int product = MultiplyChars(s1[i], s2[j]);
			int sum = ToInt(sb[i + j + 1]) + product + carry;
			sb[i + j + 1] = ToChar(sum % 10);
			carry = sum / 10;
		}
		
		if (carry > 0)
		{
			sb[i] = ToChar(carry);
		}
	}
	
	string result = sb.ToString().Trim();
	if (result[0] == '0')
	{
		return "0";
	}
	return result;
}

private static int ToInt(char c)
{
	if (c == ' ')
	{
		return 0;
	}
	
	return (int) c - '0';
}

private static char ToChar(int number)
{
	return (char)((int) '0' + number); 
}

private static int MultiplyChars(char c1, char c2)
{
	int first = (int)c1 - '0';
	int second = (int)c2-'0';
	
	return first * second;
}

// Define other methods and classes here
