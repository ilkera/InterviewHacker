<Query Kind="Program" />

void Main()
{
	for (int i = 0; i < 10; i++)
	{
		Console.WriteLine("Number of 1s in {0} is {1}", i, GetNumberOf1(i));
	}
}

public static int GetNumberOf1(int number)
{
	int count = 0;
	
	while (number != 0)
	{
		count++;
		number = number & (number - 1);
	}
	
	return count;
}

// Define other methods and classes here
