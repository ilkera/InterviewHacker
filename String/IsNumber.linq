<Query Kind="Program" />

void Main()
{
	IsNumber("123").Dump();
	IsNumber("-123").Dump();
	IsNumber("1.23").Dump();
	IsNumber("-12.3").Dump();
	IsNumber("1.2.3").Dump();
	IsNumber("+123").Dump();
	IsNumber("+-123").Dump();
	IsNumber("0.12").Dump();
	IsNumber(".12").Dump();
}

public static bool IsNumber(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		return false;
	}
	
	int index = 0;
	bool decimalPoint = false;
	bool anyNumber = false;
	
	if (str[0] == '+' || str[0] == '-')
	{
		index++;
	}
	
	while (index < str.Length)
	{
		if (str[index] == '.')
		{
			if (decimalPoint)
			{
				return false;
			}
			
			decimalPoint = true;
		}
		else if (str[index] - '0' < 0 || str[index] - '0' > 9)
		{
			return false;
		}
		else
		{
			anyNumber = true;
		}
		index++;
	}
	
	return anyNumber;
}

// Define other methods and classes here
