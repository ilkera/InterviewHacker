<Query Kind="Program" />

void Main()
{
	Node emptyList = null;
	ListUtils.Insert(ref emptyList, 3);
	
	emptyList.Dump();
	
	ListUtils.Insert(ref emptyList, 5);
	
	emptyList.Dump();	
}

public class ListUtils
{
	public static void Insert(ref Node head, int item)
	{
		// Case 1 : Empty list
		if (head == null)
		{
			head = new Node(item, null);
			return;
		}
		
		// Case 2: Add item in front of the list
		Node newItem = new Node(item, head);
		head = newItem;
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
