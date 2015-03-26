<Query Kind="Program" />

void Main()
{
	List<Interval> intervals = new List<Interval>();
	intervals.Add(new Interval(0,7));
	intervals.Add(new Interval(2,5));
	intervals.Add(new Interval(1,3));
	intervals.Add(new Interval(6,8));
	intervals.Add(new Interval(11,13));
	intervals.Add(new Interval(16,17));
	intervals.Add(new Interval(9,14));
	
	FindMaxNonOverlappingIntervals(intervals).Dump();
	
}

public class Interval
{
	public int StartTime { get; set; }
	public int EndTime { get; set; }
	
	public Interval(int start, int end)
	{
		this.StartTime = start;
		this.EndTime = end;
	}
}

public static int FindMaxNonOverlappingIntervals(List<Interval> intervals)
{
	if (intervals == null || intervals.Count < 1)
	{
		return 0;
	}
	
	// Sort Intervals by Finish time
	intervals.Sort((first, second) => first.EndTime.CompareTo(second.EndTime));
	int maxNonOverLapping = 0;
	intervals.Dump();
	
	// Take the first one 
	Interval lastTaken = intervals[0];
	maxNonOverLapping++;
	
	for (int i = 1; i < intervals.Count; i++)
	{
		// If intervals overlap, then skip that interval 
		// If not, then take it
		if (!IsOverlapping(lastTaken, intervals[i]))
		{
			maxNonOverLapping++;
			lastTaken = intervals[i];
		}
	}
	
	return maxNonOverLapping;
}

private static bool IsOverlapping(Interval first, Interval second)
{
	return first.StartTime > second.EndTime || second.StartTime > first.EndTime;
}	


// Define other methods and classes here