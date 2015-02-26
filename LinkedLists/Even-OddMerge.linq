<Query Kind="Program" />

void Main()
{
	Print(EvenOddMerge(new Node(0)));
	Print(EvenOddMerge(new Node(0, new Node(1))));
	Print(EvenOddMerge(new Node(0, new Node(1, new Node(2)))));
	Print(EvenOddMerge(new Node(0, new Node(1, new Node(2, new Node(3))))));
	Print(EvenOddMerge(new Node(0, new Node(1, new Node(2, new Node(3, new Node(4)))))));
	Print(EvenOddMerge(new Node(0, new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))))));
	Print(EvenOddMerge(new Node(0, new Node(1, new Node(2, new Node(3, new Node(4, new Node(5, new Node(6)))))))));
}

private static void Print(Node node)
{
	Node current = node;
	
	while (current != null)
	{
		Console.Write("{0} -", current.Data);
		current = current.Next;
	}
	Console.WriteLine("");
}

public static Node EvenOddMerge(Node head)
{
	if (head == null || head.Next == null)
	{
		return head;
	}
	
	Node even = head;
	Node oddStart = head.Next;
	Node odd = head.Next;
	
	while (even != null && even.Next != null && odd != null && odd.Next != null)
	{
		even.Next = even.Next.Next;
		odd.Next = odd.Next.Next;
		even = even.Next;
		odd = odd.Next;
	}
	
	if (even != null && even.Next != null)
	{
		even.Next = even.Next.Next;
	}
	
	Node evenEnd = head;
	while (evenEnd.Next != null)
	{
		evenEnd = evenEnd.Next;
	}
	
	evenEnd.Next = oddStart;
	
	return head;
}

public class Node
{	
	public Node(int data, Node next = null )
	{
		this.Data = data;
		this.Next = next;
	}
	
	public int Data { get; set; }
	public Node Next { get; set; }
}

// Define other methods and classes here
