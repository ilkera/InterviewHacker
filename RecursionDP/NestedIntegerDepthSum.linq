<Query Kind="Program" />

void Main()
{
	List<NestedInteger> values = new List<NestedInteger>();
	values.Add(new NestedInteger(new List<int>{2}));
	values.Add(new NestedInteger(new List<int>{1, 1}));
	values.Add(new NestedInteger(new List<int>{1, 1}));
	
	int sum = DepthSum(values, 1);
	
	Console.WriteLine("Depth sum " + sum);
}

public static int DepthSum(List<NestedInteger> values, int level)
{
	if (values == null || values.Count < 1)
	{
		return 0;
	}
	
	int sum = 0;
	foreach (NestedInteger element in values)
	{
		if (element.IsInteger() && element.GetInteger() != null)
		{
			sum += element.GetInteger().Value * level;
		}
		else
		{
			sum += DepthSum(element.GetList(), level + 1);
		}
	}
	
	return sum;
}

public class NestedInteger
{
	private List<int> values;
	
	public NestedInteger(List<int> values)
	{
		this.values = values;
	}
	
	public bool IsInteger()
	{
		if (this.values != null && this.values.Count == 1)
		{
			return true;
		}
		
		return false;
	}
	
	public int? GetInteger()
	{
		if (!this.IsInteger())
		{
			return null;
		}
		
		return this.values[0];
	}
	
	public List<NestedInteger> GetList()
	{
		if (this.IsInteger())
		{
			return null;
		}
		
		List<NestedInteger> result = new List<NestedInteger>();
		
		foreach (var item in this.values)
		{
			result.Add(new NestedInteger(new List<int> {item}));
		}
		
		return result;
	}
}

// Define other methods and classes here
