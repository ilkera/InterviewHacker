<Query Kind="Program" />

void Main()
{
	Node list = null;
	
	NodeUtils.Insert(ref list, 5);
	
	list.Dump();
	
	NodeUtils.Insert(ref list, 1); // min
	
	list.Dump();
	
	NodeUtils.Insert(ref list, 10); // max
	
	list.Dump();
	
	NodeUtils.Insert(ref list, 7); // middle
			
	list.Dump();
	
	NodeUtils.Insert(ref list, 7); // middle dup
			
	list.Dump();
	
	NodeUtils.Insert(ref list, 10); // max dup
	
	list.Dump();
	
	NodeUtils.Insert(ref list, 1); // min dup
	
	list.Dump();
}

public static class NodeUtils
{
	public static void Insert(ref Node aNode, int item)
	{
		if (aNode == null)
		{
			aNode = new Node(item);
			aNode.Next = aNode;
			return;
		}
		
		Node current = aNode;
		Node previous = null;
		
		do
		{
			previous = current;
			current = current.Next;
			
			if (item <= current.Data && item >= previous.Data)
			{	
				break;
			}
			
			if ((previous.Data > current.Data) && (item < current.Data || item > previous.Data))
			{	
				break;
			}
			
		}while(current != aNode);
				
		Node newNode = new Node(item, current);
		previous.Next = newNode;
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
