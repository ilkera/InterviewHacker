<Query Kind="Program" />

void Main()
{
	(ListUtils.HasCycle(null) == false).Dump();
	(ListUtils.HasCycle(new Node(1)) == false).Dump();
	(ListUtils.HasCycle(new Node(1, new Node(2))) == false).Dump();
	
	Node root = new Node(1);
	Node cycle = new Node(2, new Node(3, new Node(4, new Node(5, root))));
	root.Next = cycle;
	(ListUtils.HasCycle(root) == true).Dump();	
}

public class ListUtils
{
	public static bool HasCycle(Node head)
	{
		if (head == null || head.Next == null)
		{
			return false;
		}
		
		Node faster = head;
		Node slower = head;
		
		while (faster != null && faster.Next != null)
		{
			slower = slower.Next;
			faster = faster.Next.Next;
			
			if (slower == faster)
			{
				return true;
			}
		}
		
		return false;
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
