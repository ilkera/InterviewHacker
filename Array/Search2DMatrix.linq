<Query Kind="Program" />

/* Problem: Search a 2-D Matrix

Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

Integers in each row are sorted from left to right.
The first integer of each row is greater than the last integer of the previous row.
For example,

Consider the following matrix:

[
  [1,   3,  5,  7],
  [10, 11, 16, 20],
  [23, 30, 34, 50]
]
Given target = 3, return true.

*/
void Main()
{
	int[,] matrix = {{1, 3, 5, 7}, 
					{10, 12, 16, 20}, 
					{23, 30, 34, 50}};
					
	int[] targets = {1, 3 ,5, 7, 10, 12, 16, 20, 23, 30, 34, 50, 90, 120};
	
	foreach (var element in targets)
	{
		Search(matrix, element).Dump();
	}
}

public static bool Search(int[,] matrix, int target)
{
	if (matrix == null || matrix.Length < 1)
	{	
		return false;
	}
	
	int rowCount = matrix.GetLength(0);
	int colCount = matrix.GetLength(1);
	
	int start = 0;
	int end = rowCount * colCount - 1;
	
	while (start <= end)
	{
		int mid = start + (end - start) / 2;
		int midRow = mid / colCount;
		int midCol = mid % colCount;
		
		if (target == matrix[midRow, midCol])
		{
			return true;
		}
		else if (matrix[midRow, midCol] > target)
		{
			end = mid - 1;			
		}
		else
		{
			start = mid + 1;
		}
	}
	
	return false;
}

// Define other methods and classes here
