<Query Kind="Program" />

void Main()
{
	FindMedian(new int[] {1, 2, 3, 5}, new int[] {4, 5, 7}).Dump();
	FindMedian(new int[] {1, 2, 3}, new int[] {4, 5, 6}).Dump();
	FindMedian(new int[] {1, 2, 3}, new int[] {}).Dump();
	FindMedian(new int[] {},new int[] {1, 2, 3}).Dump();
}

public static double FindMedian(int[] arrayA, int[] arrayB)
{
	if (arrayA == null)
	{
		return Median(arrayB);
	}
	
	if (arrayB == null)
	{
		return Median(arrayA);
	}
	
	int aLength = arrayA.Length;
	int bLength = arrayB.Length;
	
	if ((aLength + bLength) % 2 != 0) // odd case
	{
		 return FindKth(arrayA, arrayB, (aLength + bLength) / 2, 0, aLength - 1, 0, bLength - 1);
	}
	else
	{
		return (FindKth(arrayA, arrayB, (aLength + bLength) / 2, 0, aLength - 1, 0, bLength - 1) +
				FindKth(arrayA, arrayB, ((aLength + bLength) / 2) - 1, 0, aLength - 1, 0, bLength - 1)) / 2.0;
	}
}

private static double FindKth(int[] arrayA, int[] arrayB, int k, int aStart, int aEnd, int bStart, int bEnd)
{
	int aLen = aEnd - aStart + 1;
	int bLen = bEnd - bStart + 1;
	
	if (aLen == 0)
	{
		return arrayB[bStart + k];
	}
	
	if (bLen == 0)
	{
		return arrayA[aStart + k];
	}
	
	if (k == 0)
	{
		return arrayA[aStart] < arrayB[bStart] ? arrayA[aStart] : arrayB[bStart];
	}
	
	int aMid = aLen * k / (aLen + bLen);
	int bMid = k - aMid - 1;
	
	aMid = aStart + aMid;
	bMid = bStart + bMid;
	
	if (arrayA[aMid] > arrayB[bMid])
	{
		k = k - (bMid - bStart + 1);
		aEnd = aMid;
		bStart = bMid + 1;
	}
	else
	{
		k = k - (aMid - aStart + 1);
		bEnd = bMid;
		aStart = aMid + 1;
	}
	
	return FindKth(arrayA, arrayB, k, aStart, aEnd, bStart, bEnd);
}

private static double Median(int[] array)
{
	if (array == null)
	{
		return 0.0;
	}
	
	if (array.Length / 2 != 0)
	{
		return array[array.Length / 2];
	}
	else
	{
		return (array[array.Length / 2] + array[(array.Length / 2) - 1]) / 2.0;
	}
}

// Define other methods and classes here
