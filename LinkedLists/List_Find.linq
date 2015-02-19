<Query Kind="Program" />

void Main()
{
	Node list = new Node(5, new Node(3, new Node(2, new Node(1, new Node(0)))));
	
	ListUtils.Find(list, 5).Data.Dump();
	
	ListUtils.Find(list, 1).Data.Dump();
			
	(ListUtils.Find(list, 10) == null).Dump();
}

public class ListUtils
{
	public static Node Find(Node current, int key)
	{
		while (current != null && current.Data != key)
		{
			current = current.Next;
		}		
		return current;
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
