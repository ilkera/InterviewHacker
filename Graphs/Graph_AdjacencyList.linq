<Query Kind="Program" />

void Main()
{
	Graph g = new Graph(5);
	g.AddEdge(0,1);
	g.AddEdge(2,4);
	g.AddEdge(0,2);
	g.AddEdge(3,1);
	
	g.Neighbors(0).Dump();
}

public class Graph
{
	private int V;
	private List<int>[] adj;
	
	public Graph(int vertexCount)
	{
		this.V = vertexCount;
		this.adj = new List<int>[this.V];
		
		for (int i = 0; i < this.V; i++)
		{
			this.adj[i] = new List<int>();
		}
	}
	
	public List<int> Neighbors(int v)
	{
		return this.adj[v];
	}
	
	public void AddEdge(int v, int w)
	{
		adj[v].Add(w);
		adj[w].Add(v);
	}
}
// Define other methods and classes here
