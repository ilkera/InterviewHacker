<Query Kind="Program" />

void Main()
{
	char[,] matrix = new char[4,4] { 
	{'C','S','V','N'}, 
	{'L','G','H','M'}, 
	{'D','F','O','A'}, 
	{'H','A','T','X'}};
	
	matrix.Dump();
	
	DoesWordExist(matrix, "HOT").Dump();
	DoesWordExist(matrix, "HAT").Dump();
	DoesWordExist(matrix, "HELLO").Dump();
}

public static bool DoesWordExist(char[,] matrix, string word)
{
	if (matrix == null || matrix.Length < 1 || string.IsNullOrEmpty(word))
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
			if (!visited[row, col] && matrix[row, col] == word[0] && Search(matrix, row, col, "", word, visited))
			{
				return true;
			}
		}
	}
	
	return false;	
}

private static bool Search(char[,] matrix, int row, int col, string prefix, string word, bool[,] visited)
{
	visited[row, col] = true;
	string current = prefix + matrix[row, col];
	
	if (current == word)
	{
		return true;
	}
	
	if (CanMove(matrix, row-1, col, visited) && Search(matrix, row-1, col, current, word, visited))
	{
		return true;
	}
	
	if (CanMove(matrix, row+1, col, visited) && Search(matrix, row+1, col, current, word, visited))
	{
		return true;
	}
	
	if (CanMove(matrix, row, col - 1, visited) && Search(matrix, row, col - 1, current, word, visited))
	{
		return true;
	}
	
	if (CanMove(matrix, row, col + 1, visited) && Search(matrix, row, col + 1, current, word, visited))
	{
		return true;
	}
	
	visited[row, col] = false;
	
	return false;
}

private static bool CanMove(char[,] matrix, int row, int col, bool[,] visited)
{
	return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && !visited[row, col];
}

// Define other methods and classes here