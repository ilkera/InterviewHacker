<Query Kind="Program" />

void Main()
{
	Node list = null;
	
	(ListUtils.Remove(list, 4) == null).Dump();
	
	list = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))));
	
	ListUtils.Remove(list, 4).Dump();
			
	ListUtils.Remove(list, 5).Dump();
	
	ListUtils.Remove(list, 72).Dump();
	
	ListUtils.Remove(list, 1).Dump();
	
	Node list2 = new Node(3, new Node(5, new Node(2, new Node(3, new Node(3)))));
	ListUtils.Remove(list2, 3).Dump();
}

public class ListUtils
{	
	public static Node Remove(Node head, int keyToBeRemoved)
	{
		// special case: removed item is at front
		while (head != null && head.Data == keyToBeRemoved)
		{
			head = head.Next;
		}
		
		// null list
		if (head == null)
		{
			return null;
		}
		
		Node current = head;	
		while (current != null && current.Next != null)
		{
			if (current.Next.Data == keyToBeRemoved)
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
