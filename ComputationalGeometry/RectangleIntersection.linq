<Query Kind="Program" />

public struct Rectangle
{
	public int x;
	public int y;
	public int width;
	public int height;
};

void Main()
{
	Rectangle rectA;
	rectA.x = 10;
	rectA.width = 30;
	rectA.y = 10;
	rectA.height = 30;
	
	Rectangle rectB;
	rectB.x = 20;
	rectB.width = 50;
	rectB.y = 20;
	rectB.height = 50;
	
	Rectangle rectC;
	rectC.x = 70;
	rectC.width = 90;
	rectC.y = 90;
	rectC.height = 90;
	
	Util.IsRectangleOverlap(rectA, rectB).Dump();
	Util.IsRectangleOverlap(rectA, rectC).Dump();
}

public class Util
{
	public static bool IsRectangleOverlap(Rectangle a, Rectangle b)
	{
		bool xOverlap = ValueInRange(a.x, b.x, b.x + b.width) || ValueInRange(b.x, a.x, a.x + a.width);
		bool yOverlap = ValueInRange(a.y, b.y, b.y + b.height) || ValueInRange(b.y, a.y, a.y + a.height);
		
		return xOverlap && yOverlap;
	}
	
	private static bool ValueInRange(int value, int min, int max)
	{
		return value >= min && value <= max;
	}
}

// Define other methods and classes here