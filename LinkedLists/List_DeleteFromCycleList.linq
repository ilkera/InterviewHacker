<Query Kind="Program" />

void Main()
{
	Node empty = null;
	
	(ListUtils.DeleteFromCycleList(empty, 3) == null).Dump();
	
	// only one item and target is the head
	Node root = new Node(3);
	root.Next = root;
	
	(ListUtils.DeleteFromCycleList(root, 3) == null).Dump();
	
	root = new Node(0);
	Node list = new Node(1, new Node(2, new Node(3, new Node(4, root))));
	root.Next = list;
	
	// when key is not there
	root = ListUtils.DeleteFromCycleList(root, 11).Dump();
	
	// delete the last key 
	root = ListUtils.DeleteFromCycleList(root, 4).Dump();
	
	// delete the first key 
	root = ListUtils.DeleteFromCycleList(root, 0).Dump();
	
	// delete the mid key 
	root = ListUtils.DeleteFromCycleList(root, 3).Dump();
	
	// duplicates
	root = new Node(3);
	list = new Node(1, new Node(3, new Node(3, new Node(4, root))));
	root.Next = list;
	
	root = ListUtils.DeleteFromCycleList(root, 3).Dump();
	
}

public class ListUtils
{
	public static Node DeleteFromCycleList(Node list, int key)
	{
		// when list is empty/null or wen there is only one item which is the target
		if (list == null || (list.Next == list && list.Data == key))
		{
			return null;
		}
			
		while (list.Data == key)
		{
			list = list.Next;
		}
		
		Node current = list;
		
		while (current != null && current.Next != list)
		{
			if (current.Next.Data == key)
			{
				current.Next = current.Next.Next;
			}
			else
			{
				current = current.Next;
			}
		}
		
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
