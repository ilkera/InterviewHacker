<Query Kind="Program" />

void Main()
{
		Graph g = new Graph(10);
		g.AddEdge(0, 2);
		g.AddEdge(2, 3);
		g.AddEdge(4, 7);
		g.AddEdge(7, 5);
		g.AddEdge(5, 1);
		g.AddEdge(5, 3);
		g.AddEdge(0, 1);
		
		ShortestPath sp = new ShortestPath(g, 0);
		sp.DistanceTo(3).Dump();
}

public class ShortestPath
{
	private int source;
	private int[] edgeTo;
	private int[] distTo;
	private bool[] visited;
	
	public ShortestPath(Graph g, int source)
	{
		this.source = source;
		this.visited = new bool[g.V];
		this.edgeTo = new int[g.V];
		
		for (int i = 0; i < this.edgeTo.Length; i++)
		{
			this.edgeTo[i] = -1;
		}
		
		this.distTo = new int[g.V];
		
		this.BFS(g);
	}
	
	public void BFS(Graph g)
	{
		Queue<int> vertices = new Queue<int>();
		vertices.Enqueue(this.source);
		this.visited[this.source] = true;
		this.distTo[this.source] = 0;
		
		while (vertices.Count != 0)
		{
			int current = vertices.Dequeue();
			
			foreach (var neighbor in g.Neighbors(current))
			{
				if (!this.visited[neighbor])
				{
					vertices.Enqueue(neighbor);
					this.visited[neighbor] = true;
					this.edgeTo[neighbor] = current;
					this.distTo[neighbor] = this.distTo[current] + 1;
				}
			}
		}
		
	}
	
	public List<int> Path(int vertex)
	{
		List<int> result = new List<int>();
		
		if (this.DistanceTo(vertex) > 0)
		{
			for (int i = vertex; i != this.source; i = this.edgeTo[i])
			{
				result.Add(i);
			}
			
			result.Add(this.source);
		}
		
		return result;
	}
	
	public int DistanceTo(int vertex)
	{
		return this.distTo[vertex];
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
