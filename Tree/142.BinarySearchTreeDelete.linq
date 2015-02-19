<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(8, new TreeNode(6), new TreeNode(11)));
	BinarySearchTreeUtils.Delete(root, 4);
	root.Dump();
	
	BinarySearchTreeUtils.Delete(root, 1);
	root.Dump();
}

public class BinarySearchTreeUtils
{
	public static TreeNode Delete(TreeNode root, int key)
	{
		if (root == null)
		{
			return root;
		}
		
		if (root.Key > key)
		{
			root.Left = Delete(root.Left, key);
		}
		else if (root.Key < key)
		{
			root.Right = Delete(root.Right, key);
		}
		else
		{
			// node with only one or no child
			if (root.Left == null)
			{
				return root.Right;
			}
			else if (root.Right == null)
			{
				return root.Left;
			}
			
			// node with both children
			TreeNode successor = BinarySearchTreeUtils.Min(root.Right);
			root.Key = successor.Key;
			root.Right = Delete(root.Right, successor.Key);
		}
		
		return root;
	}
	
	public static TreeNode Min(TreeNode root)
	{
		if (root == null)
		{
			return root;
		}
		
		if (root.Left == null)
		{
			return root;
		}
		
		return Min(root.Left);
	}
}

public class TreeNode
{	
	public int Key { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	
	public TreeNode(int key, TreeNode left = null, TreeNode right = null)
	{
		this.Key = key;
		this.Left = left;
		this.Right = right;
	}
}

// Define other methods and classes here