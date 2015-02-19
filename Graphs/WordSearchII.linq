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

public class RowCol
{
	public int Row { get; set; }
	public int Col { get; set; }
	
	public RowCol (int row, int col)
	{
		this.Row = row;
		this.Col = col;
	}
}

public static bool SearchWord(char[,] matrix, string word)
{
	if (matrix == null || string.IsNullOrEmpty(word))
	{
		return false;
	}
	
	int rows = matrix.GetLength(0);
	int cols = matrix.GetLength(1);
	
	Dictionary<char, List<RowCol>> allChars = PreProcess(matrix);
	bool[,] visited = new bool[rows, cols];
	
	if (!allChars.ContainsKey(word[0]))
	{
		return false;
	}
	
	foreach (RowCol candidate in allChars[word[0]])
	{
		if (Search(allChars, candidate, word, 0, visited))
		{
			return true;
		}
	}
	
	return false;
}

private static bool Search(Dictionary<char, List<RowCol>> allchars, RowCol rowCol, string word, int index, bool[,] visited)
{
	if (index + 1 == word.Length)
	{
		return true;
	}
	
	int row = rowCol.Row;
	int col = rowCol.Col;
	
	visited[row, col] = true;
	index++;
	
	if (!allchars.ContainsKey(word[index]))
	{
		return false;
	}
	
	// Check neighbors
	foreach (RowCol neighbor in GetNeighbors(allchars, word[index], rowCol))
	{
		if (!visited[neighbor.Row, neighbor.Col] && Search(allchars, neighbor, word, index, visited))
		{
			return true;
		}
	}
	
	visited[row, col] = false;
	
	return false;
}

private static Dictionary<char, List<RowCol>> PreProcess(char[,] matrix)
{
	Dictionary<char, List<RowCol>> allChars = new Dictionary<char, List<RowCol>>();
	
	for (int row = 0; row < matrix.GetLength(0); row++)
	{
		for (int col = 0; col < matrix.GetLength(1); col++)
		{
			char current = matrix[row, col];
			
			if (!allChars.ContainsKey(current))
			{
				allChars.Add(current, new List<RowCol>());
			}
			allChars[current].Add(new RowCol(row, col));
		}
	}
	
	return allChars;
}

private static List<RowCol> GetNeighbors(Dictionary<char, List<RowCol>> allchars, char current, RowCol rowCol)
{
	List<RowCol> neighbors = new List<RowCol>();	
	foreach (RowCol candidate in allchars[current])
	{
		if (IsAdjacent(candidate, rowCol))
		{
			neighbors.Add(candidate);
		}
	}
	
	return neighbors;
}

private static bool IsAdjacent(RowCol first, RowCol second)
{
	int minRowDiff = Math.Abs(first.Row - second.Row);
	int minColDiff = Math.Abs(first.Col - second.Col);
	
	if ((minRowDiff == 1 && minColDiff == 0) || (minColDiff == 1 && minRowDiff == 0))
	{
		return true;
	}
	
	return false;
}

// Define other methods and classes here
