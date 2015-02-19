<Query Kind="Program" />

void Main()
{
	bool[,] matrix = { {true, true, true, false, true},
	{true, true, true, false, true},
	{false, false, true, false, false}, 
	{true, false, true, true, true}, {false, true, true, false, true}};
	
	matrix.Dump();
	
	CelebrityFinder cf = new CelebrityFinder(matrix);
	cf.FindCelebrity_BruteForce().Dump();
	cf.FindCelebrity_PreComputed().Dump();
	cf.FindCelebrity().Dump();
	
	// no celebrity case
	
	bool[,] noCelebMatrix = { {true, true, false, false}, {true, true, false, false}, {false, true, true, true}, {false, false, false, false}};
	noCelebMatrix.Dump();
	
	CelebrityFinder noCf = new CelebrityFinder(noCelebMatrix);
	noCf.FindCelebrity_BruteForce().Dump();
	noCf.FindCelebrity_PreComputed().Dump();
	noCf.FindCelebrity().Dump();
}

public class CelebrityFinder
{
	private bool[,] matrix;
	private Dictionary<int, List<int>> relationMap;
	
	public CelebrityFinder(bool[,] matrix)
	{
		this.matrix = matrix;
		this.relationMap = new Dictionary<int, List<int>>();
		
		this.BuildRelationMap();
	}
	
	public bool KnowsOf(int first, int second)
	{
		return this.matrix[first, second] == true;
	}
	
	public int FindCelebrity()
	{
		int first = 0;
		int second = 1;
		
		while (second < matrix.GetLength(1))
		{
			// First Knows Second
			if (this.matrix[first,second])
			{
				// a. First is not celebrity because first != second 
				// b. Celebrity only knows itself
				first = second++;
			}
			else
			{
				// First Does Not Know Second
				// a. First could be celebrity (candidate)
				// b. Second can not be celebrity. Because everybody knows celebrity.
				second++;
			}
		}
		
		for (int i = 0; i < this.matrix.GetLength(0); i++)
		{
			if (i != first && this.matrix[first,i])
			{
				return -1;
			}
		}
		
		return first;
	}
	
	public int FindCelebrity_PreComputed()
	{
		int celebrity = -1;
		
		foreach (KeyValuePair<int, List<int>> relation in this.relationMap)
		{
			if (relation.Value.Count == 1 && relation.Key == relation.Value[0])
			{
				celebrity = relation.Key;
			}
		}
	
		return celebrity;
	}
	
	public int FindCelebrity_BruteForce()
	{
		int celebrity = -1;
		for (int row = 0; row < matrix.GetLength(0); row++)
		{
			bool isCelebrity = true;
			for (int col = 0; col < matrix.GetLength(1); col++)
			{
				if (row != col && matrix[row,col] || (row == col && !matrix[row,col]))
				{
					isCelebrity = false;
					break;
				}
			}
			
			if (isCelebrity)
			{
				celebrity = row;
				break;
			}
		}
		
		return celebrity;
	}
	
	private void BuildRelationMap()
	{
		for (int row = 0; row < this.matrix.GetLength(0); row++)
		{
			this.relationMap.Add(row, new List<int>());
			
			for (int col = 0; col < this.matrix.GetLength(1); col++)
			{
				if (matrix[row,col])
				{
					this.relationMap[row].Add(col);
				}
			}
		}
	}
}


// Define other methods and classes here
