<Query Kind="Program" />

void Main()
{
	DecodeWays("1").Dump();
	DecodeWays("10").Dump();
	DecodeWays("12").Dump();
	DecodeWays("2421").Dump();
	DecodeWays("1224").Dump();
}

public static int DecodeWays(string message)
{
	if (string.IsNullOrEmpty(message))
	{
		return 0;
	}
	
	if (message.Length < 2)
	{
		return 1;
	}
	
	int[] ways = new int[message.Length];
	
	ways[0] = 1;
	for (int i = 1; i < message.Length; i++)
	{
		char current = message[i];
		if (IsValid(current))
		{
			char previous = message[i-1];
			
			if (previous == '1' || (previous == '2' && current <= '6'))
			{
				ways[i] = ways[i-1] + 1;
			}
			else
			{
				ways[i] = ways[i-1];
			}
		}
		else
		{
			ways[i] = ways[i-1];
		}
	}
	
	return ways[ways.Length -1];
}

private static bool IsValid(char ch)
{
	return ch - '0' > 0 && ch - '0' < 10;
}

// Define other methods and classes here
