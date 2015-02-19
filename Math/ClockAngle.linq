<Query Kind="Program" />

void Main()
{
	/*
Basically:

The hour hand moves at the rate of 0.5 degrees per minute
12 hours. 360/12 = moves 30degree/hour 30/60 = 0.5 degree per minute

The minute hand moves at the rate of of 6 degrees per minute
1 hour = 60 minutes. 360/60 => 6 degree per minute

Problem solved.
	
	
	*/
	
	FindAngle(12,30).Dump();
	
}

// h = 1..12, m = 0..59
static double FindAngle(int hour, int minute)
{
	if (hour < 0 || minute < 0 || hour > 12 || minute > 60)
	{
		return double.NaN;
	}
	
    double hAngle = 0.5D * (hour * 60 + minute);
    double mAngle = 6 * minute;
    double angle = Math.Abs(hAngle - mAngle);
    angle = Math.Min(angle, 360 - angle);
    return angle;
}

// Define other methods and classes here
