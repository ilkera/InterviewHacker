<Query Kind="Program" />

void Main()
{
	(Add(null, null) == null).Dump();
	Add(new Node(1, new Node(2, new Node(3))), null).Dump();
	Add(new Node(1, new Node(8)), new Node(9, new Node(2))).Dump();
	Add(new Node(2, new Node(4, new Node(3))), new Node(5, new Node(6, new Node(4)))).Dump();
	Add(new Node(2, new Node(4, new Node(3))), new Node(5, new Node(6, new Node(6)))).Dump();
}

public static Node Add(Node first, Node second)
{
	if (first == null && second == null)
	{
		return null;
	}
	
	if (first == null || second == null)
	{
		return first == null ? second : first;
	}
	
	Node result = new Node(0);
	
	Node current_result = result;
	Node current_first = first;
	Node current_second = second;
	int carry = 0;
	int current_sum = 0;
	
	while (current_first != null || current_second != null)
	{
		if (current_first != null && current_second != null)
		{
		    current_sum = current_first.Data + current_second.Data + carry;
			current_first = current_first.Next;
			current_second = current_second.Next;
		}
		else if (current_first != null)
		{
			current_sum = current_first.Data + carry;
			current_first = current_first.Next;
		}
		else
		{
			current_sum = current_second.Data + carry;
			current_second = current_first.Next;
		}
		
		current_result.Next = new Node(current_sum % 10);
		carry = current_sum / 10;
		current_result = current_result.Next;
	}
	
	if (carry > 0)
	{
		current_result.Next = new Node(carry);
	}
	
	return result.Next;
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
