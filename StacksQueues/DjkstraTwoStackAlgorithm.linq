<Query Kind="Program" />

void Main()
{
	Evaluate("( 1 + ( ( 2 + 3 ) * (4 * 5) ) )").Dump();
}

public static int Evaluate(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		throw new ArgumentException("invalid input");
	}
	
	Stack<int> values = new Stack<int>();
	Stack<char> ops = new Stack<char>();
	
	for (int i = 0; i < str.Length; i++)
	{
		char current = str[i];
		
		if (char.IsDigit(current))
		{
			values.Push(current - '0');
		}
		else if (current == '+' || current == '*')
		{
			ops.Push(current);
		}
		else if (current == ')')
		{
			if (values.Count < 2)
			{
				throw new Exception("less than 2 items in the value stack");
			}
			
			char top_operator = ops.Pop();
			
			if (top_operator == '*')
			{
				values.Push(values.Pop() * values.Pop());
			}
			else if (top_operator == '+')
			{
				values.Push(values.Pop() + values.Pop());
			}
		}
	}
	
	if (values.Count == 1)
	{
		return values.Pop();
	}
	
	throw new Exception("Invalid program");
	
}

// Define other methods and classes here
