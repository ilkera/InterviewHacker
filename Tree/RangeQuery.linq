<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(10,
						new TreeNode(5, new TreeNode(3), new TreeNode(8, new TreeNode(7))), 
						new TreeNode(16, new TreeNode(14), new TreeNode(20)));
						
	BSTUtil.Keys(root, 1, 2).Dump();
	BSTUtil.Keys(root, 1, 5).Dump();
	BSTUtil.Keys(root, 8, 15).Dump();
						
}

public class BSTUtil
{
	public static void Print(TreeNode node)
	{
		if (node == null)
		{
			return;
		}
		
		Print(node.Left);
		Console.Write("{0} ", node.Key);
		Print(node.Right);
	}
	
	public static List<int> Keys(TreeNode root, int low, int high)
	{
		List<int> result = new List<int>();
		
		if (root != null)
		{
			AddRange(root, low, high, result);
		}
		
		return result;
	}
	
	private static void AddRange(TreeNode root, int low, int high, List<int> result)
	{
		if (root == null)
		{
			return;
		}
		
		if (low < root.Key)
		{
			AddRange(root.Left, low, high, result);
		}
		
		if (low <= root.Key && root.Key <= high)
		{
			result.Add(root.Key);
		}
		
		if (high > root.Key)
		{
			AddRange(root.Right, low, high, result);
		}
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
