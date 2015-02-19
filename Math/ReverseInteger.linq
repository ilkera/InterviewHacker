<Query Kind="Program" />

void Main()
{
	Reverse(123).Dump();
	Reverse(-123).Dump();
	Reverse(100).Dump();
	Reverse(-100).Dump();
	Reverse(1000000003).Dump();
}

public static int Reverse(int number)
{
	int lastDigit = 0;
	int result = 0;
	bool isNegative = number < 0;
	
	if (isNegative)
	{
		number *= -1;
	}
	
	while (number > 0)
	{
		lastDigit = number % 10;
		result = result * 10 + lastDigit;
		number /= 10;
	}
	
	if (result < 0) 
	{
		return -1;
	}
	
	if (isNegative)
	{
		result *= -1;
	}

	return result;
}

// Define other methods and classes here
