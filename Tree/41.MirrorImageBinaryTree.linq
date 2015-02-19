<Query Kind="Program" />

void Main()
{
	TreeNode first = new TreeNode(5, new TreeNode(6, new TreeNode(7), new TreeNode(8)), new TreeNode(9,null, new TreeNode(10)));
	TreeNode second = new TreeNode(5, new TreeNode(9, new TreeNode(10)), new TreeNode(6, new TreeNode(8), new TreeNode(7)));
	
	TreeUtils.IsMirror(first, second).Dump();
}


public class TreeUtils
{
	public static bool IsMirror(TreeNode first, TreeNode second)
	{
		if (first == null && second == null)
		{
			return true;
		}
		
		if (first == null || second == null || first.Data != second.Data)
		{
			return false;
		}
		
		return IsMirror(first.Left, second.Right) && IsMirror(first.Right, second.Left);
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
