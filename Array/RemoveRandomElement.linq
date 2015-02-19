<Query Kind="Program" />

void Main()
{
	Randomizer rnd = new Randomizer();
	
	for (int i = 0; i < 50; i++)
	{
		rnd.Add(i);		
	}
	
	while (rnd.Length != 0)
	{	
		int result = rnd.RemoveRandom();
		Console.WriteLine("Removing random " + result + " Current length " + rnd.Length) ;
	}
}

public class Randomizer
{
	private Random random;
	private Dictionary<int, int> valueIndexMap;
	private List<int> values;
	private int length;
	
	public int Length
	{
		get
		{
			return this.length;
		}
	}
	
	public Randomizer()
	{
		this.valueIndexMap = new Dictionary<int, int>();
		this.values = new List<int>();
		this.length = 0;
		this.random = new Random();
	}
	
	public void Add(int value)
	{
		if (this.valueIndexMap.ContainsKey(value))
		{
			return;
		}
		
		if (length == 0 || this.values.Count == length)
		{
			this.values.Add(value);
		}
		else
		{
			this.values[length] = value;	
		}
		
		this.valueIndexMap.Add(value, length);
		length++;
	}
	
	public void Remove(int value)
	{
		if (this.valueIndexMap.ContainsKey(value))
		{
			int indexToRemove = this.valueIndexMap[value];
			this.RemoveAt(indexToRemove);	
		}
	}
	
	public int RemoveRandom()
	{
		int randomIndex = this.random.Next(0, this.length);
		int result = this.values[randomIndex];
		this.RemoveAt(randomIndex);
		return result;
	}
	
	private void RemoveAt(int index)
	{
		this.valueIndexMap.Remove(this.values[index]);
		this.values[index] = int.MaxValue;
		Swap(index, length - 1);
		--this.length;
	}
	
	private void Swap(int first, int second)
	{
		int temp = this.values[first];
		this.values[first] = this.values[second];
		this.values[second] = temp;
	}
}

// Define other methods and classes here
