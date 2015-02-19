<Query Kind="Program" />

void Main()
{
	// insert into empty
	Node empty = null;
	ListUtils.InsertIntoSortedCyclicList(empty, 1).Dump();
	
	// insert into one item list
	Node oneItem = new Node(1);
	oneItem.Next = oneItem;
	ListUtils.InsertIntoSortedCyclicList(oneItem, 2).Dump();
	
	oneItem = new Node(2);
	oneItem.Next = oneItem;
	ListUtils.InsertIntoSortedCyclicList(oneItem, 1).Dump();
		
	// insert min
	Node root = new Node(3);
	Node list = new Node(4, new Node(5, new Node(6, root)));
	root.Next = list;
	
	ListUtils.InsertIntoSortedCyclicList(oneItem, 2).Dump();
	
	
	// insert mid
	
	// insert max
}


public class ListUtils
{
	public static Node InsertIntoSortedCyclicList(Node list, int item)
	{
		if (list == null)
		{
			list = new Node(item);
			list.Next = list;
			
			return list;
		}
		
		Node current = list;
		Node previous = null;
		
	
		Node newNode = new Node(item);
		newNode.Next = current;
		previous.Next = current;
		
		return list;
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
