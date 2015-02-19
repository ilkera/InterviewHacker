<Query Kind="Program" />

void Main()
{
	MatchingParens("Sometimes (when I nest them (my parentheticals) too much (like this (and this))) they get confusing", 10).Dump();
	
}

public static int MatchingParens(string str, int opening_paren_index)
{
	if (string.IsNullOrEmpty(str))
	{
		return -1;
	}
	
	int open_paran_count = 0;
	int position = opening_paren_index + 1;
	
	for (int i = position; i < str.Length; i++)
	{
		char ch = str[i];
		
		if (ch == '(')
		{
			open_paran_count++;
		}
		else if (ch == ')')
		{
			if (open_paran_count == 0)
			{
				return position;
			}
			else
			{
				open_paran_count--;
			}
		}
		position += 1;
	}
	
	return -1;
}

// Define other methods and classes here
