<Query Kind="Program" />

void Main()
{
	GenerateParanthesis(1).Dump();
	GenerateParanthesis(2).Dump();
	GenerateParanthesis(3).Dump();
}

public static List<string> GenerateParanthesis(int n)
{
	List<string> result = new List<string>();
	
	if (n <= 0)
	{
		return result;	
	}
	
	GenerateParanthesis_Helper(n, n, "", result);
	
	return result;
}

private static void GenerateParanthesis_Helper(int leftRemaining, int rightRemaining, string currentParanthesis, List<string> result)
{	
	if (leftRemaining == 0 && rightRemaining == 0)
	{
		result.Add(currentParanthesis);
		return;
	}
	
	if (leftRemaining > 0)
	{
		GenerateParanthesis_Helper(leftRemaining - 1, rightRemaining, currentParanthesis + "(", result);
		
		if (leftRemaining < rightRemaining)
		{
			GenerateParanthesis_Helper(leftRemaining, rightRemaining -1, currentParanthesis + ")", result);	
		}
	}
	else if (rightRemaining > 0)
	{
		GenerateParanthesis_Helper(leftRemaining, rightRemaining -1, currentParanthesis + ")", result);	
	}
}

// Define other methods and classes here
