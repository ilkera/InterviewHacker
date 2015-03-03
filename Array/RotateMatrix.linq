<Query Kind="Program" />

void Main()
{
	int[,] matrix = { {1,2,3}, {4,5,6}, {7,8,9}};
	matrix.Dump();
	
	Rotate(matrix, Direction.Left).Dump();
	Rotate(matrix, Direction.Right).Dump();
}

public enum Direction
{
	Left,
	Right
}

public static int[,] Rotate(int[,] matrix, Direction direction)
{
	if (matrix == null || matrix.Length < 1)
	{
		return null;
	}
	
	int rows = matrix.GetLength(0);
	int cols = matrix.GetLength(1);
	
	if (rows != cols)
	{
		throw new Exception("Not a square matrix");
	}
	
	int[,] result = new int[rows, cols];
	
	// Transpose matrix
	Transpose(matrix, result);
	
	if (direction == Direction.Left)
	{
		ReverseCols(result);
	}
	else if (direction == Direction.Right)
	{
		ReverseRows(result);
	}
	
	return result;
}

public static void ReverseRows(int[,] matrix)
{
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		int left = 0;
		int right = matrix.GetLength(1) - 1;
		
		while (left < right)
		{
			int temp = matrix[i, left];
			matrix[i, left] = matrix[i, right];
			matrix[i, right] = temp;
			left++;
			right--;
		}
	}
}

public static void ReverseCols(int[,] matrix)
{
	for (int i = 0; i < matrix.GetLength(1); i++)
	{
		int left = 0;
		int right = matrix.GetLength(0) - 1;
		
		while (left < right)
		{
			int temp = matrix[left, i];
			matrix[left, i] = matrix[right, i];
			matrix[right, i] = temp;
			left++;
			right--;
		}
	}
}

public static void Transpose(int[,] original, int[,] output)
{
	for (int i = 0; i < original.GetLength(0); i++)
	{
		for (int j = 0; j < original.GetLength(1); j++)
		{
			output[j, i] = original[i,j];
		}
	}
}

// Define other methods and classes here
