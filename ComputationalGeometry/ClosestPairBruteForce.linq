<Query Kind="Program" />

void Main()
{
	List<Point> points = new List<Point>();

	points.Add(new Point(1, 1));
	points.Add(new Point(1, 3));
	points.Add(new Point(-1, 1));
	points.Add(new Point(-1, 3));
	points.Add(new Point(1, -1));
	points.Add(new Point(3, -1));
	points.Add(new Point(-1, -1));
	points.Add(new Point(2, 2));
	points.Add(new Point(2, -1));
	points.Add(new Point(2, 0));
	points.Add(new Point(1, 2));
	
	ClosestPairUtil.FindClosestPair(points).Dump();
	
}

public class ClosestPairUtil
{
	public static List<Point> FindClosestPair(List<Point> points)
	{
		List<Point> result = new List<Point>();
		double minDistance = double.MaxValue;
		Point first = null;
		Point second = null;
		
		for (int i = 0; i < points.Count; i++)
		{
			for (int j = 0;  j < points.Count;  j++)
			{
				if (i == j)
				{
					continue;
				}
				
				double distance = points[i].GetDistance(points[j]);

				if (distance < minDistance)
				{
					minDistance = distance;
					first = points[i];
					second = points[j];
				}
			}
		}
		
		result.Add(first);
		result.Add(second);
		
		return result;
	}
		
}

public class Point
{
	public int X { get; set; }
	public int Y { get; set; }
	
	public Point(int x, int y)
	{
		this.X = x;
		this.Y = y;
	}

	public double GetDistance(Point other)
	{
		double a = Math.Pow(this.X - other.X, 2);
		double b = Math.Pow(this.Y - other.Y, 2);
		
		return Math.Sqrt(a + b);
	}
}

// Define other methods and classes here
