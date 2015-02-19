<Query Kind="Program" />

void Main()
{
	Node first = new Node(1);
	Node second = new Node(2);
	Node third = new Node(3);
	
	first.Next = second;
	second.Next = third;
	
	Delete(second);
	first.Dump();
}

public static void Delete(Node nodeToDelete)
{
	if (nodeToDelete == null)
	{
		return;
	}
	
	if (nodeToDelete.Next == null)
	{
		throw new Exception("We can't delete the last item with this method");
	}
	
	Node next = nodeToDelete.Next;
	nodeToDelete.Data = next.Data;
	nodeToDelete.Next = next.Next;
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
