<Query Kind="Program" />

void Main()
{
	List<BagItem> items = new List<BagItem>();
	items.Add(new BagItem(175, 10));
	items.Add(new BagItem(90, 9));
	items.Add(new BagItem(20, 4));
	items.Add(new BagItem(50, 2));
	items.Add(new BagItem(10, 1));
	items.Add(new BagItem(200, 20));
	
	ChooseBest_Recursive(items, 20).Dump();
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
	
	return ChooseBestHelper(items, totalWeight, 0);
}

private static Bag ChooseBestHelper(
List<BagItem> items, 
int totalWeight,
int currentIndex)
{
	if (totalWeight <= 0 || currentIndex == items.Count || items[currentIndex].Weight > totalWeight)
	{
		return new Bag(totalWeight);
	}
	
	BagItem first = items[currentIndex];
	
	// Without taking the first
	Bag remaining_without_current = ChooseBestHelper(items, totalWeight, currentIndex + 1);
	
	// With taking the first
	Bag remaining_with_current = ChooseBestHelper(items, totalWeight - first.Weight, currentIndex + 1);
	remaining_with_current.Items.Add(first);
	remaining_with_current.TotalValue += first.Value;
	
	Bag result;
	
	if (remaining_with_current.TotalValue > remaining_without_current.TotalValue)
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
