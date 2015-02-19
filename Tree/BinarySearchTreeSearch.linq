<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(8, new TreeNode(6), new TreeNode(11)));
	BinarySearchTreeUtils.Search(root, 4).Dump();
	BinarySearchTreeUtils.Search(root, 2).Dump();
	BinarySearchTreeUtils.Search(root, 1).Dump();
	BinarySearchTreeUtils.Search(root, 3).Dump();
	
	BinarySearchTreeUtils.Search(root, 8).Dump();
	BinarySearchTreeUtils.Search(root, 6).Dump();
	BinarySearchTreeUtils.Search(root, 11).Dump();
	
	BinarySearchTreeUtils.Search(root, 20).Dump();
	BinarySearchTreeUtils.Search(root, 25).Dump();
	
	Console.WriteLine("Iterative ");
	(BinarySearchTreeUtils.Search_Iterative(root, 4).Key == 4).Dump();
	(BinarySearchTreeUtils.Search_Iterative(root, 2).Key == 2).Dump();
	(BinarySearchTreeUtils.Search_Iterative(root, 1).Key == 1).Dump();
	(BinarySearchTreeUtils.Search_Iterative(root, 3).Key == 3).Dump();
	
	(BinarySearchTreeUtils.Search_Iterative(root, 8).Key == 8).Dump();
	(BinarySearchTreeUtils.Search_Iterative(root, 6).Key == 6).Dump();
	(BinarySearchTreeUtils.Search_Iterative(root, 11).Key == 11).Dump();
	
	(BinarySearchTreeUtils.Search_Iterative(root, 20) == null).Dump();
	(BinarySearchTreeUtils.Search_Iterative(root, 25) == null).Dump();
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
	
	public static TreeNode Search_Iterative(TreeNode root, int key)
	{
		TreeNode current = root;
		while (current != null)
		{
			if (current.Key == key)
			{
				return current;
			}
			else if (current.Key > key)
			{
				current = current.Left;
			}
			else
			{
				current = current.Right;
			}
		}
		
		return null;
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
