<Query Kind="Program" />

void Main()
{
	int[,] matrix = {{1,2,3}, {4,5,6}, {7,8,9}};
	matrix.Dump();
	
	SpiralMatrix(matrix).Dump();
}

public static List<int> SpiralMatrix(int[,] matrix)
{
	List<int> result = new List<int>();
	
	if (matrix != null && matrix.Length > 0)
	{
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		
		bool[,] visited = new bool[rows, cols];
		int row = 0;
		int col = 0;
		int current = 0;
		int items = rows * cols - 1;
		
		result.Add(matrix[row, col]);
		visited[row, col] = true;
		
		while (current < items)
		{
			while (CanMove(matrix, row, col + 1, visited))
			{
				++col;
				result.Add(matrix[row, col]);
				visited[row, col] = true;
				++current;
			}
			
			while (CanMove(matrix, row + 1, col, visited))
			{
				++row;
				result.Add(matrix[row, col]);
				visited[row, col] = true;
				++current;
			}
			
			while (CanMove(matrix, row, col - 1, visited))
			{
				--col;
				result.Add(matrix[row, col]);
				visited[row, col] = true;
				++current;
			}
			
			while (CanMove(matrix, row - 1, col, visited))
			{
				--row;
				result.Add(matrix[row, col]);
				visited[row, col] = true;
				++current;
			}
		}
	}
	
	return result;
}

private static bool CanMove(int[,] matrix, int row, int col, bool[,] visited)
{
	return row >= 0 && 
		   row < matrix.GetLength(0) &&
		   col >= 0 && 
		   col < matrix.GetLength(1) &&
		   !visited[row, col];
}

// Define other methods and classes here
