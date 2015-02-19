<Query Kind="Program" />

void Main()
{
	List<Point> points = new List<Point>();
	
	Point origin = new Point(0, 0);
	points.Add(new Point(1, 1, origin));
	points.Add(new Point(1, 3, origin));
	points.Add(new Point(-1, 1, origin));
	points.Add(new Point(-1, 3, origin));
	points.Add(new Point(1, -1, origin));
	points.Add(new Point(3, -1, origin));
	points.Add(new Point(-1, -1, origin));
	points.Add(new Point(-1, 3, origin));
	points.Add(new Point(2, 2, origin));
	points.Add(new Point(2, -1, origin));
	points.Add(new Point(2, 0, origin));
	points.Add(new Point(1, 2, origin));
	
	ClosestPoint.FindClosestPoints(points, 5).Dump();
}

public class ClosestPoint
{
	public static List<Point> FindClosestPoints(List<Point> points, int K)
	{
		List<Point> result = new List<Point>();
		
		if (points != null && points.Count > 0)
		{
			FindTopKClosestPoints(points, K, result);
		}
		
		return result;
	}
	
	private static void FindTopKClosestPoints(List<Point> points, int k, List<Point> result)
	{
		int left = 0;
		int right = points.Count - 1;
		int pivotIndex = Partition(points, left, right);
		
		while (pivotIndex + 1 != k)
		{
			if (pivotIndex + 1 > k)
			{
				right = pivotIndex - 1;
			}
			else
			{	
				left = pivotIndex + 1;
			}
			
			pivotIndex = Partition(points, left, right);
		}
		
		for (int i = left; i <= pivotIndex; i++)
		{
			result.Add(points[i]);
		}
	}
	
	private static int Partition(List<Point> points, int left, int right)
	{
		Point pivot = points[right];
		int pivotIndex = left;
		
		for (int i = left; i < right; i++)
		{
			if (!IsGreater(points[i], pivot))
			{
				Swap(points, i, pivotIndex++);
			}
		}
		
		Swap(points, right, pivotIndex);
		
		return pivotIndex;
	}
	
	private static void Swap(List<Point> points, int source, int dest)
	{
		Point temp = points[source];
		points[source] = points[dest];
		points[dest] = temp;
	}
	
	private static bool IsGreater(Point a, Point b)
	{
		return a.Distance > b.Distance;
	}
}


public class Point : IComparable<Point>
{
	public int X { get; set; }
	public int Y { get; set; }
	public double Distance { get; set; }
	
	public Point(int x, int y, Point origin)
	{
		this.X = x;
		this.Y = y;
		this.Distance = this.FindDistanceTo(origin);
	}
	
	public Point(int x, int y)
	{
		this.X = x;
		this.Y = y;
	}
	
	public double FindDistance(Point other)
	{
		return this.FindDistanceTo(other);
	}
	
	private double FindDistanceTo(Point origin)
	{
		double a = Math.Pow(this.X - origin.X, 2);
		double b = Math.Pow(this.Y - origin.Y, 2);
		return Math.Sqrt(a + b);
	}
	
	public int CompareTo(Point other)
	{
		return this.Distance.CompareTo(other.Distance);
	}
}

// Define other methods and classes here
