<Query Kind="Program" />

void Main()
{
	IsValidParanthesis("(()[]{})").Dump();
	IsValidParanthesis("(}[]{}").Dump();
	IsValidParanthesis("()[]{").Dump();
}

public static bool IsValidParanthesis(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		return false;
	}
	
	Dictionary<char, char> paranMap = new Dictionary<char, char>();
	paranMap.Add('(', ')');
	paranMap.Add('[', ']');
	paranMap.Add('{', '}');
		
	Stack<char> openedParans = new Stack<char>();
	
	for (int i = 0; i < str.Length; i++)
	{
		char current = str[i];
		
		if (paranMap.ContainsKey(current))
		{
			openedParans.Push(current);
		}
		else if (paranMap.ContainsValue(current))
		{
			if (openedParans.Count != 0 && paranMap[openedParans.Peek()] == current)
			{
				openedParans.Pop();
			}
			else 
			{
				return false;
			}
		}
	}
	
	return openedParans.Count == 0;
}

// Define other methods and classes here
