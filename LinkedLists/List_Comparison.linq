<Query Kind="Program" />

void Main()
{
	(ListUtils.AreEquals(null, new Node(1)) == false).Dump();	
	(ListUtils.AreEquals(new Node(1), null) == false).Dump();
	(ListUtils.AreEquals(null, null) == true).Dump();
	(ListUtils.AreEquals(new Node(1), new Node(1)) == true).Dump();
	(ListUtils.AreEquals(new Node(1), new Node(2)) == false).Dump();
	(ListUtils.AreEquals(new Node(1, new Node(2, new Node(3))), new Node(1, new Node(2, new Node(3)))) == true).Dump();
	(ListUtils.AreEquals(new Node(1, new Node(2, new Node(3, new Node(4)))), new Node(1, new Node(2, new Node(3)))) == false).Dump();	
}

public class ListUtils
{
	public static bool AreEquals(Node first, Node second)
	{
		if (first == null && second == null)
		{
			return true;
		}
		else if (first == null || second == null)
		{
			return false;
		}
		
		Node first_current = first;
		Node second_current = second;
		
		while (first_current != null && second_current != null)
		{
			if (first_current.Data != second_current.Data)
			{
				return false;
			}
			
			first_current = first_current.Next;
			second_current = second_current.Next;
		}
		
		return first_current == null && second_current == null;
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
