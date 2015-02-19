<Query Kind="Program" />

void Main()
{
	int[,] first = new int[4,4]{ {0, -2, -7, 0}, {9, 2, -6, 2}, {-4, 1, -4, 1}, {-1, 8, 0, -2} };
	int[,] second = new int[4,5] {
	{1, 2, -1, -4, -20},
    {-8, -3, 4, 2, 1},
    {3, 8, 10, 1, 3},
    {-4, -1, 1, 7, -6}};
	
	LargestSumSubMatrix(first).Dump();
	LargestSumSubMatrix_Naive(first).Dump();
	LargestSumSubMatrix(second).Dump();
	LargestSumSubMatrix_Naive(second).Dump();
}

public static int LargestSumSubMatrix_Naive(int[,] matrix)
{
	if (matrix == null)
	{
		throw new ArgumentNullException("null matrix");
	}
	
	int maxSum = int.MinValue;
	int rows = matrix.GetLength(0);
	int cols = matrix.GetLength(1);
	
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			for (int k = i ; k < rows; k++)
			{
				for (int m = j; m < cols; m++)
				{
					int tempSum = 0;
					
					for (int p = i; p <= k; p++)
					{
						for (int q = j; q <= m; q++)
						{
							tempSum +=  matrix[p, q];
						}	
					}
					
					maxSum = Math.Max(maxSum, tempSum);
				}
			}	
		}
	}
	
	return maxSum;
}

public static int LargestSumSubMatrix(int[,] matrix)
{
	if (matrix == null)
	{
		throw new ArgumentNullException("null matrix");
	}
	
	int maxSum = int.MinValue;
	int numCols = matrix.GetLength(1);
	int numRows = matrix.GetLength(0);
	
	for (int left = 0; left < numCols; left++)
	{
		int[] tempRows = new int[numRows];
		for (int right = left; right < numCols; right++)
		{
			for (int i = 0; i < numRows; i++)
			{
				tempRows[i] += matrix[i, right];
			}
			
			int sum = LargestSum(tempRows);
			maxSum = Math.Max(sum,maxSum);
		}
	}
	
	return maxSum;
}

private static int LargestSum(int[] array)
{
	int maxSum = int.MinValue;
	int currentSum = maxSum;
	
	for (int i = 0; i < array.Length; i++)
	{
		if (currentSum < 0)
		{
			currentSum = array[i];
		}
		else
		{
			currentSum += array[i];
		}
		
		maxSum = Math.Max(currentSum, maxSum);
	}
	
	return maxSum;
}

// Define other methods and classes here
