<Query Kind="Program" />

void Main()
{
	for (int i = 2; i <= 10; i++)
	{
		PrintDecimalExpansion(1,i, false).Dump();	
	}
}

public static string PrintDecimalExpansion(int dividend, int divisor, bool showZeroes)
{
	int precision = 1000;
	int quotient = dividend / divisor;
	int remainder = dividend % divisor;
	
	Dictionary<long, long> numberToIndexMap = new Dictionary<long, long>();
	
	List<int> fractions = new List<int>();
	
	for (int i = 0; i < precision; i++)
	{
		dividend = remainder * 10;
		quotient = dividend / divisor;
		remainder = dividend % divisor;
	
		fractions.Add(quotient);

		if (remainder == 0 && !showZeroes)
		{
			break;
		}
	}
	
	return string.Join("", fractions);
}

private static int ConvertToNumber(List<int> list)
{
	int result = 0;
	
	for (int i = 0; i < list.Count; i++)
	{
		result = result * 10 + list[i];
	}
	
	return result;
}


// Define other methods and classes here
