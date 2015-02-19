<Query Kind="Program" />

void Main()
{
	int[,] matrix = new int[4,4] {
									{0, 1, 0, 1},
									{0, 0, 0, 1},
									{1, 0, 0 , 1},
									{0, 0, 0, 0} };
	
	HasInfluencer(matrix).Dump();
	

	matrix = new int[4,4] {
									{0, 0, 0, 0},
									{0, 0, 0, 0},
									{1, 0, 0, 1},
									{0, 0, 0, 0} };
	
	HasInfluencer(matrix).Dump();
	
	
	matrix = new int[4,4] {
									{0, 1, 1, 1},
									{0, 0, 0, 0},
									{1, 0, 0, 1},
									{0, 0, 0, 0} };
	
	HasInfluencer(matrix).Dump();
	
	matrix = new int[4,4] {
									{0, 0, 0, 1},
									{0, 0, 0, 0},
									{1, 1, 0, 1},
									{0, 0, 0, 0} };
	
	HasInfluencer(matrix).Dump();
}

public static bool HasInfluencer(int[,] matrix)
{
	if (matrix == null)
	{
		return false;
	}
	
	int first = 0;
	int second = 1;
	
	while (second < matrix.GetLength(1))
	{
		if (matrix[first, second] == 1)
		{
			// first influences second 
			// second can't be influencer so move second.
			second++;
		}
		else
		{
			// first doesn't influence second
			// first can't be influencer but second can be. so move first
			first = second++;
		}
	}
	
	for (int i = 0; i < matrix.GetLength(1); i++)
	{
		if (i != first && matrix[first,i] == 0)
		{
			return false;
		}
	}
	
	return true;
}

public static bool HasInfluencer_BruteForce(int[,] matrix)
{	
	if (matrix == null)
	{
		return false;
	}
	
	for (int row = 0; row < matrix.GetLength(0); row++)
	{
		bool isInfluencer = true;
		
		for (int col = 0; col < matrix.GetLength(1); col++)
		{	
			if (row != col && matrix[row, col] == 0) 
			{
				isInfluencer = false;
				break;
			}
		}
		
		if (isInfluencer)
		{
			return true;
		}
	}
	
	return false;
}

// Define other methods and classes here