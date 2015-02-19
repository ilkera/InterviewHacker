<Query Kind="Program" />

void Main()
{
	LongestIncreasingSubsequence(new int[] {3, 2, 6, 4, 5, 1}).Dump();
	LongestIncreasingSubsequence(new int[] {0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15}).Dump();
	
	LongestIncreseaingSubsequence_Items(new int[] {3, 2, 6, 4, 5, 1}).Dump();
	LongestIncreseaingSubsequence_Items(new int[] {0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15}).Dump();
}

public static int LongestIncreasingSubsequence(int[] array)
{
	if (array == null || array.Length < 1)
	{	
		return 0;
	}
	
	int[] dp = new int[array.Length];
	dp[0] = 1;
	int longest = int.MinValue;
	
	for (int i = 1; i < array.Length; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if (array[i] > array[j] && dp[j] + 1 > dp[i])
			{
				dp[i] = dp[j] + 1;
				longest = Math.Max(longest, dp[i]);
			}
		}
	}
	
	return longest;
}

public static List<int> LongestIncreseaingSubsequence_Items(int[] array)
{
	if (array == null || array.Length < 1)
	{	
		return null;
	}
		
	int[] dp = new int[array.Length];
	int[] choice = new int[array.Length];
	int maxLength = int.MinValue;
	int bestEnd = 0;
	
	dp[0] = array[0];
	choice[0] = -1;
	
	for (int i = 1; i < array.Length; i++)
	{
		choice[i] = -1;
		
		for (int j = 0; j < i; j++)
		{
			if (array[i] > array[j] && dp[j] + 1 > dp[i])
			{
				dp[i] = dp[j] + 1;
				choice[i] = j;
			}
		}
		
		if (dp[i] > maxLength)
		{
			maxLength = dp[i];
			bestEnd = i;
		}
	}
	
	List<int> sequence = new List<int>();
	for (int i = bestEnd; i != -1; i = choice[i])
	{
		sequence.Add(array[i]);
	}
	sequence.Reverse();
	
	return sequence;
}


// Define other methods and classes here
