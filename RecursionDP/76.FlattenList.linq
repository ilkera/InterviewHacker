<Query Kind="Program" />

void Main()
{
	var list = new List<object>{new List<object>{1}, 2, new List<object>{new List<object>{3,4}, 5}, new List<object>{new List<object>{new List<object>{}}}, new List<object>{new List<object>{new List<object>{6}}}, 7, 8, new List<object>{}};
 	
	//list.Dump();
	
	list.Flatten().Dump();
}

public static class ListExtensions
{
	public static List<object> Flatten(this List<object> list)
	{
		List<object> result = new List<object>();
		
		foreach (var item in list)
		{
			if (item is List<object>)
			{
				result.AddRange(Flatten(item as List<object>));
			}
			else
			{
				result.Add(item);
			}
		}
		return result;
	}
}

// Define other methods and classes here
