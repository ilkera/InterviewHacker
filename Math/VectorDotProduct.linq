<Query Kind="Program" />

void Main()
{
	double[] y = {5.0, 2.0, 4.0, 1.0};
	double[] x = {1.0, 2.0, 3.0, 4.0};
	
	Vector v_x = new Vector(x);
	Vector v_y = new Vector(y);
	
	v_x.DotProduct( v_y).Dump();
}

public class Vector
{
	private int N; // length
	private double[] data;
	
	public Vector(int n)
	{
		this.N = n;
		this.data = new double[this.N];
	}
	
	public Vector(double[] data)
	{
		this.N = data.Length;
		this.data = new double[this.N];
		
		for (int i = 0; i < this.N; i++)
		{
			this.data[i] = data[i];
		}
	}
	
	public double DotProduct(Vector that)
	{
		if (this.N != that.N)
		{
			throw new Exception("Dimensions don't agree");
		}
		
		double sum = 0.0;
		for (int i = 0; i < this.N; i++)
		{
			sum += this.data[i] * that.data[i];
		}
		
		return sum;
	}
}

// Define other methods and classes here
