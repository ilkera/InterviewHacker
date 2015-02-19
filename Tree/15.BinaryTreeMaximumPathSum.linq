<Query Kind="Program" />

void Main()
{
	Console.WriteLine("Test 1");
	Util.FindMaxPathSum(new TreeNode(-10, new TreeNode(5, new TreeNode(2), new TreeNode(7)), new TreeNode(7))).Dump();
	
	Console.WriteLine("Test 2");
	Util.FindMaxPathSum(new TreeNode(-8, 
							new TreeNode(7, 
									new TreeNode(10, new TreeNode(-17), new TreeNode(-20)), new TreeNode(5, null, new TreeNode(-5))),
							new TreeNode(4, new TreeNode(1), new TreeNode(2)))).Dump();
	
	Console.WriteLine("Test 3");						
	Util.FindMaxPathSum(new TreeNode(5, new TreeNode(-8), new TreeNode(-10))).Dump();
}


public class Util
{
	public static int FindMaxPathSum(TreeNode root)
	{
		if (root == null)
		{
			return 0;
		}
		
		int max = 0;
		
		FindMaxPathSum_Helper(root, ref max);
		
		return max;
	}
	
	public static int FindMaxPathSum_Helper(TreeNode root, ref int maxSoFar)
	{
		if (root == null)
		{
			return int.MinValue;
		}
		
		int left_Sum = FindMaxPathSum_Helper(root.Left, ref maxSoFar);
		int right_Sum = FindMaxPathSum_Helper(root.Right, ref maxSoFar);
		
		int node_only = root.Value;
		int node_with_left = left_Sum != int.MinValue ? left_Sum + node_only : node_only;
		int node_with_right = right_Sum != int.MinValue ? right_Sum + node_only: node_only;
		int node_with_left_and_right = node_with_left + node_with_right - node_only;
		
		int current_max = Math.Max(node_only, Math.Max(node_with_left_and_right, Math.Max(node_with_left, node_with_right)));
		
		maxSoFar = Math.Max(current_max, maxSoFar);
		
		return current_max;
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
