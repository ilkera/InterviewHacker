<Query Kind="Program" />

void Main()
{
	Util.PreOrder_Recursive(new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3)));	
	Console.WriteLine("");
	Util.PreOrder_Iterative(new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3)));	
}

public class Util
{
	public static void PreOrder_Iterative(TreeNode root)
	{
		if (root == null)
		{
			return;
		}
		
		Stack<TreeNode> stack = new Stack<TreeNode>();
		stack.Push(root);
		
		while (stack.Count != 0)
		{
			TreeNode current = stack.Pop();
			
			Console.Write("{0} - ", current.Value);
			
			if (current.Right != null)
			{
				stack.Push(current.Right);
			}
			
			if (current.Left != null)
			{
				stack.Push(current.Left);
			}
		}
	}
	public static void PreOrder_Recursive(TreeNode root)
	{
		if (root == null)
		{
			return;
		}
		
		Console.Write ("{0} - ", root.Value);
		
		PreOrder_Recursive(root.Left);
		PreOrder_Recursive(root.Right);
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
