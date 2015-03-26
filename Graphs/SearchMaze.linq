<Query Kind="Program" />

void Main()
{
	int[,] maze1 = new int[6,6] { {0, 1, 1, 1, 1, 1}, {0, 0, 0, 0, 0, 0}, {1, 0, 1, 0, 1, 0}, {1, 0, 1, 0, 1, 0}, {0, 0, 0, 1, 0, 0}, {1, 1, 0, 0, 0, 1} };
	
	maze1.Dump();
	
	SolveMaze(maze1, new RowCol(0,0), new RowCol(4,5)).Dump();
	
	int[,] maze2 = new int[6,6] { 
	{0, 1, 1, 1, 1, 1},
	{0, 0, 0, 0, 0, 0},
	{1, 0, 1, 0, 1, 0},
	{1, 0, 1, 0, 1, 0}, 
	{0, 0, 0, 1, 0, 0},
	{1, 1, 0, 0, 1, 1} };
	
	//maze2.Dump();
	
	SolveMaze(maze2, new RowCol(0,0), new RowCol(4,5)).Dump();

	int[,] maze3 = new int[6,6] { 
	{0, 1, 1, 1, 1, 1},
	{0, 0, 0, 0, 0, 1},
	{1, 0, 1, 0, 1, 0},
	{1, 0, 1, 0, 1, 0}, 
	{0, 0, 0, 1, 0, 0},
	{1, 1, 0, 0, 1, 1} };
	
	//maze3.Dump();
	
	SolveMaze(maze3, new RowCol(0,0), new RowCol(4,5)).Dump();
}

public class RowCol
{
	public int Row { get; set; }
	public int Col { get; set; }
	
	public RowCol(int row, int col)
	{
		this.Row = row;
		this.Col = col;
	}
}

public static bool SolveMaze(int[,] matrix, RowCol start, RowCol target)
{
	if (matrix == null || matrix.Length < 1)
	{
		return false;
	}
	
	int rows = matrix.GetLength(0);
	int cols = matrix.GetLength(1);
	bool[,] visited = new bool[rows, cols];
	
	return SearchMaze(matrix, start, target, visited);
}

private static bool SearchMaze(int[,] matrix, RowCol current, RowCol target, bool[,] visited)
{
	if (AreEqual(current, target))
	{
		return true;
	}
	
	visited[current.Row, current.Col] = true;	

	if (CanMove(matrix, current.Row - 1, current.Col, visited) && SearchMaze(matrix, new RowCol(current.Row -1, current.Col), target, visited))
	{
		return true;
	}
	
	if (CanMove(matrix, current.Row + 1, current.Col, visited) && SearchMaze(matrix, new RowCol(current.Row + 1, current.Col), target, visited)) 
	{
		return true;
	}
	
	if (CanMove(matrix, current.Row, current.Col - 1, visited) && SearchMaze(matrix, new RowCol(current.Row, current.Col - 1), target, visited))
	{
		return true;	
	}
	
	if (CanMove(matrix, current.Row, current.Col + 1, visited) && SearchMaze(matrix, new RowCol(current.Row, current.Col + 1), target, visited))
	{
		return true;
	}

	visited[current.Row, current.Col] = false;	
	return false;
}

private static bool CanMove(int[,] matrix, int row, int col, bool[,] visited)
{
	if (row < matrix.GetLength(0) && row >= 0 && col < matrix.GetLength(1) && col >= 0)
	{
		return matrix[row, col] != 1 && !visited[row, col];
	}
	return false;
}

private static bool AreEqual(RowCol a, RowCol b)
{
	return a.Row == b.Row && a.Col == b.Col;
}

// Define other methods and classes here