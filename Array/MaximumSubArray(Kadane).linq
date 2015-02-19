<Query Kind="Program" />

void Main()
{
	int[] array = {-1, -2, 3, 4, -5, 6};
	
	MaxResult max = MaximumSubArray(array);
	
	max.Dump();
}

public static MaxResult MaximumSubArray(int[] array)
{
	if (array == null || array.Length < 1)
	{
		throw new ArgumentNullException("empty/null array");
	}
	
	MaxResult maxSoFar = new MaxResult(int.MinValue, -1, -1);
	MaxResult currentMax = maxSoFar;
	
	for (int i = 0; i < array.Length; i++)
	{
		if (currentMax.Value < 0)
		{
			currentMax.Value = array[i];
			currentMax.StartIndex = i;
			currentMax.EndIndex = i;
		}
		else
		{
			currentMax.Value += array[i];
			currentMax.EndIndex = i;
		}
		
		if (currentMax.Value > maxSoFar.Value)
		{
			maxSoFar = currentMax;
		}
	}
	
	return maxSoFar;
}

public struct MaxResult
{
	public int Value;
	public int StartIndex;
	public int EndIndex;
	
	public MaxResult(int value, int start, int end)
	{
		this.Value = value;
		this.StartIndex = start;
		this.EndIndex = end;
	}
}

// Define other methods and classes here
