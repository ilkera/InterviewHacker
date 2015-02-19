<Query Kind="Program" />

void Main()
{
	(ListUtils.IsPalindrome(null) == true).Dump();
	(ListUtils.IsPalindrome(new Node(1)) == true).Dump();
	(ListUtils.IsPalindrome(new Node(1, new Node(2))) == false).Dump();
	(ListUtils.IsPalindrome(new Node(1, new Node(1))) == true).Dump();
	(ListUtils.IsPalindrome(new Node(1, new Node(2, new Node(1)))) == true).Dump();
	(ListUtils.IsPalindrome(new Node(1, new Node(2, new Node(3)))) == false).Dump();
	(ListUtils.IsPalindrome(new Node(1, new Node(2, new Node(3, new Node(2, new Node(1)))))) == true).Dump();
	(ListUtils.IsPalindrome(new Node(1, new Node(2, new Node(3, new Node(3, new Node(2, new Node(1))))))) == true).Dump();

	Console.WriteLine("Via recursion \n");
	(ListUtils.IsPalindrome_v2(null) == true).Dump();
	(ListUtils.IsPalindrome_v2(new Node(1)) == true).Dump();
	(ListUtils.IsPalindrome_v2(new Node(1, new Node(2))) == false).Dump();
	(ListUtils.IsPalindrome_v2(new Node(1, new Node(1))) == true).Dump();
	(ListUtils.IsPalindrome_v2(new Node(1, new Node(2, new Node(1)))) == true).Dump();
	(ListUtils.IsPalindrome_v2(new Node(1, new Node(2, new Node(3)))) == false).Dump();
	(ListUtils.IsPalindrome_v2(new Node(1, new Node(2, new Node(3, new Node(2, new Node(1)))))) == true).Dump();
	(ListUtils.IsPalindrome_v2(new Node(1, new Node(2, new Node(3, new Node(3, new Node(2, new Node(1))))))) == true).Dump();

}

public class ListUtils
{
	public static bool IsPalindrome(Node head)
	{
		if (head == null || head.Next == null)
		{
			return true;
		}
		
		Stack<int> reversed = new Stack<int>();
		
		Node current = head;
		while (current != null)
		{
			reversed.Push(current.Data);
			current = current.Next;
		}
		
		current = head;
		while (current != null)
		{
			if (current.Data != reversed.Pop())
			{
				return false;
			}
			current = current.Next;
		}
		
		return true;
	}
	
	public static bool IsPalindrome_v2(Node head)
	{
		if (head == null || head.Next == null)
		{
			return true;
		}
		
		// Find the mid node
		Node mid = ListUtils.FindMid(head);
		
		if (mid.Next == null)
		{
			return head.Data == mid.Data;
		}
		
		// Reverse the right half
		Node rightHead = ListUtils.Reverse(mid.Next);
		
		// Compare Lists
		bool isPalindrome = CompareLists(head, rightHead);
		
		// Reconstruct 
		mid.Next = ListUtils.Reverse(rightHead);
		
		return isPalindrome;
	}
	
	private static bool CompareLists(Node left, Node right)
	{
		while (right != null)
		{
			if (right.Data != left.Data)
			{	
				return false;
			}
			
			right = right.Next;
			left = left.Next;
		}
		
		return true;
	}
	
	private static Node FindMid(Node head)
	{
		Node faster = head;
		Node slower = head;
		
		while (faster != null && faster.Next != null)
		{
			faster = faster.Next.Next;
			slower = slower.Next;
		}
		
		return slower;
	}
	
	private static Node Reverse(Node head)
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
