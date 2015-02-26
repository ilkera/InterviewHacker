<Query Kind="Program" />

void Main()
{
	Graph g = new Graph(7);
	g.AddEdge(0,1);
	g.AddEdge(0,5);
	g.AddEdge(0,2);
	g.AddEdge(6,0);
	g.AddEdge(6,4);
	g.AddEdge(3,2);
	g.AddEdge(3,4);
	g.AddEdge(3,6);
	g.AddEdge(3,5);
	g.AddEdge(5,2);
	g.AddEdge(1,4);
	
	DepthFirstOrder df = new DepthFirstOrder(g);
	df.ReversePost().Dump();
}

public class DepthFirstOrder
{
	private bool[] visited;
	private List<int> postOrder;
	
	public DepthFirstOrder(Graph g)
	{
		this.visited = new bool[g.V];
		this.postOrder = new List<int>();
		
		for (int i = 0; i < g.V; i++)
		{
			if (!this.visited[i])
			{
				Dfs(g, i);
			}
		}
		
		this.postOrder.Reverse();
	}
	
	public List<int> ReversePost()
	{
		return this.postOrder;
	}
	
	private void Dfs(Graph g, int current)
	{
		this.visited[current] = true;
		
		foreach (var neighbor in g.Neighbors(current))
		{
			if (!this.visited[neighbor])
			{
				Dfs(g, neighbor);
			}
		}
		
		postOrder.Add(current);
	}
}



// DAG
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
	}
}
// Define other methods and classes here