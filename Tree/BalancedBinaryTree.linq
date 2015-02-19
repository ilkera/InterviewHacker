<Query Kind="Program" />

void Main()
{
	(Utils.GetHeight(null) == 0).Dump();
	(Utils.GetHeight(new TreeNode(1)) == 1).Dump();
	(Utils.GetHeight(new TreeNode(1, new TreeNode(2))) == 2).Dump();
	(Utils.GetHeight(new TreeNode(1, new TreeNode(2), new TreeNode(3))) == 2).Dump();
	(Utils.GetHeight(new TreeNode(1, new TreeNode(2, new TreeNode(4)), new TreeNode(3))) == 3).Dump();
	(Utils.GetHeight(new TreeNode(1, null, new TreeNode(2, null, new TreeNode(3, null, new TreeNode(4, null, new TreeNode(5)))))) == 5).Dump();
	
	Console.WriteLine("\nIs Balanced");
	(Utils.IsBalanced(null) == true).Dump();
	(Utils.IsBalanced(new TreeNode(1)) == true).Dump();
	(Utils.IsBalanced(new TreeNode(1, new TreeNode(2))) == true).Dump();
	(Utils.IsBalanced(new TreeNode(1, new TreeNode(2), new TreeNode(3))) == true).Dump();
	(Utils.IsBalanced(new TreeNode(1, new TreeNode(2, new TreeNode(4)), new TreeNode(3))) == true).Dump();
	
	// Invalid
	(Utils.IsBalanced(new TreeNode(1, new TreeNode(2, new TreeNode(4, null, new TreeNode(8))), new TreeNode(3))) == false).Dump();
	(Utils.IsBalanced(new TreeNode(1, null, new TreeNode(2, null, new TreeNode(3, null, new TreeNode(4, null, new TreeNode(5)))))) == false).Dump();
	
}

public class Utils
{
	public static int GetHeight(TreeNode root)
	{
		if (root == null)
		{
			return 0;
		}
		
		return 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right)); 
	}
	
	public static bool IsBalanced(TreeNode root)
	{
		if (root == null)
		{
			return true;
		}
		
		int leftHeight = GetHeight(root.Left);
		int rightHeight = GetHeight(root.Right);
		
		return Math.Abs(leftHeight-rightHeight) < 2;
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
