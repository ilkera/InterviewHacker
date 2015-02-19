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
			if(Search(matrix, word, 0, row, col, visited))
			{
				return true;
			}
		}
	}
	
	return false;
}

private static bool Search(char[,] matrix, string word, int index, int row, int col, bool[,] visited)
{
	if (visited[row, col])
	{
		return false;
	}
	
	if (index + 1 == word.Length)
	{
		return true;
	}
	
	visited[row, col] = true;
	index++;
	
	// Go left (row, col - 1)
	if (col - 1 >= 0 && matrix[row, col-1] == word[index])
	{
		return Search(matrix, word, index, row, col - 1, visited);
	}
	
	// Go right (row, col + 1)
	if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == word[index])
	{
		return Search(matrix, word, index, row, col + 1, visited);
	}
	
	// Go up (row - 1, col)
	if (row - 1 >= 0 && matrix[row - 1, col] == word[index])
	{
		return Search(matrix, word, index, row - 1, col, visited);
	}
	
	// Go down (row + 1, col)
	if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == word[index])
	{
		return Search(matrix, word, index, row + 1, col, visited);
	}
	
	visited[row, col] = false;
	return false;
}



// Define other methods and classes here
