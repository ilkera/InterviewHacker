<Query Kind="Program" />

void Main()
{
	Node last = new Node(7);
	Node head = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5, new Node(6, last))))));
	last.Next = head;
	
	HasCycle(head).Dump();
	
}

public static bool HasCycle(Node head)
{
	if (head == null)
	{
		return false;
	}
	
	Node slow = head;
	Node fast = head;
	
	while (fast != null && fast.Next != null)
	{
		slow = slow.Next;
		fast = fast.Next.Next;
		
		if (fast == slow)
		{
			return true;
		}
	}
	
	return false;
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
