<Query Kind="Program" />

void Main()
{
	RemoveDuplicates(new Node(1, new Node(1, new Node(2, new Node(3))))).Dump();
	RemoveDuplicates(new Node(1, new Node(1, new Node(1, new Node(1))))).Dump();
	RemoveDuplicates(new Node(1, new Node(2, new Node(2, new Node(3, new Node(4, new Node(5))))))).Dump();
}

public static Node RemoveDuplicates(Node head)
{
	if (head == null || head.Next == null)
	{
		return head;
	}
	
	Node current = head;
	
	while (current != null && current.Next != null)
	{
		if (current.Value == current.Next.Value)
		{
			current.Next = current.Next.Next;
		}
		else
		{
			current = current.Next;
		}
	}
	
	return head;
}

public class Node
{
	public int Value { get; set; }
	public Node Next { get; set; }
	
	public Node(int value, Node next = null)
	{
		this.Value = value;
		this.Next = next;
	}
}

// Define other methods and classes here
