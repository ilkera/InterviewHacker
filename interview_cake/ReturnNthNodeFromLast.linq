<Query Kind="Program" />

void Main()
{
	NthNodeFromLast(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))), 1).Data.Dump();
	NthNodeFromLast(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))), 2).Data.Dump();
	NthNodeFromLast(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))), 3).Data.Dump();
	NthNodeFromLast(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))), 4).Data.Dump();
	NthNodeFromLast(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))), 5).Data.Dump();
	(NthNodeFromLast(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))), 6) == null).Dump();
	(NthNodeFromLast(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))), 0) == null).Dump();
}

public static Node NthNodeFromLast(Node head, int k)
{
	if (k <= 0 || head == null)
	{
		return null;
	}
	
	Node current = head;
	Node result = current;
	
	while (current != null)
	{
		if (k > 0)
		{
			k--;
		}
		else
		{
			result = result.Next;
		}
		
		current = current.Next;
	}
	
	if (k > 0)
	{
		return null;
	}
	
	return result;
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
