<Query Kind="Program" />

void Main()
{
	for (int i = 0; i < 100; i++)
	{
		Console.WriteLine("Square root of {0} is {1:0.#}", i, Sqrt(i));	
	}
}

public static double Sqrt(double number)
{
	if (number < 0)
	{
		return double.NaN;
	}
	
	double start = 0.0;
	double end = number / 2.0 < Math.Sqrt(double.MaxValue) ? (number / 2.0) + 1.0 : Math.Sqrt(double.MaxValue);
	double precision = 0.00000000000001;
	
	while (end - start >= precision)
	{
		double mid = start + (end-start)/2.0;
		double midSquare = mid * mid;
		
		if (midSquare == number)
		{
			return mid;
		}
		else if (midSquare > number)
		{
			end = mid;
		}
		else
		{
			start = mid;
		}
	}

	return start;
}

// Define other methods and classes here