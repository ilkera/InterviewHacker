<Query Kind="Program" />

void Main()
{
	BinominalCoefficient_Recursive(5,2).Dump();
	BinominalCoefficient_DP(5,2).Dump();
}

public int BinominalCoefficient_DP(int n, int k)
{
	int[,] dp = new int[n + 1, k + 1];
	
	for (int i = 0; i <= n; i++)
	{
		for (int j = 0; j <= k; j++)
		{
			if (i == j || i == 0 || j == 0)
			{
				dp[i,j] = 1;
			}
			else
			{
				dp[i,j] = dp[i-1,j-1] + dp[i-1,j];
			}	
		}
	}
	
	return dp[n,k];
}

public int BinominalCoefficient_Recursive(int n, int k)
{
	if (n == k || k == 0)
	{
		return 1;
	}
	
	return BinominalCoefficient_Recursive(n-1, k-1) + BinominalCoefficient_Recursive(n-1, k);
}

// Define other methods and classes here
