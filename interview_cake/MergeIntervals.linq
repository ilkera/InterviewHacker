<Query Kind="Program" />

void Main()
{
	// [(0, 1), (3, 5), (4, 8), (10, 12), (9, 10)]
	List<Interval> intervals = new List<Interval>();
	intervals.Add(new Interval(4,8));
	intervals.Add(new Interval(3,5));
	intervals.Add(new Interval(9,10));
	intervals.Add(new Interval(10,12));
	intervals.Add(new Interval(0,1));
	
	List<Interval> test2 = new List<Interval>();
	test2.Add(new Interval(1,2));
	test2.Add(new Interval(2,3));
	
	List<Interval> test3 = new List<Interval>();
	test3.Add(new Interval(1,3));
	test3.Add(new Interval(2,4));	

	List<Interval> test4 = new List<Interval>();
	test4.Add(new Interval(1,5));
	test4.Add(new Interval(2,3));	

	Console.WriteLine("Test 4");
	Merge(test4).Dump();
	
	Console.WriteLine("Test 3");
	Merge(test3).Dump();	
	
	Console.WriteLine("Test 2");
	Merge(test2).Dump();
	
		
	Console.WriteLine("Test 5");
	//  [(1, 10), (2, 6), (3, 5), (7,9)]
	List<Interval> test5 = new List<Interval>();
	test5.Add(new Interval(1,10));
	test5.Add(new Interval(2,6));	
	test5.Add(new Interval(3,5));
	test5.Add(new Interval(7,9));	
	Merge(test5).Dump();
	
	Console.WriteLine("Main test");
	Merge(intervals).Dump();
	
}

public static List<Interval> Merge(List<Interval> intervals)
{
	List<Interval> result = new List<Interval>();
	
	if (intervals == null || intervals.Count < 1)
	{
		return result;
	}
	
	intervals.Sort(delegate(Interval a, Interval b) { return a.Start.CompareTo(b.Start); });
	Interval merged = intervals[0];
	
	for (int i = 1; i < intervals.Count; i++)
	{
		if (IsOverlap(intervals[i], merged))
		{
			merged = new Interval(
						Math.Min(merged.Start, intervals[i].Start),
						Math.Max(merged.End, intervals[i].End));
		}
		else
		{
			if (merged.Start > intervals[i].End)
			{
				result.Add(intervals[i]);
			}
			else
			{
				result.Add(merged);
				merged = intervals[i];
			}
		}
	}
	
	result.Add(merged);
	
	return result;
}

public static bool IsOverlap(Interval first, Interval second)
{
	return IsBetween(first.End, second.Start, second.End) || IsBetween(second.End, first.Start, first.End);
}

public static bool IsBetween(int value, int min, int max)
{
	return value >= min && value <= max;
}

public class Interval
{
	public int Start { get; set; }
	public int End { get; set; }
	
	public Interval(int start, int end)
	{
		if (end < start)
		{
			throw new Exception("invalid");
		}
		
		this.Start = start;
		this.End = end;
	}
}

// Define other methods and classes here
