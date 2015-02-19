<Query Kind="Program" />

void Main()
{

	Node even = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5, new Node(6))))));
	Node odd = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))));
	Node empty = null;
	Node single = new Node(1);
	Node two = new Node(1, new Node(2));
	
	ListUtils.FindMiddleNode(even).Data.Dump();
	ListUtils.FindMiddleNode(odd).Data.Dump();
	(ListUtils.FindMiddleNode(empty) == null).Dump();
	ListUtils.FindMiddleNode(single).Data.Dump();
	ListUtils.FindMiddleNode(two).Data.Dump();
	
	Console.WriteLine("Method v2");
	ListUtils.FindMiddleNode_v2(even).Data.Dump();
	ListUtils.FindMiddleNode_v2(odd).Data.Dump();
	(ListUtils.FindMiddleNode_v2(empty) == null).Dump();
	ListUtils.FindMiddleNode_v2(single).Data.Dump();
	ListUtils.FindMiddleNode_v2(two).Data.Dump();
}

public class ListUtils
{
	public static Node FindMiddleNode(Node list)
	{
		if (list == null)
		{
			return null;
		}
		
		Node faster = list;
		Node slower = list;
		
		while (faster != null && faster.Next != null)
		{
			faster = faster.Next.Next;
			slower = slower.Next;
		}
	
		return slower;
	}
	
	public static Node FindMiddleNode_v2(Node head)
	{
		if (head == null)
		{
			return null;
		}
		
		int count = 0;
		Node current = head;
		Node mid = head;
		
		while (current != null)
		{
			if ((count & 1) == 1)
			{
				mid = mid.Next;
			}
			
			count++;
			current = current.Next;
		}
		
		return mid;
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
