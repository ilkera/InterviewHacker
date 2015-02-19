<Query Kind="Program" />

void Main()
{
	TempTracker tracker = new TempTracker(100);
	Random rnd = new Random();
	
	for (int i = 0; i < 30; i++)
	{
		int temp = rnd.Next(0, 100);
		tracker.Insert(temp);
		
		Console.WriteLine("Temp: {4} | Min: {0} | Max: {1} | Sum: {5} | Mean: {2} | Mode:{3}", tracker.Min, tracker.Max, tracker.Mean, tracker.Mode, temp, tracker.Sum);
	}
	
}

public class TempTracker
{
	private int Count { get; set; }
	private int MaxTemp { get; set; }
	private int[] Occurences;
	private int MaxOccurrenceCount;
	
	public int Max { get; private set; }
	public int Min { get; private set; }
	public float Mean { get; private set; }
	public int Mode { get; private set; }
	public int Sum { get; set; }
	
	public TempTracker(int maxTemp)
	{
		this.MaxTemp = maxTemp;
		this.Occurences = new int[this.MaxTemp + 1];
		this.Max = int.MinValue;
		this.Min = int.MaxValue;
	}
	
	public void Insert(int temp)
	{
		if (temp > this.MaxTemp || temp < 0)
		{
			throw new Exception("invalid data");
		}
				
		if (this.Max < temp)
		{
			this.Max = temp;
		}
		
		if (this.Min > temp)
		{
			this.Min = temp;
		}
		
		this.Count += 1;
		this.Sum += temp;
		this.Mean = this.Sum / this.Count;
			
		this.Occurences[temp]+= 1;
		
		if (this.Occurences[temp] > this.MaxOccurrenceCount)
		{
			this.MaxOccurrenceCount = this.Occurences[temp];
			this.Mode = temp;
		}		
	}
	
	
}

// Define other methods and classes here
