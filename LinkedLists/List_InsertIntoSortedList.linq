<Query Kind="Program" />

void Main()
{
	Node list = null;
	
	ListUtils.Insert(ref list, 5);
	
	list.Dump();
	
	ListUtils.Insert(ref list, 2);
	
	list.Dump();
	
	ListUtils.Insert(ref list, 3);
	
	list.Dump();
	
	ListUtils.Insert(ref list, 1);
	
	list.Dump();
	
	ListUtils.Insert(ref list, 1);
	
	list.Dump();
}

public class ListUtils
{
	// Insert item into sorted list
	public static void Insert(ref Node list, int item)
	{
		// Case 1 : empty list or minimum
		if (list == null || item <= list.Data)
		{
			list = new Node(item, list);
			return;
		}
		
		Node current = list;
		Node previous = null;
		
		while (current != null && current.Data < item)
		{
			previous = current;
			current = current.Next;
		}
		
		// adding max or into middle
		previous.Next = new Node(item, current);	
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
