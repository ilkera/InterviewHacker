<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(10);
	BinarySearchTreeUtils.Insert(root, 6);
	BinarySearchTreeUtils.Insert(root, 14);
	BinarySearchTreeUtils.Insert(root, 10);
	root.Dump();
}

public class BinarySearchTreeUtils
{
	public static bool Search(TreeNode root, int key)
	{
		if (root == null)
		{
			return false;
		}
		
		if (root.Key == key)
		{
			return true;
		}
		else if (root.Key > key)
		{
			return Search(root.Left, key);
		}
		else
		{
			return Search(root.Right, key);
		}
	}
	
	public static TreeNode Insert(TreeNode root, int key)
	{
		if (root == null)
		{
			return new TreeNode(key);
		}
		
		if (root.Key > key)
		{
			root.Left = Insert(root.Left, key);
		}
		else
		{
			root.Right = Insert(root.Right, key);
		}
		
		return root;
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
