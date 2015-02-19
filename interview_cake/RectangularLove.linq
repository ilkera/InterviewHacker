<Query Kind="Program" />

void Main()
{
	Rectangle rectA = new Rectangle(10, 10, 30, 30);
	Rectangle rectB = new Rectangle(20, 20, 50, 50);
	Rectangle rectC = new Rectangle(70, 90, 90, 90);
	
	FindIntersection(rectA, rectB).Dump();
	FindIntersection(rectA, rectC).Dump();
	
}

public static void FindRangeOverlap(
			int point1,
			int length1,
			int point2,
			int length2,
			out int result_point, 
			out int result_length)
{
	int highest_starting_point = Math.Max(point1, point2);
	int lowest_end_point = Math.Min(point1 + length1, point2 + length2);
	
	if (highest_starting_point > lowest_end_point)
	{
		result_point = -1;
		result_length = -1;
		return;
	}
	
	result_point = highest_starting_point;
	result_length = lowest_end_point - highest_starting_point;
}

public static Rectangle FindIntersection(Rectangle a, Rectangle b)
{
	int x_overlap_point;
	int overlap_width;
	int y_overlap_point;
	int overlap_height;
	
	FindRangeOverlap(a.X, a.Width, b.X, b.Width, out x_overlap_point, out overlap_width);
	FindRangeOverlap(a.Y, a.Height, b.Y, b.Height, out y_overlap_point, out overlap_height);
	
	if (overlap_width == -1 || overlap_height == -1)
	{
		return null; // no intersection
	}
	
	return new Rectangle(x_overlap_point, overlap_width, y_overlap_point, overlap_height);
}

public class Rectangle
{
	public int X { get; set; }
	public int Y { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	
	public Rectangle(int x, int y, int width, int height)
	{
		this.X = x;
		this.Y = y;
		this.Width = width;
		this.Height = height;
	}
}

// Define other methods and classes here