<Query Kind="Program" />

void Main()
{
	TreeNode test1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
	TreeNode test2 = new TreeNode(1, new TreeNode(2, new TreeNode(4)), new TreeNode(3));
	TreeNode test3 = new TreeNode(1, new TreeNode(2, new TreeNode(4, new TreeNode(5))), new TreeNode(3));
	
	Util.SuperBalanced(test1).Dump();
	Util.SuperBalanced(test2).Dump();
	Util.SuperBalanced(test3).Dump();
}

public class Util
{
	public static bool SuperBalanced(TreeNode root)
	{
		List<int> depths = new List<int>();
		Stack<Tuple<TreeNode, int>> nodes = new Stack<Tuple<TreeNode, int>>();
		nodes.Push(new Tuple<TreeNode,int>(root, 0));
		
		while (nodes.Count != 0)
		{
			TreeNode currentNode = nodes.Peek().Item1;
			int currentDepth = nodes.Peek().Item2;
			nodes.Pop();
			
			if (currentNode.Left == null && currentNode.Right == null)
			{
				if (!depths.Contains(currentDepth))
				{
					depths.Add(currentDepth);
					
					if (depths.Count > 2 || (depths.Count == 2 && Math.Abs(depths[0] - depths[1]) > 1))
					{
						return false;
					}
				}
			}
			
			if (currentNode.Left != null)
			{
				nodes.Push(new Tuple<TreeNode, int>(currentNode.Left, currentDepth + 1));
			}
			
			if (currentNode.Right != null)
			{
				nodes.Push(new Tuple<TreeNode, int>(currentNode.Right, currentDepth + 1));
			}
			
		}
		
		return true;
	}
	
	public static bool SuperBalanced_Recursive(TreeNode root)
	{
		if (root == null)
		{
			return true;
		}
		
		int leftDepth = MaxDepth(root.Left);
		int rightDepth = MaxDepth(root.Right);
		
		return Math.Abs(leftDepth - rightDepth) < 2;
	}
	
	public static int MaxDepth(TreeNode root)
	{
		if (root == null)
		{
			return 0;
		}
		
		return 1 + Math.Max(MaxDepth(root.Left), MaxDepth(root.Right));
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
