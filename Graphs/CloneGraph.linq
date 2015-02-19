<Query Kind="Program" />

void Main()
{
	GraphNode a1= new GraphNode(1);
	GraphNode a2 = new GraphNode(2);
	GraphNode a3 = new GraphNode(3);
	GraphNode a4 = new GraphNode(4);
	GraphNode a5 = new GraphNode(5);
	
	List<GraphNode> l1 = new List<GraphNode>();
	l1.Add(a2);
	l1.Add(a3);
	
	List<GraphNode> l2 = new List<GraphNode>();
	l2.Add(a4);
	
	List<GraphNode> l3 = new List<GraphNode>();
	l3.Add(a5);
	
	List<GraphNode> l4 = new List<GraphNode>();
	l4.Add(a1);
	l4.Add(a3);
	
	List<GraphNode> l5 = new List<GraphNode>();
	l5.Add(a2);
	
	a1.Neighbors = l1;
	a2.Neighbors = l2;
	a3.Neighbors = l3;
	a4.Neighbors = l4;
	a5.Neighbors = l5;
	
	a1.Dump();
	
	GraphNode clone = Clone(a1);
	clone.Dump();
}

public static GraphNode Clone(GraphNode graph)
{
	if (graph == null)
	{
		return null;
	}
	
	Queue<GraphNode> queue = new Queue<GraphNode>();
	Dictionary<GraphNode, GraphNode> map = new Dictionary<GraphNode, GraphNode>();
	
	GraphNode cloneHead = new GraphNode(graph.Data);
	queue.Enqueue(graph);
	map.Add(graph, cloneHead);
	
	while (queue.Count != 0)
	{
		GraphNode current = queue.Dequeue();
		foreach (GraphNode neighbor in current.Neighbors)
		{
			if (!map.ContainsKey(neighbor))
			{
				GraphNode copy = new GraphNode(neighbor.Data);
				map.Add(neighbor, copy);
				queue.Enqueue(neighbor);
			}
			map[current].Neighbors.Add(map[neighbor]);
		}
	}
	
	return cloneHead;
}

public class GraphNode
{
	public int Data { get; set; }
	public List<GraphNode> Neighbors { get; set;}
	
	public GraphNode(int data, List<GraphNode> neighbors =  null)
	{
		this.Data = data;
		
		if (neighbors != null)
		{
			this.Neighbors = neighbors;
		}
		else
		{
			this.Neighbors = new List<GraphNode>();
		}
	}
}

// Define other methods and classes here
