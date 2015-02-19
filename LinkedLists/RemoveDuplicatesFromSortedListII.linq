<Query Kind="Program" />

void Main()
{
	RemoveDuplicatesFromSortedListII(new Node(1, new Node(1, new Node(2)))).Dump();
	RemoveDuplicatesFromSortedListII(new Node(1, new Node(1, new Node(1, new Node(1))))).Dump();
	RemoveDuplicatesFromSortedListII(new Node(1, new Node(2, new Node(2, new Node(3))))).Dump();	
	RemoveDuplicatesFromSortedListII(new Node(1, new Node(2, new Node(2, new Node(3, new Node(3)))))).Dump();	
	RemoveDuplicatesFromSortedListII(new Node(1, new Node(2, new Node(3, new Node(3, new Node(4, new Node(4, new Node(5)))))))).Dump();	
}

public static Node RemoveDuplicatesFromSortedListII(Node head)
{
	if (head == null || head.Next == null)
	{
		return head;
	}
	
	while (head != null && head.Next != null && head.Value == head.Next.Value)
	{
		head = head.Next.Next;
	}
	
	if (head == null)
	{
		return null;
	}
	
	Node current = head;
	Node previous = null;
	
	while (current != null && current.Next != null)
	{
		if (current.Value == current.Next.Value)
		{
			previous.Next = current.Next.Next; 
			current = previous.Next;
		}
		else
		{
			previous = current;
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
