<Query Kind="Program" />

void Main()
{
	SwapPairNodes(new Node(1)).Dump();
	SwapPairNodes(new Node(1, new Node(2))).Dump();
	SwapPairNodes(new Node(1, new Node(2, new Node(3)))).Dump();
	SwapPairNodes(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))))).Dump();
	SwapPairNodes(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5, new Node(6))))))).Dump();
}

public static Node SwapPairNodes(Node head)
{
	if (head == null || head.Next == null)
	{
		return head;
	}
	
	Node newHead = head.Next;
	Node current = head;
	Node previous = null;
	
	while (current != null && current.Next != null)
	{
		Node next = current.Next.Next;
		
		if (previous != null)
		{
			previous.Next = current.Next;
		}
		
		current.Next.Next = current;
		current.Next = next;
		previous = current;
		current = next;
	}
	
	return newHead;
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
