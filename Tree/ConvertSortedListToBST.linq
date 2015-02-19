<Query Kind="Program" />

void Main()
{
	Node test = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))));
	
	ConvertSortedListToBST(test).Dump();
}

public static TreeNode ConvertSortedListToBST(Node head)
{
	if (head == null)
	{
		return null;
	}
	
	int length = Utils.GetLength(head);
	
	return BuildBST(ref head, 0, length - 1);
}

private static TreeNode BuildBST(ref Node head, int start , int end)
{
	if (start > end)
	{
		return null;
	}
	
	int mid = start + (end - start)/2;
	TreeNode left = BuildBST(ref head, start, mid - 1);
	TreeNode root = new TreeNode(head.Data, left);
	head = head.Next;
	root.Right = BuildBST(ref head, mid + 1, end);
	
	return root;
}

public class Utils
{
	public static int GetLength(Node head)
	{
		if (head == null)
		{
			return 0;
		}
		
		Node current = head;
		int length = 0;
		
		while (current != null)
		{
			length++;
			current = current.Next;
		}
		
		return length;
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

public class TreeNode
{
	public int Data { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	
	public TreeNode(int data, TreeNode left = null, TreeNode right = null)
	{
		this.Data = data;
		this.Left = left;
		this.Right = right;
	}
}


// Define other methods and classes here
