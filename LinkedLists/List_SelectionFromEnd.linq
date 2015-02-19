<Query Kind="Program" />

void Main()
{
	Node regular = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))));
	(ListUtils.FindNthFromEnd(regular, 1).Data == 5).Dump();
	(ListUtils.FindNthFromEnd(regular, 2).Data == 4).Dump();
	(ListUtils.FindNthFromEnd(regular, 3).Data == 3).Dump();
	(ListUtils.FindNthFromEnd(regular, 4).Data == 2).Dump();
	(ListUtils.FindNthFromEnd(regular, 5).Data == 1).Dump();
	(ListUtils.FindNthFromEnd(regular, 6) == null).Dump();
	(ListUtils.FindNthFromEnd(regular, 0) == null).Dump();
	(ListUtils.FindNthFromEnd(regular, -4) == null).Dump();
	(ListUtils.FindNthFromEnd(null, 2) == null).Dump();
}

public class ListUtils
{
	public static Node FindNthFromEnd(Node head, int n)
	{
		if (n < 1 || head == null)
		{
			return null;
		}
		
		Node current = head;
		while (n > 0 && current != null)
		{
			current = current.Next;
			n--;
		}
		
		if (n == 0 && current == null) 
		{
			return head;
		}
		else if (current == null)
		{
			return null;
		}
		
		Node lastFromEnd = head;
		
		while (current != null)
		{
			current = current.Next;
			lastFromEnd = lastFromEnd.Next;
		}
		
		return lastFromEnd;
		
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
