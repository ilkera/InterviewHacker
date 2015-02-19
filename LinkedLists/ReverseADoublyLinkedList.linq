<Query Kind="Program" />

void Main()
{
	// 1 - 2 - 3
	// cur.Pre = next;
	// cur.Next = pre
	// pre = cur
	// cur = next;
	// 3  2  1
	
	Node first = new Node(1);
	Node second = new Node(2);
	Node third = new Node(3);
	
	first.Previous = null;
	first.Next = second;
	second.Previous = first;
	second.Next = third;
	third.Previous =second;
	
	ListUtil.PrintList(first);
	Node reversed = ListUtil.Reverse(first);
	ListUtil.PrintList(reversed);
}

public class ListUtil
{
	public static void PrintList(Node head)
	{
		if (head == null)
		{
			return;
		}
		
		Node current = head;
		
		while (current != null)
		{
			string previous = current.Previous != null ? current.Previous.Data.ToString() : "null";
			Console.Write("P:{0}:C:{1} ->", previous, current.Data);
			current = current.Next;
		}
		Console.WriteLine("");
	}
	
	public static Node Reverse(Node head)
	{
		if (head == null || head.Next == null)
		{
			return head;
		}
		
		Node current = head;
		Node previous = null;
		
		while (current != null)
		{
			Node next = current.Next;
			current.Previous = next;
			current.Next = previous;
			previous = current;
			current = next;
		}
		
		return previous;
	}
}

public class Node
{
	public int Data { get; set; }
	public Node Next { get;  set; }
	public Node Previous { get; set; }
	
	public Node(int data, Node next = null, Node previous = null)
	{
		this.Data = data;
		this.Next = next;
		this.Previous = previous;
	}
}

// Define other methods and classes here
