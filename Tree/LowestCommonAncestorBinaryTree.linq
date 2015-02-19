<Query Kind="Program" />

void Main()
{
	// 		3
	// 	  2  	5
	// 1	  4    6	
	TreeNode root = new TreeNode(3, 
							new TreeNode(2, new TreeNode(1)),
							new TreeNode(5, new TreeNode(4),new TreeNode(6)),
							null /* parent */);
							
	root.Left.Parent = root;
	root.Left.Left.Parent = root.Left;
	
	root.Right.Parent = root;
	root.Right.Left.Parent =root.Right;
	root.Right.Right.Parent = root.Right;
			
	Console.WriteLine("No parent");
	Utils.LCA_NoParent(root, root.Left, root.Right).Value.Dump();
	Utils.LCA_NoParent(root, root.Right.Left, root.Right.Right).Value.Dump();
	Utils.LCA_NoParent(root, root.Right, root.Right.Right).Value.Dump();
	
	Console.WriteLine("With parent");
	Utils.LCA_WithParent(root, root.Left, root.Right).Value.Dump();
	Utils.LCA_WithParent(root, root.Right.Left, root.Right.Right).Value.Dump();
	Utils.LCA_WithParent(root, root.Right, root.Right.Right).Value.Dump();
	
	Console.WriteLine("With parent - optimized ");
	Utils.LCA_WithParentOptimized(root, root.Left, root.Right).Value.Dump();
	Utils.LCA_WithParentOptimized(root, root.Right.Left, root.Right.Right).Value.Dump();
	Utils.LCA_WithParentOptimized(root, root.Right, root.Right.Right).Value.Dump();
	
}

public class Utils
{
	public static TreeNode LCA_NoParent(TreeNode root, TreeNode a, TreeNode b)
	{
		if (root == null)
		{
			return null;
		}
		
		if (root == a || root == b)
		{
			return root;
		}
		
		TreeNode leftRes = LCA_NoParent(root.Left, a, b);
		TreeNode rightRes = LCA_NoParent(root.Right, a, b);
		
		if (leftRes != null && rightRes != null)
		{
			return root;
		}
		else
		{
			return leftRes != null ? leftRes : rightRes;
		}	
	}
	
	public static TreeNode LCA_WithParent(TreeNode root, TreeNode a, TreeNode b)
	{
		if (root == null)
		{
			return null;
		}
		
		int depthA = GetDepth(a);
		int depthB = GetDepth(b);
		
		if (depthB > depthA)
		{
			TreeNode temp = a;
			a = b;
			b = temp;
		}
		
		int depthDiff = Math.Abs(depthA - depthB);
		while (depthDiff-- > 0)
		{
			a = a.Parent;
		}
		
		while (a != b)
		{
			a = a.Parent;
			b = b.Parent;
		}
		
		return a;
	}
	
	public static TreeNode LCA_WithParentOptimized(TreeNode root, TreeNode a, TreeNode b)
	{
		if (root == null)
		{
			return root;
		}
		
		HashSet<TreeNode> seen = new HashSet<TreeNode>();
		
		while (a != null || b != null)
		{
			if (a != null)
			{	
				if (!seen.Add(a))
				{
					return a;
				}
				else
				{
					a = a.Parent;
				}
			}
			
			if (b != null)
			{
				if (!seen.Add(b))
				{
					return b;
				}
				else
				{
					b = b.Parent;
				}	
			}
		}
		
		return null; // a and b not in the same tree
	}
	
	private static int GetDepth(TreeNode root)
	{
		int depth = 0;
		
		while (root != null)
		{
			depth++;
			root = root.Parent;
		}
		
		return depth;
	}
}

public class TreeNode
{
	public int Value { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	public TreeNode Parent { get; set; }
	
	public TreeNode(int value, TreeNode left = null, TreeNode right = null, TreeNode parent = null)
	{
		this.Value = value;
		this.Left = left;
		this.Right = right;
		this.Parent = parent;
	}
}

// Define other methods and classes here
