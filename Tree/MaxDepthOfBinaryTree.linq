<Query Kind="Program" />

void Main()
{
		TreeNode root  = new TreeNode(6,
			new TreeNode(2, new TreeNode(0),new TreeNode(4, new TreeNode(3), new TreeNode(5))), 
			new TreeNode(8, new TreeNode(7), new TreeNode(9)));
			
		FindMaxDepth(root).Dump();
}

public static int FindMaxDepth(TreeNode root)
{
	if (root == null)
	{
		return 0;
	}
	
	int leftDepth = FindMaxDepth(root.Left);
	int rightDepth = FindMaxDepth(root.Right);
	
	return 1 + Math.Max(leftDepth, rightDepth);
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
