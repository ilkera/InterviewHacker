<Query Kind="Program" />

void Main()
{
	NaiveDiv(5,2).Dump();
	NaiveDiv(-5, 2).Dump();
	NaiveDiv(5, -2).Dump();
	NaiveDiv(-5, -2).Dump();
	NaiveDiv(15000,2).Dump();
	
	Console.WriteLine("Optimized");
	OptimizedDiv(5,2).Dump();
	OptimizedDiv(-5, 2).Dump();
	OptimizedDiv(5, -2).Dump();
	OptimizedDiv(-5, -2).Dump();
	OptimizedDiv(15000,2).Dump();	
}

public static int NaiveDiv(int dividend, int divisor)
{
	return Div(dividend, divisor, false);
}

public static int OptimizedDiv(int dividend, int divisor)
{
	return Div(dividend, divisor, true);
}

private static int Div(int dividend, int divisor, bool optimized = true)
{
	if (divisor == 0)
	{
		throw new DivideByZeroException("divisor is zero");
	}
	
	if (dividend == 0)
	{
		return 0;
	}
	
	if (divisor == 1)
	{
		return dividend;
	}
	
	bool isNegativeDivisor = divisor < 0;
	bool isNegativeDividend = dividend < 0;
	
	if (isNegativeDivisor)
	{
		divisor *= -1;
	}
	
	if (isNegativeDividend)
	{
		dividend *= -1;
	}
	
	int quotient = 0;
	
	if (!optimized)
	{
		quotient = Naive_DivHelper(dividend, divisor);
	}
	else
	{
		quotient = Optimized_DivHelper(dividend, divisor);
	}
	
	if ((isNegativeDividend && isNegativeDivisor) || (!isNegativeDividend && !isNegativeDivisor))
	{
		return quotient;
	}
	else
	{
		return quotient * -1;
	}
}

private static int Naive_DivHelper(int dividend, int divisor)
{
	int quotient = 0;
	
	while (dividend >= divisor)
	{
		dividend -= divisor;
		quotient++;
	}
	
	return quotient;
}

public static int Optimized_DivHelper(int dividend, int divisor)
{
	int quotient = 0;
	int currentQuotientBase = 1;
	int currentDivisor = divisor;
	
	while (dividend >= divisor)
	{
		if (dividend >= currentDivisor)
		{
			dividend -= currentDivisor;
			quotient += currentQuotientBase;
			
			currentDivisor *= 2;
			currentQuotientBase *= 2;
		}
		else
		{
			currentDivisor /= 2;
			currentQuotientBase /=2;
		}
	}
	
	return quotient;
}

// Define other methods and classes here
