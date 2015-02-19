<Query Kind="Program" />

void Main()
{
	int[,] matrixA = { {2, 1}, {3, 4}, {5, 6}};
	int[,] matrixB = { {1, 3, 6} , {2, 4, 5}};
	
	int[,] result = Multiply(matrixA, matrixB);
	
	result.Dump();
}

public static int[,] Multiply(int[,] a, int[,] b)
{
	if (a == null || b == null)
	{
		return null;
	}
	
	if (a.GetLength(1) != b.GetLength(0))
	{
		throw new Exception("Size doesn't match");
	}
	
	int[,] result = new int[a.GetLength(0), b.GetLength(1)];
	
	for (int i = 0; i < a.GetLength(0); i++)
	{
		for (int j = 0; j < b.GetLength(1); j++)
		{
			for (int k = 0; k < a.GetLength(1); k++)
			{
				result[i,j] += a[i,k] * b[k,j];
			}
		}
	}
	
	return result;
}

// Define other methods and classes here
