<Query Kind="Program" />

void Main()
{
	(AddBinary("", "") == "").Dump();
	(AddBinary(null, null) == null).Dump();
	(AddBinary("1", null) == "1").Dump();
	(AddBinary(null, "1") == "1").Dump();
	(AddBinary("", "1") == "1").Dump();
	(AddBinary("1", "") == "1").Dump();
	(AddBinary("", null) == null).Dump();
	(AddBinary(null, "") == "").Dump();
	
	(AddBinary("11", "1") == "100").Dump();
	(AddBinary("11", "11") == "110").Dump();
	(AddBinary("11", "0") == "11").Dump();
	(AddBinary("101", "101") == "1010").Dump();
}

public static string AddBinary(string first, string second)
{
	if (first == null && second == null)
	{
		return null;	
	}
	
	if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second))
	{
		return string.IsNullOrEmpty(first) ? second : first;
	}
	
	int carry = 0;
	int sum = 0;
	int iFirst =  first.Length - 1;
	int iSecond = second.Length - 1;
	StringBuilder result = new StringBuilder();
	
	while (iFirst >= 0 || iSecond >= 0)
	{
		if (iFirst >=0 & iSecond >= 0)
		{
			 sum = first[iFirst--].ToInt32() + second[iSecond--].ToInt32();
		}
		else if (iFirst >= 0)
		{
			 sum = first[iFirst--].ToInt32();
		}
		else
		{
			sum = second[iSecond--].ToInt32();
		}
		
		sum += carry;
		result.Append(sum % 2);
		carry = sum / 2;
	}
	
	if (carry > 0)
	{
		result.Append(1);
	}
	
	return result.ToString().Reverse();
}

static class CharExtensions
{
    public static int ToInt32(this char input)
    {
        return Convert.ToInt32(input.ToString());
    }
}

static class StringExtension
{
	public static string Reverse(this string input)
	{
		char[] toArray = input.ToCharArray();
		Array.Reverse(toArray);
		
		return new string(toArray);
	}
}



// Define other methods and classes here