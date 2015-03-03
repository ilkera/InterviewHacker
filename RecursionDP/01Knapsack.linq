<Query Kind="Program" />

void Main()
{
	List<BagItem> items = new List<BagItem>();
/*
	items.Add(new BagItem(175, 10));
	items.Add(new BagItem(90, 9));
	items.Add(new BagItem(20, 4));
	items.Add(new BagItem(50, 2));
	items.Add(new BagItem(10, 1));
	items.Add(new BagItem(200, 20));
	
	ChooseBest_Recursive(items, 20).Dump();
	
	ChooseBest(items, 20).Dump();
	
	*/
	
	items.Add(new BagItem(175, 2));
	items.Add(new BagItem(90, 4));
	items.Add(new BagItem(20, 1));
	items.Add(new BagItem(50, 3));
	items.Add(new BagItem(10, 1));
	items.Add(new BagItem(200, 2));
	
	ChooseBest(items, 7).Dump();
}

public static int ChooseBest(List<BagItem> items, int maxCapacity)
{
	if (items == null || items.Count < 1)
	{
		return 0;
	}
	
	int[,] table = new int[maxCapacity + 1, items.Count + 1];
	
	for (int item = 1; item < table.GetLength(1); item++)
	{
		for (int weight = 1; weight < table.GetLength(0); weight++)
		{
			BagItem current = items[item - 1];
			
			if (current.Weight > weight)
			{
				table[weight, item] = table[weight, item - 1];
			}
			else
			{
				table[weight, item] = Math.Max(
										table[weight - current.Weight, 
										item-1] + current.Value, table[weight, item-1]);
			}
		}
	}
	
	table.Dump();

	return table[maxCapacity, items.Count];
}

public class Bag
{
	public int Capacity { get; set; }
	public int TotalValue { get; set; }
	public int TotalWeight { get; set; }
	public List<BagItem> Items { get; set; }
	
	public Bag(int capacity)
	{
		this.Capacity = capacity;
		this.Items = new List<BagItem>();
	}
}

public class BagItem
{
	public int Value { get; set; }
	public int Weight { get; set; }
	
	public BagItem(int value, int weight)
	{
		this.Value = value;
		this.Weight= weight;
	}
}

public static Bag ChooseBest_Recursive(List<BagItem> items, int totalWeight)
{
	if (items == null || items.Count < 1 || totalWeight <= 0)
	{
		return new Bag(totalWeight);
	}
	
	return ChooseBestHelper(items, totalWeight);
}

private static Bag ChooseBestHelper(
List<BagItem> items, 
int totalWeight)
{
	if (items.Count == 0 || totalWeight <= 0)
	{
		return new Bag(0);
	}
	
	BagItem first = items[0];
	
	// Without taking the first
	Bag remaining_without_current = ChooseBestHelper(items.Skip(1).ToList(), totalWeight);
	
	// With taking the first
	Bag remaining_with_current = ChooseBestHelper(items.Skip(1).ToList(), totalWeight - first.Weight);
	remaining_with_current.Items.Add(first);
	remaining_with_current.TotalValue += first.Value;
	
	Bag result;
	
	if (first.Weight <= totalWeight && remaining_with_current.TotalValue > remaining_without_current.TotalValue)
	{
		result = remaining_with_current;
	}
	else
	{
		result = remaining_without_current;
	}
	
	return result;
}

// Define other methods and classes here