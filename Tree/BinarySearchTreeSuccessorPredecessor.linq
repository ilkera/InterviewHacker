<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(4,
					new TreeNode(2, new TreeNode(1), new TreeNode(3)),
					new TreeNode(8, new TreeNode(6), new TreeNode(11)), null);
					
	root.Left.Parent = root;
	root.Right.Parent = root;
	
	root.Left.Left.Parent = root.Left;
	root.Left.Right.Parent = root.Left;
	
	root.Right.Left.Parent = root.Right;
	root.Right.Right.Parent = root.Right;
	
	Console.WriteLine("Successor");
	BinarySearchTreeUtils.Successor(root).Key.Dump();
	BinarySearchTreeUtils.Successor(root.Left.Left).Key.Dump();
	
	Console.WriteLine("Predecessor");
	BinarySearchTreeUtils.Predecessor(root).Key.Dump();
	BinarySearchTreeUtils.Predecessor(root.Right.Left).Key.Dump();
}

public class BinarySearchTreeUtils
{
	public static TreeNode Predecessor(TreeNode node)
	{
		if (node == null)
		{
			return null;
		}
		
		if (node.Left != null)
		{
			return BinarySearchTreeUtils.Max(node.Left);
		}
		else
		{
			TreeNode predecessor = node.Parent;
			TreeNode current = node;
			
			while (predecessor != null && predecessor.Left == current)
			{
				current = predecessor;
				predecessor = predecessor.Parent;
			}
			
			return predecessor;
		}
	}
	
	public static TreeNode Successor(TreeNode node)
	{
		if (node == null)
		{
			return null;
		}
		
		// Case 1 - Node has a right subtree
		if (node.Right != null)
		{
			return BinarySearchTreeUtils.Min(node.Right);
		}
		else 
		{
			TreeNode successor = node.Parent;
			TreeNode current = node;
			
			while (successor != null && successor.Right == current)
			{
				current = successor;
				successor = successor.Parent;
			}
			
			return successor;
		}
	}
	
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
	public TreeNode Parent { get; set; }
	
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
	
	public TreeNode(int key, TreeNode left = null, TreeNode right = null, TreeNode parent =  null)
	{
		this.Key = key;
		this.Left = left;
		this.Right = right;
		this.Parent = parent;
	}
}

// Define other methods and classes here
