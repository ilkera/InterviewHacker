<Query Kind="Program" />

void Main()
{
	Graph g = new Graph(13);
	g.AddEdge(0,6);
	g.AddEdge(0,1);
	g.AddEdge(0,2);
	g.AddEdge(0,5);
	g.AddEdge(6,4);
	g.AddEdge(4,5);
	g.AddEdge(3,5);
	g.AddEdge(3,4);
	
	g.AddEdge(7,8);
	
	g.AddEdge(9,10);
	g.AddEdge(9,11);
	g.AddEdge(9,12);
	g.AddEdge(11,12);
	
	ConnectedComponents cc = new ConnectedComponents(g);
	cc.Count().Dump();
	
	cc.Id(11).Dump();
	cc.Id(7).Dump();
	cc.Id(0).Dump();
}

public class ConnectedComponents
{
	private bool[] visited;
	private int[] id;
	private int count;
	
	public ConnectedComponents(Graph g)
	{
		this.visited = new bool[g.V];
		this.id = new int[g.V];
		this.count = 0;
		
		for (int i = 0; i < g.V; i++)
		{
			if (!this.visited[i])
			{
				DFS(g, i);	
				this.count++;
			}
		}
	}
	
	public bool Connected(int v, int w)
	{
		return this.id[v] == this.id[w];
	}
	
	public int Count()
	{
		return this.count;
	}
	
	public int Id(int vertex)
	{
		return this.id[vertex];
	}
	
	private void DFS(Graph g, int current)
	{
		this.visited[current] = true;
		this.id[current] = this.count;
		
		foreach (var neighbor in g.Neighbors(current))
		{
			if (!this.visited[neighbor])
			{
				DFS(g, neighbor);
			}
		}
	}
}

public class Graph
{
	private int v;
	private List<int>[] adj;
	
	public Graph(int vertexCount)
	{
		this.v = vertexCount;
		this.adj = new List<int>[this.v];
		
		for (int i = 0; i < this.v; i++)
		{
			this.adj[i] = new List<int>();
		}
	}
	
	public int V
	{
		get
		{
			return this.v;
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
