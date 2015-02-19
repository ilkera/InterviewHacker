<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(5, 
						new TreeNode(4, new TreeNode(11, new TreeNode(7),new TreeNode(2))), new TreeNode(8, new TreeNode(13), new TreeNode(4, new TreeNode(5), new TreeNode(1))));

	FindAllPaths(root, 22).Dump();
}

public static List<List<int>> FindAllPaths(TreeNode root, int target)
{
	List<List<int>> result = new List<List<int>>();
	
	if (root != null)
	{
		FindAllPathHelper(root, 0, target, new List<int>(), result);
	}
	
	return result;
}

private static void FindAllPathHelper(TreeNode root, int currentSum, int target, List<int> solution, List<List<int>> result)
{
	solution.Add(root.Value);
	currentSum += root.Value;
	
	if (currentSum == target && root.Left == null && root.Right == null)
	{
		result.Add(new List<int>(solution));
	}
	else
	{
		if (root.Left != null)
		{
			FindAllPathHelper(root.Left, currentSum, target, solution, result);
		}
		
		if (root.Right != null)
		{
			FindAllPathHelper(root.Right, currentSum, target, solution, result);
		}
	}
	
	solution.RemoveAt(solution.Count - 1);
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
