<Query Kind="Program" />

void Main()
{
	CalculateExpression(new List<string> {"4", "1", "+", "2.5", "*"}).Dump();
	CalculateExpression(new List<string> {"5", "80", "40", "/", "+"}).Dump();
}

public static double CalculateExpression(List<string> ops)
{
	if (ops == null || ops.Count < 1)
	{
		return 0;
	}
	
	Stack<double> numbers = new Stack<double>();
	foreach (var current in ops)
	{
		double number;
		if (double.TryParse(current, out number))
		{
			numbers.Push(number);
		}
		else if (IsOperator(current))
		{
			if (numbers.Count < 2)
			{
				throw new FormatException("illegal input");
			}
			
			double second = numbers.Pop();
			double first = numbers.Pop();
			
			numbers.Push(Calculate(first, second, current));
		}
		else
		{
			throw new FormatException("invalid data");
		}
	}
	
	if (numbers.Count == 1)
	{
		return numbers.Pop();
	}
	
	throw new FormatException("invalid format");
}

public static double Calculate(double first, double second, string op)
{
	if (op == "+")
	{
		return first + second;
	}
	else if (op == "*")
	{
		return first * second;
	}
	else if (op == "/")
	{
		if (second == 0)
		{
			throw new DivideByZeroException();
		}
		
		return first / second;
	}
	
	else if (op == "-")
	{
		return first - second;
	}
	else
	{
		throw new FormatException("illegal operator");
	}
}

public static bool IsOperator(string op)
{
	return (op != null && (op == "+" || op == "-" || op == "*" || op == "/"));
}

// Define other methods and classes here
