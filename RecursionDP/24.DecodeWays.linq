<Query Kind="Program" />

void Main()
{
	Decoder.DecodeWays("1").Dump();
	Decoder.DecodeWays("10").Dump();
	Decoder.DecodeWays("12").Dump();
	Decoder.DecodeWays("2421").Dump();
	Decoder.DecodeWays("1224").Dump();
}

public class Decoder
{
	public static int DecodeWays(string message)
	{
		if (string.IsNullOrEmpty(message))
		{
			return 0;
		}
		
		if (message.Length == 1)
		{
			return message[0] != '0' ? 1 : 0;
		}
		
		char current = message[0];
		char next = message[1];
		
		if (current == '1' || (current == '2' && next <= '6'))
		{
			return 1 + DecodeWays(message.Substring(1));
		}
		
		return DecodeWays(message.Substring(1));
	}
}


// Define other methods and classes here