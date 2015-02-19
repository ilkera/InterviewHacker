<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, new TreeNode(6), new TreeNode(7)));
	Console.WriteLine("Recursive");
	Util.PostOrderTraversal_Recursive(root);
	Console.WriteLine("\n\nIterative");
	Util.PostOrderTraversal_Iterative(root);
}

public class Util
{
	public static void PostOrderTraversal_Iterative(TreeNode root)
	{
		List<TreeNode> preOrder = PreOrderTraversal_Inverted(root);
		preOrder.Reverse();
		
		foreach (var node in preOrder)
		{
			Console.Write("{0} ", node.Value);
		}
		Console.WriteLine("");
	}
	
	private static List<TreeNode> PreOrderTraversal_Inverted(TreeNode root)
	{
		List<TreeNode> result = new List<TreeNode>();
		
		if (root != null)
		{
			Stack<TreeNode> stack = new Stack<TreeNode>();
			stack.Push(root);
			
			while (stack.Count != 0)
			{
				TreeNode current = stack.Pop();
				result.Add(current);
				
				if (current.Left != null)
				{
					stack.Push(current.Left);
				}
				
				if (current.Right != null)
				{
					stack.Push(current.Right);
				}
			}
		}
		
		return result;
	}
	
	public static void PostOrderTraversal_Recursive(TreeNode root)
	{
		if (root == null)
		{
			return;
		}
		
		PostOrderTraversal_Recursive(root.Left);
		PostOrderTraversal_Recursive(root.Right);
		Console.Write(root.Value + " ");
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
