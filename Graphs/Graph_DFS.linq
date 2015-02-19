<Query Kind="Program" />

void Main()
{
	Graph g = new Graph(5);
	g.AddEdge(0,1);
	g.AddEdge(2,4);
	g.AddEdge(0,2);
	g.AddEdge(3,1);
	
	/*
	
		0 - 1 - 3
		2 
		4
	
	*/
	
	DepthFirstPaths dfs = new DepthFirstPaths(g, 0);
	dfs.HasPathTo(1).Dump();
	dfs.HasPathTo(3).Dump();
	dfs.HasPathTo(4).Dump();
	dfs.GetPath(4).Dump();

}

public class DepthFirstPaths
{
	private bool[] visited;
	private int[] edgeTo;
	private int source;
	
	public DepthFirstPaths(Graph g, int s)
	{
		this.visited = new bool[g.V];
		this.edgeTo = new int[g.V];
		
		for (int i = 0; i < this.edgeTo.Length; i++)
		{
			this.edgeTo[i] = -1;
		}
		
		this.source = s;
		
		//this.Dfs(g, s);
		
		this.Dfs_Iterative(g);
	}
	
	public List<int> GetPath(int vertex)
	{
		List<int> result = new List<int>();
		
		if (this.HasPathTo(vertex))
		{
			for (int i = vertex; i != this.source; i = edgeTo[i])
			{
				result.Add(i);	
			}
			
			result.Add(this.source);
		}
		
		return result;
	}
	
	public bool HasPathTo(int vertex)
	{
		return this.visited[vertex];
	}
	
	private void Dfs_Iterative(Graph g)
	{
		Stack<int> vertices = new Stack<int>();
		
		vertices.Push(this.source);
		while (vertices.Count != 0)
		{
			int current = vertices.Pop();
			this.visited[current] = true;
			
			foreach (var neighbor in g.Neighbors(current))
			{
				if (!this.visited[neighbor])
				{
					vertices.Push(neighbor);
					this.edgeTo[neighbor] = current;
				}
			}
		}
		
	}
	private void Dfs(Graph g, int vertex)
	{
		this.visited[vertex] = true;
			
		foreach (var neighbor in g.Neighbors(vertex))
		{
			if (!this.visited[neighbor])
			{
				Dfs(g, neighbor);
				edgeTo[neighbor] = vertex;
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
