<Query Kind="Program" />

void Main()
{
	char[,] matrix = {
  		{'A','B','C','E'},
		{'S','F','C','S'},
		{'A','D','E','E'}
	};
	
	matrix.Dump();
	
	SearchWord(matrix, "ABCCED").Dump();
	SearchWord(matrix, "SEE").Dump();
	SearchWord(matrix, "ABCB").Dump();
	
}

public static bool SearchWord(char[,] matrix, string word)
{
	if (matrix == null || string.IsNullOrEmpty(word))
	{
		return false;
	}
	
	int rows = matrix.GetLength(0);
	int cols = matrix.GetLength(1);
	
	bool[,] visited = new bool[rows, cols];
	
	for (int row = 0; row < rows; row++)
	{
		for (int col = 0; col < cols; col++)
		{
			if(!visited[row, col] && word[0] == matrix[row,col] && Search(matrix, word, 0, row, col, visited))
			{
				return true;
			}
		}
	}
	
	return false;
}

private static bool CanMove(int row, int col, int rows, int cols, bool[,] visited)
{
	return row >= 0 && row < rows && col >= 0 && col < cols && !visited[row, col];
}

private static bool Search(char[,] matrix, string word, int index, int row, int col, bool[,] visited)
{	
	visited[row, col] = true;
	++index;
	
	if (index == word.Length)
	{
		return true;
	}
	
	int rows = matrix.GetLength(0);
	int cols = matrix.GetLength(1);
	
	// Go left (row, col - 1)
	if (CanMove(row, col-1,rows,cols,visited) && 
		matrix[row, col-1] == word[index] &&
		Search(matrix, word, index, row, col - 1, visited))
	{
		return true;
	}
	
	// Go right (row, col + 1)
	if (CanMove(row, col + 1, rows, cols,visited) &&
		matrix[row, col + 1] == word[index] &&
		Search(matrix, word, index, row, col + 1, visited))
	{
		return true;
	}
	
	// Go up (row - 1, col)
	if (CanMove(row -1, col, rows, cols, visited) &&
		matrix[row - 1, col] == word[index] &&
		Search(matrix, word, index, row - 1, col, visited))
	{
		return true;
	}
	
	// Go down (row + 1, col)
	if (CanMove(row + 1, col, rows, col, visited) && 
		matrix[row + 1, col] == word[index] &&
		Search(matrix, word, index, row + 1, col, visited))
	{
		return true;
	}
	
	visited[row, col] = false;
	return false;
}



// Define other methods and classes here