<Query Kind="Program">
  <Reference Relative="..\Collections\PowerCollections.dll">D:\Github\coding_interviews\Collections\PowerCollections.dll</Reference>
  <Namespace>Wintellect.PowerCollections</Namespace>
</Query>

void Main()
{
	MedianOfStream m = new MedianOfStream();
	
	Random rnd = new Random();
	
	for (int i = 0; i < 10; i++)
	{
		int randomValue = rnd.Next(0, 50);
		m.Insert(randomValue);
		Console.WriteLine("Inserted item " + randomValue + " Current Median " + m.GetMedian());
	}
}

public class MedianOfStream
{
	private OrderedBag<int> minHeap;
	private OrderedBag<int> maxHeap;
	private int count;
	
	public MedianOfStream()
	{
		this.minHeap = new OrderedBag<int>();
		this.maxHeap = new OrderedBag<int>();
		this.count = 0;
	}
	
	public void Insert(int item)
	{		
		if (this.count % 2 == 0)
		{
			this.maxHeap.Add(item);
			this.count++;
			
			if (this.minHeap.Count != 0 && this.maxHeap.Max() > this.minHeap.Min())
			{
				int toMin = this.maxHeap.RemoveLast();
				int toMax = this.minHeap.RemoveFirst();
				this.maxHeap.Add(toMax);
				this.minHeap.Add(toMin);
			}
		}
		else
		{
			this.maxHeap.Add(item);
			this.count++;
			this.minHeap.Add(this.maxHeap.RemoveLast());
		}
	}
	
	public double GetMedian()
	{
		if (this.count > 0)
		{
			if (this.count % 2 == 0)
			{
				return (this.maxHeap.Max() + this.minHeap.Min()) / 2.0;
			}
			else
			{
				return this.maxHeap.Max();
			}
		}
		
		return 0;
	}
}

// Define other methods and classes here
