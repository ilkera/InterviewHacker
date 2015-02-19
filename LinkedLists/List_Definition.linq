<Query Kind="Program" />

void Main()
{
	Node list = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))));
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
