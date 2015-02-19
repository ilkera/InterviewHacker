<Query Kind="Program" />

void Main()
{
	Node cycleEnd = new Node(8);
	Node cycleStart = new Node(4, new Node(5, new Node(6, new Node(7, cycleEnd))));
	cycleEnd.Next = cycleStart;
	
	Node head = new Node(1, new Node(2, new Node(3, cycleStart)));
	
	FindCycle(head).Value.Dump();
}

public static Node FindCycle(Node head)
{
	if (head == null)
	{
		return null;
	}
	
	Node slow = head;
	Node fast = head;
	
	while (fast != null && fast.Next != null)
	{
		slow = slow.Next;
		fast = fast.Next.Next;
		
		if (slow == fast)
		{
			break;
		}
	}
	
	if (fast == null || fast.Next == null)
	{
		return null;
	}
	
	fast = head;
	
	while (fast != slow)
	{
		fast = fast.Next;
		slow = slow.Next;
	}
	
	return slow;
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
