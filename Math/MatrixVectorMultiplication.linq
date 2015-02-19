<Query Kind="Program" />

void Main()
{
	double[,] matrix = new double[5,5] { {0.0, .90, 0, 0, 0},
										{0, 0, .36, .36, .18},
										{0, 0, 0, .90, 0},
										{.90, 0, 0, 0, 0},
										{.47, 0, .47, 0, 0}};
										
	double[] vector = new double[5] { .05, .04, .36, .37, .19};
	
	MatrixVectorMultiplication(matrix, vector, 5).Dump();
	
	SparseVector[] a = new SparseVector[5];
	for (int i = 0; i < 5; i++)
	{
		a[i] = new SparseVector();
	}
	a[0].Put(1, .90);
	a[1].Put(2, .36);
	a[1].Put(3, .36);
	a[1].Put(4, .18);
	a[2].Put(3, .90);
	a[3].Put(0, .90);
	a[4].Put(0, .47);	
	a[4].Put(2, .47);
		
	double[] b = new double[5] { .05, .04, .36, .37, .19};
	double[] result = new double[5];
	
	for (int i = 0; i < 5; i++)
	{
		result[i] = a[i].DotProduct(b);
	}
	
	result.Dump();
}

public class SparseVector
{
	private Dictionary<int, double> sparseMap;
	
	public SparseVector()
	{
		this.sparseMap = new Dictionary<int, double>();
	}
	
	public void Put(int index, double value)
	{
		if (sparseMap.ContainsKey(index))
		{
			sparseMap[index] = value;
		}
		else
		{
			sparseMap.Add(index, value);
		}
	}
	
	public double DotProduct(double[] that)
	{
		double sum = 0.0;
		foreach (var index in this.sparseMap.Keys.ToList())
		{
			sum += this.sparseMap[index] * that[index];
		}
		
		return sum;
	}
}

public static double[] MatrixVectorMultiplication(double[,] matrix, double[] vector, int length)
{
	double[] result = new double[length];
	
	for (int row = 0; row < length; row++)
	{
		double sum = 0.0;
		
		for (int i = 0; i < length; i++)
		{
			sum += matrix[row,i] * vector[i];
		}
		result[row] = sum;
	}
	
	return result;
}

// Define other methods and classes here
