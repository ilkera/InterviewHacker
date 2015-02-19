<Query Kind="Program" />

void Main()
{
	List<Interval> list = new List<Interval> { new Interval(1,3), new Interval(6,9)};
	
	Util.Insert(list, new Interval(2,5)).Dump();
	
	List<Interval> intervals = new List<Interval> {new Interval(1,2), new Interval(3,5), new Interval(6,7), new Interval(8,10), new Interval(12,16)};
	
	Util.Insert(intervals, new Interval(4, 9)).Dump();
}

public class Interval
{
	public int Start { get; set; }
	public int End { get; set; }
	
	public Interval(int start, int end)
	{
		this.Start = start;
		this.End = end;
	}
}

public class Util
{
	public static List<Interval> Insert(List<Interval> intervals, Interval toBeInserted)
	{
		List<Interval> result = new List<Interval>();
		
		if (intervals == null)
		{
			result.Add(toBeInserted);
			return result;
		}
		
		Interval lastMerged = toBeInserted;
		int current = 0;
		
		while (current < intervals.Count)
		{	
			if (IsSmaller(intervals[current], lastMerged))
			{
				result.Add(intervals[current]);
			}
			else if (IsGreater(intervals[current], lastMerged))
			{
				result.Add(lastMerged);
				lastMerged = intervals[current];
			}
			else
			{
				lastMerged = Merge(intervals[current], lastMerged);	
			}
			current++;
		}
		
		result.Add(lastMerged);
		
		return result;
	}
	
	private static bool IsGreater(Interval a, Interval b)
	{
		return a.Start > b.End;
	}
	
	private static bool IsSmaller(Interval a, Interval b)
	{
		return a.End < b.Start;
	}
	
	private static Interval Merge(Interval a, Interval b)
	{
		return new Interval(Math.Min(a.Start, b.Start),  Math.Max(a.End, b.End));
	}
}

// Define other methods and classes here
