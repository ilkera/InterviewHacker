<Query Kind="Program" />

void Main()
{
	 int [] array1 = {12, 34, 57, 61, 69, 80};
     int [] array2 = {27, 39, 48, 51, 79};
	 
	 FindMinDiference(array1, array2).Dump();
}

public static int FindMinDiference(int[] first, int [] second)
{
	if (first == null || second == null)
	{
		throw new ArgumentNullException("input array null");
	}
	
	int lenFirst = first.Length;
	int lenSecond = second.Length;
	
	int iFirst = 0;
	int iSecond = 0;
	
	int minDiff = int.MaxValue;
	
	while (iFirst < lenFirst && iSecond < lenSecond)
	{
		if (first[iFirst] == second[iSecond])
		{
			return 0;
		}
		
		int diff = Math.Abs(first[iFirst] - second[iSecond]);
		minDiff = Math.Min(minDiff, diff);
		
		if (first[iFirst] > second[iSecond])
		{
			iSecond++;
		}
		else
		{
			iFirst++;
		}
	}
	
	if (iFirst < lenFirst)
	{
		iSecond--;
		
		while (iFirst < lenFirst)
		{
			int diff = Math.Abs(first[iFirst] - second[iSecond]);
			minDiff = Math.Min(minDiff, diff);
			iFirst++;
		}
	}
	
	if (iSecond < lenSecond)
	{
		iFirst--;
		
		while (iSecond < lenSecond)
		{
			int diff = Math.Abs(first[iFirst] - second[iSecond]);
			minDiff = Math.Min(minDiff, diff);
			iSecond++;
		}
	}
	
	return minDiff;
}