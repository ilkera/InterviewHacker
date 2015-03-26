<Query Kind="Program">
  <Reference Relative="..\Collections\PowerCollections.dll">D:\Github\InterviewHacker\Collections\PowerCollections.dll</Reference>
  <Namespace>Wintellect.PowerCollections</Namespace>
</Query>

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
	
	List<Point> topK = Utils.FindClosestKPointsToOrigin(points, 5);
	
	topK.Dump();
}

public class Utils
{
	public static List<Point> FindClosestKPointsToOrigin(List<Point> points, int K)
	{
		OrderedBag<Point> queue = new OrderedBag<Point>();
		
		foreach (var point in points)
		{
			if (queue.Count < K)
			{
				queue.Add(point);
			}
			else
			{
				if (queue.Last().CompareTo(point) > 0)
				{
					queue.RemoveLast();
					queue.Add(point);
				}
			}
		}
		
		return queue.ToList();
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