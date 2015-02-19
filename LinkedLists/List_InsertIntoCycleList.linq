<Query Kind="Program" />

void Main()
{
	Node list = null;
	
	list = ListUtils.InsertIntoCycle(list, 1).Dump();
	
	list = ListUtils.InsertIntoCycle(list, 2).Dump();
	
	list = ListUtils.InsertIntoCycle(list, 3).Dump();
	
	list = ListUtils.InsertIntoCycle(list, 4).Dump();
	
	list = ListUtils.InsertIntoCycle(list, 5).Dump();
	
	// List with no cycle
	Node listWithNoCycle = new Node(1, new Node(2, new Node(3)));
	
	(ListUtils.InsertIntoCycle(listWithNoCycle, 4) == null).Dump();
	
}

public class ListUtils
{
	public static Node InsertIntoCycle(Node list, int item)
	{
		if (list == null)
		{
			list = new Node(item);
			list.Next = list;			
			return list;
		}
		
		Node current = list;
		
		while (current != null && current.Next != list)
		{
			current = current.Next;
		}
		
		if (current == null)
		{
			return null;
		}
			
		Node inserted = new Node(item, current.Next);
		current.Next = inserted;
		
		return list;
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
