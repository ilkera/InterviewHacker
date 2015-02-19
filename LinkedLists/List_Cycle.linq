<Query Kind="Program" />

void Main()
{
	Node noCycle = new Node(1, new Node(2, new Node(3)));
	
	(ListUtils.HasCycle(noCycle) == false).Dump();
	
	Node root = new Node(1);
	Node hasCycle = new Node(1, new Node(2, new Node(3, root)));
	root.Next = hasCycle;
	
	(ListUtils.HasCycle(root) == true).Dump();
}

public class ListUtils
{
	public static bool HasCycle(Node list)
	{
		if (list == null)
		{
			return false;
		}
		
		Node current = list;
		
		while (current != null && current.Next != list)
		{
			current = current.Next;
		}
		
		if (current == null)
		{
			return false;
		}
		
		return true;
	}
}

public class Node
{
	public int Data { get; set; }
	public Node Next { get; set; }
	
	public Node(int data, Node next = null)
	{
		this.Data = data;
		this.Next = next;
	}
}

// Define other methods and classes here
