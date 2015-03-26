<Query Kind="Program" />

void Main()
{
	JustifyText(new string[] {"This", "is", "an", "example", "of", "text", "justification"}).Dump();
}

public static int L = 16;

public static List<string> JustifyText(string[] words)
{
	int currLineLength = 0;
	int currLineWords = 0;
	int currLineStart = 0;
	
	List<string> result = new List<string>();
	
	for (int i = 0; i < words.Length; i++)
	{
		++currLineWords;
		
		int lookAheadCurrLineLength = currLineLength + words[i].Length + (currLineWords - 1);
		
		if (lookAheadCurrLineLength == L)
		{
			result.Add(ConstructLineWithSpaces(words, currLineStart, i, i - currLineStart));
			currLineLength = 0;
			currLineStart = i + 1;
			currLineWords = 0;
		}
		else if (lookAheadCurrLineLength > L)
		{
			result.Add(ConstructLineWithSpaces(words, currLineStart, i - 1, L - currLineLength));
			currLineLength = words[i].Length;
			currLineWords = 1;
			currLineStart = i;
		}
		else
		{
			currLineLength += words[i].Length;
		}
	}
	
	if (currLineWords > 0)
	{
		StringBuilder lastLine = new StringBuilder(ConstructLineWithSpaces(words, currLineStart, words.Length - 1, currLineWords - 1));
		
		for (int i = 0; i < L - currLineLength; i++)
		{
			lastLine.Append("_");
		}
		
		result.Add(lastLine.ToString());
	}
	
	return result;
}

private static string ConstructLineWithSpaces(string[] words, int start, int end, int numSpaces)
{
	int numWordsCurrLine = end - start + 1;
	
	StringBuilder line = new StringBuilder();
	
	for (int i = start; i < end; i++)
	{
		line.Append(words[i]);
		--numWordsCurrLine;
		
		int numCurrSpace = (int)Math.Ceiling((double) numSpaces / numWordsCurrLine);
		
		for (int j = 0; j < numCurrSpace; j++)
		{
			line.Append("_");
		}
		
		numSpaces -= numCurrSpace;
	}
	
	line.Append(words[end]);	
	return line.ToString();
}

// Define other methods and classes here