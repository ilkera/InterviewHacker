<Query Kind="Program" />

void Main()
{
	Node root = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))));
	
	ListUtils.Reverse(root).Dump();
}

public class ListUtils
{
	public static Node Reverse(Node head)
	{
		if (head == null)
		{
			return null;
		}
		
		Node current = head;
		Node previous = null;
		
		while (current != null)
		{
			Node next = current.Next;	
			current.Next = previous;
			previous = current;
			current = next;
		}
		
		return previous;
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