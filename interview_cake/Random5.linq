<Query Kind="Program" />

void Main()
{
	for (int i = 0; i < 50; i++)
	{
		int result = rand5();
		Console.WriteLine(result);
	}
}

static public int rand5()
{
	int result = 7;
	
	while (result > 5)
	{
		result = rand7();
	}
	
	return result;
}

static Random rnd = new Random();
public static int rand7()
{
	return rnd.Next(1,8);
}

// Define other methods and classes here
