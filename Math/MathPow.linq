<Query Kind="Program" />

void Main()
{
	Pow(2, 3).Dump();
	Pow(2, 5).Dump();
	Pow(2, 6).Dump();
	Pow(2, 1).Dump();
	Pow(2, 0).Dump();
	Pow(1, 3).Dump();
	Pow(1, 0).Dump();
	Pow(0, 0).Dump();
	Pow(0, 1).Dump();
	Pow(250000, 1).Dump();
	Pow(1, 25000).Dump();
	Pow(2, -3).Dump();
	Pow(-2, 3).Dump();
	Pow(-2, 4).Dump();
}

public static double Pow(double baseNum, int exp)
{
	if (baseNum == 1 || exp == 0) 
	{
		return 1;
	}
	
	if (baseNum == 0)
	{
		return 0;
	}
	
	if (exp == 1)
	{
		return baseNum;
	}
	
	bool isNegativeExp = exp < 0;
	
	if (isNegativeExp)
	{
		exp = -exp;
	}
	
	double result = 1.0;
	
	while (exp != 0)
	{
		if (exp % 2 == 1)
		{
			result *= baseNum;
		}
		
		exp /= 2;
		baseNum *= baseNum;
	}
	
	if (isNegativeExp)
	{
		return 1.0 /result;
	}
	
	return result;
}

// Define other methods and classes here
