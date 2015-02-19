<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
	root.NextRight = root.Left;
	
	Connect(root);
	root.Dump();
}

// Works for Perfect Binary tree
public void Connect(TreeNode root)
{
	if (root == null)
	{
		return;
	}
	
	if (root.Left != null)
	{
		root.Left.NextRight = root.Right;
	}
	
	if (root.Right != null)
	{
		root.Right.NextRight = root.NextRight != null ? root.NextRight.Left : null;
	}
	
	Connect(root.Left);
	Connect(root.Right);
}

public class TreeNode
{
	public int Data { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	public TreeNode NextRight { get; set; }
	
	public TreeNode(int data, TreeNode left = null, TreeNode right = null, TreeNode nextRight = null)
	{
		this.Data = data;
		this.Left = left;
		this.Right = right;
		this.NextRight = nextRight;
	}
}

// Define other methods and classes here
