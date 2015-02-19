<Query Kind="Program" />

void Main()
{
	// 	   1
	//  2	  5
	// 4 6 	10 12
	TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(6)), new TreeNode(5, new TreeNode(10), new TreeNode(12)));
	Console.WriteLine("Recursive");
	Util.PrintLeavesRightToLeft_Recursive(root);
	Console.WriteLine("\n\nIterative");
	Util.PrintLeavesRightToLeft_Iterative(root);
}


public class TreeNode
{
	public int Value { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	public bool Visited { get; set; }
	
	public TreeNode(int value, TreeNode left = null, TreeNode right = null)
	{
		this.Value = value;
		this.Left = left;
		this.Right = right;
	}
}

public class Util
{
	public static void PrintLeavesRightToLeft_Iterative(TreeNode root)
	{
		if(root == null)
		{
			return;
		}
		
		Stack<TreeNode> stack = new Stack<TreeNode>();
		stack.Push(root);
		
		while (stack.Count != 0)
		{
			TreeNode current = stack.Peek();
			
			if (current.Right != null && !current.Visited)
			{
				stack.Push(current.Right);
				current.Visited = true;
			}
			else
			{
				stack.Pop();
				
				if (current.Left == null && current.Right == null)
				{
					Console.Write("{0} ", current.Value);
				}
				
				if (current.Left != null)
				{
					stack.Push(current.Left);
				}
			}
		}
	}
	
	public static void PrintLeavesRightToLeft_Recursive(TreeNode root)
	{
		if (root == null)
		{
			return;
		}
		
		if (root.Left == null && root.Right == null)
		{
			Console.Write("{0} ", root.Value);
		}
		else
		{
			if (root.Right != null)
			{
				PrintLeavesRightToLeft_Recursive(root.Right);
			}
			
			if (root.Left != null)
			{
				PrintLeavesRightToLeft_Recursive(root.Left);
			}
		}
	}
}

// Define other methods and classes here
