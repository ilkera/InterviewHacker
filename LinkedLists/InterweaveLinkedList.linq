<Query Kind="Program" />

void Main()
{
	Node test = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))));
	
	NodeUtils.Print(test);
	Interweave(test);
	NodeUtils.Print(test);
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

public static class NodeUtils
{
	public static void Print(Node head)
	{
		if (head == null)
		{
			return;
		}
		
		Node current = head;
		
		while (current != null)
		{
			Console.Write("{0} ->", current.Data);
			current = current.Next;
		}
		Console.WriteLine("");
	}
	public static Node FindMid(Node head)
	{
		Node slow = head;
		Node fast = head;
		
		while (fast != null && fast.Next != null)
		{
			slow = slow.Next;
			fast = fast.Next.Next;
		}
		
		return slow;
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
			current.Next = previous;
			previous = current;
			current = next;
		}
		
		return previous;
	}
	
	public static Node Merge(Node first, Node second)
	{		
		if (first == null || second == null)
		{
			return first == null ? second : first;
		}
		
		Node merged = new Node(-1); // sentinel
		Node current = merged;
		bool takeFromFirst = true;
				
		while (first != null && second != null)
		{
			if (takeFromFirst)
			{
				current.Next = first;
				first = first.Next;
				takeFromFirst = false;
			}
			else
			{
				current.Next = second;
				second = second.Next;
				takeFromFirst = true;
			}
			
			current = current.Next;
		}
		
		if (first != null)
		{
			current.Next = first;
		}
		
		return merged.Next;
	}
}

public static void Interweave(Node node)
{
	if (node == null || node.Next == null)
	{
		return;
	}
	
	// First Find the mid point
	Node mid = NodeUtils.FindMid(node);
	Node firstHalf = node;
	
	// Reverse second half
	Node secondHalf = NodeUtils.Reverse(mid.Next);
	mid.Next = null;
	
	// Merge two lists
	node = NodeUtils.Merge(firstHalf, secondHalf);
}

// Define other methods and classes here
