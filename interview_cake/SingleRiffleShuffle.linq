<Query Kind="Program" />

void Main()
{
	IsSingleRiffle(new int[] { 10}, new int[] {7}, new int[] {7}).Dump();		
	IsSingleRiffle_Recursive(new int[] { 10}, new int[] {7}, new int[] {7}).Dump();
	IsSingleRiffle_Recursive_SpaceOptimized(new int[] { 10}, 0, new int[] {7}, 0, new int[] {7}, 0).Dump();
}


public static bool IsSingleRiffle(int[] leftHalf, int[] rightHalf, int[] shuffled_deck)
{
	int leftIndex = 0;
	int rightIndex = 0;
	int leftMax = leftHalf.Length;
	int rightMax = rightHalf.Length;
	
	foreach (var card in shuffled_deck)
	{
		if (leftIndex < leftMax && card == leftHalf[leftIndex])
		{
			leftIndex++;
		}
		else if (rightIndex < rightMax && card == rightHalf[rightIndex])
		{
			rightIndex++;
		}
		else
		{
			return false;
		}
	}
	
	return true;
}

public static bool IsSingleRiffle_Recursive_SpaceOptimized(
										int[] leftHalf, 
										int leftIndex,
										int[] rightHalf,
										int rightIndex,
										int[] shuffled_deck,
										int shuffledIndex)
{
	if (shuffledIndex + 1 > shuffled_deck.Length)
	{
		return true;
	}
	
	if (leftIndex < leftHalf.Length && leftHalf[leftIndex] == shuffled_deck[shuffledIndex])
	{
		leftIndex++;
	}
	else if (rightIndex < rightHalf.Length && rightHalf[rightIndex] == shuffled_deck[shuffledIndex])
	{
		rightIndex++;
	}
	
	shuffledIndex++;
	
	return IsSingleRiffle_Recursive_SpaceOptimized(leftHalf, leftIndex, rightHalf, rightIndex ,shuffled_deck, shuffledIndex);
}
					

public static bool IsSingleRiffle_Recursive(
										int[] leftHalf,
										int[] rightHalf,
										int[] shuffled_deck)
{
	if (shuffled_deck.Length == 0)
	{
		return true;
	}
	
	if (leftHalf.Length > 0 && leftHalf[0] == shuffled_deck[0])
	{
		return IsSingleRiffle_Recursive(leftHalf.Slice(1), rightHalf, shuffled_deck.Slice(1));
	}
	
	if (rightHalf.Length > 0 && rightHalf[0] == shuffled_deck[0])
	{
		return IsSingleRiffle_Recursive(leftHalf, rightHalf.Slice(1), shuffled_deck.Slice(1));
	}
	
	return false;
}

public static class ArrayExtensions
{
	public static int[] Slice(this int[] array, int startIndex)
	{
		if (array == null || array.Length < 1)
		{
			return array;
		}
		
		int[] result = new int[array.Length - startIndex];
		for (int i = startIndex; i < array.Length; i++)
		{
			result[i] = array[i];
		}
		
		return result;
	}
}

// Define other methods and classes here
