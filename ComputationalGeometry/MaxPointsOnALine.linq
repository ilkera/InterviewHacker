<Query Kind="Program" />

void Main()
{
	List<Point> points = new List<Point>();
	points.Add(new Point(1, 3));
	points.Add(new Point(2, 4));
	points.Add(new Point(3, 0));
	points.Add(new Point(2, 0));
	points.Add(new Point(0, 1));
	points.Add(new Point(1, 1));
	points.Add(new Point(3, 0));
	points.Add(new Point(0,0));
	points.Add(new Point(0,1));
	points.Add(new Point(0,0));
	
	FindMaxPointsOnALine(points).Dump();
}

public class Point
{
	public double X { get; set; }
	public double Y { get; set; }
	
	public Point(double x, double y)
	{
		this.X = x;
		this.Y = y;
	}
}

public class Utils
{
	public static double FindSlope(Point p1, Point p2)
	{
		if (p2.X - p1.X == 0)
		{
			return int.MaxValue;
		}
		else
		{
			return (p2.Y - p1.Y) / (p2.X - p1.X);
		}
	}
}

public static int FindMaxPointsOnALine(List<Point> points)
{
	int result = 0;
	Dictionary<double, int> slopeMap = new Dictionary<double, int>();
	
	foreach (Point a in points)
	{
		int max = 0;
		int duplicate = 0;
		slopeMap.Clear();
		
		foreach (Point b in points)
		{
			if (a.X == b.X && a.Y == b.Y)
			{
				duplicate++;
			}
			else
			{
				double slope = Utils.FindSlope(a, b);
				if (slopeMap.ContainsKey(slope))
				{
					slopeMap[slope] += 1;
				}
				else
				{
					slopeMap.Add(slope, 1);
				}
				
				max = Math.Max(max, slopeMap[slope]);
			}
		}
		
		result = Math.Max(result, max + duplicate);
	}
	
	return result;
}

// Define other methods and classes here
