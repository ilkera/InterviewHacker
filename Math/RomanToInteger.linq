<Query Kind="Program" />

void Main()
{
	ConvertRomanToInt("IX").Dump();
	ConvertRomanToInt("LXVIII").Dump();
	ConvertRomanToInt("CXLIV").Dump();
}

public static int RomanToIntMap(char ch)
{
	int result;
	
	switch(ch)
	{
		case 'I': result = 1; break;
		case 'V': result = 5; break;
		case 'X': result = 10; break;
		case 'L': result = 50; break;
		case 'C': result = 100; break;
		case 'D': result = 500; break;
		case 'M': result = 1000; break;
		
		default: result = -1; break;
	}
	
	return result;
}

public static int ConvertRomanToInt(string roman)
{
	if (string.IsNullOrEmpty(roman))
	{
		return -1;
	}
	
	int result = 0;
	
	for (int i = 0; i < roman.Length; i++)
	{
		int current = RomanToIntMap(roman[i]);
		
		if (i > 0 && current > RomanToIntMap(roman[i - 1]))
		{
			int previous = RomanToIntMap(roman[i - 1]);
			result += (current - (2 *previous));
		}
		else
		{
			result += current;
		}
	}
	
	return result;
	
}

// Define other methods and classes here
