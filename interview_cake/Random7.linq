<Query Kind="Program" />

void Main()
{
	for (int i = 0; i < 20; i++)
	{
		rand7().Dump();
	}
}

public static int rand7()
{
	while (true)
	{
		int roll1 = rand5();
		int roll2 = rand5();
		
		int outcome = (roll1-1)* 5 + (roll2 - 1) + 1;
		
		if (outcome > 21)
		{
			continue;
		}
		
		return outcome % 7 + 1;
	}
}

static Random rnd = new Random();
static public int rand5()
{
	return rnd.Next(1, 6);
}

// Define other methods and classes here
