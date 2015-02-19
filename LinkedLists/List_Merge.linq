<Query Kind="Program" />

void Main()
{
	(ListUtils.Merge(null, null) == null).Dump();
	ListUtils.Merge(new Node(1), null).Dump();
	ListUtils.Merge(null, new Node(1)).Dump();
	ListUtils.Merge(new Node(1, new Node(2, new Node(3))), new Node(4, new Node(5))).Dump();
}

public class ListUtils
{
	public static Node Merge(Node first, Node second)
	{
		if (first == null || second == null)
		{
			return first == null ? second : first;
		}
		
		Node head = first;
		
		while (first.Next != null)
		{
			first = first.Next;
		}
		
		first.Next = second;
		
		return head;
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
