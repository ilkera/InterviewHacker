<Query Kind="Program" />

void Main()
{
	IntervalCollection col = new IntervalCollection();
	col.AddInterval(new Interval(1,4));
	col.AddInterval(new Interval(-2,3));
	col.AddInterval(new Interval(9,10));
	
	col.GetCoveredLength().Dump();
}

public class IntervalCollection
{
	private List<Interval> intervals;
	
	public IntervalCollection()
	{
		this.intervals = new List<Interval>();
	}
	
	public void AddInterval(Interval newInterval)
	{
		if (this.intervals.Count == 0)
		{
			this.intervals.Add(newInterval);
			return;
		}
		
		int currentIndex = 0;
		while (currentIndex < this.intervals.Count)
		{
			Interval currentInterval = this.intervals[currentIndex];
			
			if (this.IsOverlap(currentInterval, newInterval))
			{
				newInterval = Merge(currentInterval, newInterval);
				this.intervals.RemoveAt(currentIndex);
			}
			else if(this.IsSmaller(newInterval, currentInterval))
			{
				Interval temp = currentInterval;
				this.intervals[currentIndex] = newInterval;
				newInterval = temp;
			}
			currentIndex++;
		}
		
		this.intervals.Add(newInterval);
	}
	
	public int GetCoveredLength()
	{
		int length = 0;
		
		for (int i = 0; i < this.intervals.Count; i++)
		{
			length += this.intervals[i].End - this.intervals[i].Start;
		}
		
		return length;
	}
	
	private bool IsOverlap(Interval a, Interval b)
	{
		return !this.IsGreater(a,b) && !this.IsSmaller(a,b);
	}
	
	private bool IsGreater(Interval a, Interval b)
	{
		return a.Start > b.End;
	}
	
	private bool IsSmaller(Interval a, Interval b)
	{
		return a.End < b.Start;
	}
	
	private Interval Merge(Interval a, Interval b)
	{
		return new Interval(Math.Min(a.Start, b.Start), Math.Max(a.End, b.End));
	}
}

public class Interval
{
	public int Start { get; set; }
	public int End { get; set; }
	
	public Interval(int start, int end)
	{
		if (start > end)
		{
			throw new ArgumentException("invalid argument");
		}
		
		this.Start = start;
		this.End = end;
	}
}

// Define other methods and classes here
