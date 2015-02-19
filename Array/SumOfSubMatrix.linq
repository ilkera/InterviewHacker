<Query Kind="Program" />

void Main()
{
	int[,] matrix = new int[4,4] { {1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16} };
	matrix.Dump();
	
	Sum(matrix, 0, 3, 0, 3).Dump();
	
	Sum(matrix, 1, 2, 1, 2).Dump();
}

public static int Sum(int[,] matrix, int sRow, int eRow, int sCol, int eCol)
{
	if (matrix == null || sRow > eRow || sCol > eCol || eRow >= matrix.GetLength(0) || eCol >= matrix.GetLength(1))
	{
		throw new Exception("invalid");
	}
	
	int sum = 0;
	
	for (int row = sRow; row <= eRow; row++)
	{
		for (int col = sCol; col <= eCol; col++)
		{
			sum += matrix[row,col];
		}
	}
	
	return sum;
}

// Define other methods and classes here
