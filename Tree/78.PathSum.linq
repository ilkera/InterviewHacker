<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(5, 
						new TreeNode(4, new TreeNode(11, new TreeNode(7),new TreeNode(2))), new TreeNode(8, new TreeNode(13), new TreeNode(4, null, new TreeNode(1))));
	
	HasPathSum(root, 22).Dump();
}

public static bool HasPathSum(TreeNode root, int sum)
{
	if (root == null)
	{
		return false;
	}
	
	return HasPathSumHelper(root, sum, 0);
}

private static bool HasPathSumHelper(TreeNode root, int sum, int current)
{
	if (root == null)
	{
		return false;
	}
	
	current += root.Value;
	
	if (root.Left == null && root.Right == null)
	{
		return current == sum;
	}
	else
	{
		return HasPathSumHelper(root.Left, sum, current) || HasPathSumHelper(root.Right, sum, current);
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
