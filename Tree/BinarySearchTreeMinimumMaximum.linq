<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(8, new TreeNode(6), new TreeNode(11)));
	BinarySearchTreeUtils.Min(root).Dump();
	BinarySearchTreeUtils.Max(root).Dump();
}

public class BinarySearchTreeUtils
{
	public static TreeNode Min(TreeNode root)
	{
		if (root == null)
		{
			return null;
		}
		
		if (root.Left == null)
		{
			return root;
		}
		
		return Min(root.Left);
	}
	
	public static TreeNode Max(TreeNode root)
	{
		if (root == null)
		{
			return null;
		}
		
		if(root.Right == null)
		{
			return root;
		}
		
		return Max(root.Right);
	}
}

public class TreeNode
{
	private int size;
	
	public int Key { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	
	public int Size
	{
		get
		{
			int leftSize = this.Left != null ? this.Left.Size : 0;
			int rightSize = this.Right != null ? this.Right.Size : 0;
			
			size = 1 + leftSize + rightSize;
			
			return size;
		}
	}
	
	public TreeNode(int key, TreeNode left = null, TreeNode right = null)
	{
		this.Key = key;
		this.Left = left;
		this.Right = right;
	}
}

// Define other methods and classes here
