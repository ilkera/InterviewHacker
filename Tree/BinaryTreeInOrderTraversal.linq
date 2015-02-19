<Query Kind="Program" />

void Main()
{
	/*
				1
		2			3
	4		5
	
	*/
	Util.InOrder_Recursive(new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3)));	
	Console.WriteLine("");
	Util.InOrder_Iterative(new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3)));	
}

public class Util
{
	public static void InOrder_Iterative(TreeNode root)
	{
		if (root == null)
		{
			return;
		}
		
		TreeNode current = root;
		Stack<TreeNode> stack = new Stack<TreeNode>();
		
		while (stack.Count != 0 || current != null)
		{
			if (current != null)
			{
				stack.Push(current);
				current = current.Left;
			}
			else
			{
				current = stack.Pop();
				Console.Write("{0} - ", current.Value);
				current = current.Right;
			}
		}
	}
	public static void InOrder_Recursive(TreeNode root)
	{
		if (root == null)
		{
			return;
		}
		
		InOrder_Recursive(root.Left);
		Console.Write("{0} - ", root.Value);
		InOrder_Recursive(root.Right);
	}
}

public class TreeNode
{
	public int Value { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	
	public TreeNode(int value, TreeNode left = null, TreeNode right = null)
	{
		this.Value = value;
		this.Left = left;
		this.Right = right;
	}
}

// Define other methods and classes here
