<Query Kind="Program" />

void Main()
{
	int[,] matrix = new int[3, 3] { {1, 1, 1}, {1, 0 , 1}, {1, 1, 0}};
	
	matrix.Dump();
	
	SetMatrixZeroes(matrix);
	
	matrix.Dump();
}

public void SetMatrixZeroes(int[,] matrix)
{
	int rows = matrix.GetLength(0);
	int cols = matrix.GetLength(1);
	
	bool firstRowZero = false;
	bool firstColZero = false;
	
	for (int i = 0; i < cols; i++)
	{
		if (matrix[0, i] == 0)
		{
			firstRowZero = true;
			break;
		}
	}
	
	for (int i = 0; i < rows; i++)
	{
		if (matrix[i, 0] == 0)
		{
			firstColZero = true;
			break;
		}
	}
	
	for (int i = 1; i < rows; i++)
	{
		for (int j = 1; j < cols; j++)
		{
			if (matrix[i,j] == 0)
			{
				matrix[0, j] = 0;
				matrix[i, 0] = 0;
			}
		}
	}
	
	for (int i = 1; i < rows; i++)
	{
		for (int j = 1; j < cols; j++)
		{
			if (matrix[0, j] == 0 || matrix[i, 0] == 0)
			{
				matrix[i,j] = 0;
			}
		}
	}
	
	if (firstColZero)
	{
		for (int i = 0; i < rows; i++)
		{
			matrix[i, 0] = 0;
		}
	}
	
	if (firstRowZero)
	{
		for (int i = 0; i < cols; i++)
		{
			matrix[0, i] = 0;
		}
	}
}

// Define other methods and classes here
