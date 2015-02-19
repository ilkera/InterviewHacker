<Query Kind="Program" />

void Main()
{
	/*
			1
		2		3
		
		After Flatten
		
		1
			2
				3
	*/
	TreeNode root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
	Util.Flatten(root);
	
	TreeNode singleItem = new TreeNode(1);
	Util.Flatten(singleItem);
	
	TreeNode skewedTreeToRight = new TreeNode(1, null, new TreeNode(2, null, new TreeNode(3, null, new TreeNode(4, null, new TreeNode(5)))));
	Util.Flatten(skewedTreeToRight);
	
	TreeNode skewedTreeToLeft = new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4, new TreeNode(5)))));
	Util.Flatten(skewedTreeToLeft);
	skewedTreeToLeft.Dump();
}

public class Util
{
	public static void Flatten(TreeNode root)
	{
		if (root == null)
		{
			return;
		}
	
		TreeNode temp = root.Right;
		Flatten(root.Left);
		Flatten(root.Right);	
	
		root.Right = root.Left;
		
		if (root.Left != null)
		{
			root.Left.Right = temp;
			root.Left = null;	
		}
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