<Query Kind="Program" />

void Main()
{
	Node first = new Node(2, new Node(5, new Node(8, new Node(12, new Node(20)))));
	Node second = new Node(1, new Node(4, new Node(7, new Node(10))));
	
	Util.Merge(first, second).Dump();
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

public class Util
{
	public static Node Merge(Node first, Node second)
	{
		if (first == null && second == null)
		{
			return null;
		}
		
		if (first == null || second == null)
		{
			return first == null ? second : first;
		}
		
		Node current_first = first;
		Node current_second = second;
		Node newHead = new Node(-1);
		Node current_merged = newHead;
		
		while (current_first != null && current_second != null)
		{
			if (current_first.Data < current_second.Data)
			{
				current_merged.Next = current_first;
				current_first = current_first.Next;
			}
			else 
			{
				current_merged.Next = current_second;
				current_second = current_second.Next;
			}
			
			current_merged = current_merged.Next;
		}
		
		if (current_first != null)
		{
			current_merged.Next = current_first;
		}
		
		if (current_second != null)
		{
			current_merged.Next = current_second;
		}
		
		return newHead.Next;
	}
}

// Define other methods and classes here
