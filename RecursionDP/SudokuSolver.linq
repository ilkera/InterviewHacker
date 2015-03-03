<Query Kind="Program" />

void Main()
{
	int[,] full = { 
	{1, 7, 2, 5, 4, 9, 6, 8, 3},
	{6, 4, 5, 8, 7, 3, 2, 1, 9},
	{3, 8, 9, 2, 6, 1, 7, 4, 5},
	{4, 9, 6, 3, 2, 7, 8, 5, 1},
	{8, 1, 3, 4, 5, 6, 9, 7, 2},
	{2, 5, 7, 1, 9, 8, 4, 3, 6},
	{9, 6, 4, 7, 1, 5, 3, 2, 8},
	{7, 3, 1, 6, 8, 2, 5, 9, 4},
	{5, 2, 8, 9, 3, 4, 1, 6, 7}};
	
	SudokuSolver s = new SudokuSolver();
	s.Solve(full);
	
	int[,] partialMatrix = {{5,3,0,0,7,0,0,0,0}, 
	{6,0,0,1,9,5,0,0,0}, 
	{0,9,8,0,0,0,0,6,0}, 
	{8,0,0,0,6,0,0,0,3},
	{4,0,0,8,0,3,0,0,1},
	{7,0,0,0,2,0,0,0,6},
	{0,6,0,0,0,0,2,8,0}, 
	{0,0,0,4,1,9,0,0,5},
	{0,0,0,0,8,0,0,7,9}};
	
	SudokuSolver s2 = new SudokuSolver();
	s2.Solve(partialMatrix);
	
	int[,] empty = new int[9,9];
	
	SudokuSolver s1 = new SudokuSolver();
	s1.Solve(empty);
	empty.Dump();
	
}

public class SudokuSolver
{	
	public void Solve(int[,] matrix)
	{
		if (matrix == null || matrix.Length < 1)
		{
			return;
		}
	
		SolveSudokuHelper(matrix, 0 /* row */ , 0 /* col */);	
	}
	
	private bool SolveSudokuHelper(int[,] matrix, int row, int col)
	{	
		if (col == matrix.GetLength(1) || row == matrix.GetLength(0))
		{
			if (row == matrix.GetLength(0))
			{
				return true;
			}
			
			return SolveSudokuHelper(matrix, row + 1, 0);
		}
		
		if (matrix[row, col] != 0)
		{
			return SolveSudokuHelper(matrix, row, col + 1);
		}
		
		for (int val = 1; val <= 9; val++)
		{
			matrix[row, col] = val;
			
			if (IsValidSudoku(matrix, row, col) && SolveSudokuHelper(matrix, row, col + 1))
			{
				return true;
			}
		}
		
		matrix[row, col] = 0;	
		return false;
	}
	
	private bool IsValidSudoku(int[,] matrix, int row, int col)
	{
		int value = matrix[row, col];
		
		for (int i = 0; i < 9; i++)
		{
			if (matrix[row,i] == value && i != col)
			{
				return false;
			}	
			
			if (matrix[i, col] == value && i != row)
			{
				return false;
			}
		}
		
		int row_start = row/3*3;
        int col_start = col/3*3;
		
        for(int i=row_start; i<row_start+3; i++)
		{
            for(int j=col_start; j<col_start+3; j++)
			{
                if(matrix[i,j]==value && (i!=row || j!=col))
				{
					return false;
				}
            }
        }
		
		return true;
	}
}


// Define other methods and classes here
