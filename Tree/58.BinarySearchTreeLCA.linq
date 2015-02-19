<Query Kind="Program" />

void Main()
{
	TreeNode root  = new TreeNode(6, new TreeNode(2, new TreeNode(0),new TreeNode(4, new TreeNode(3), new TreeNode(5))), new TreeNode(8, new TreeNode(7), new TreeNode(9)));

	FindLowestCommonAncestor(root, new TreeNode(2), new TreeNode(8)).Value.Dump();
	FindLowestCommonAncestor(root, new TreeNode(2), new TreeNode(4)).Value.Dump();
}

public static TreeNode FindLowestCommonAncestor(TreeNode root, TreeNode first, TreeNode second)
{
	if (root == null || first == null || second == null)
	{
		return null;
	}
	
	TreeNode current = root;
	
	while (current != null)
	{
		if (current.Value > Math.Max(first.Value, second.Value))
		{
			current = current.Left;
		}
		else if (current.Value < Math.Min(first.Value, second.Value))
		{
			current = current.Right;
		}
		else
		{
			break;
		}
	}
	
	return current;
}

public class TreeNode
{
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	public int Value { get; set; }
	
	public TreeNode(int data, TreeNode left = null, TreeNode right = null)
	{
		this.Value = data;
		this.Left = left;
		this.Right = right;
	}
}

// Define other methods and classes here
