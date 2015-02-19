<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(1, new TreeNode(2,new TreeNode(4), new TreeNode(5)), new TreeNode(3));
	
	GetAllPaths(root).Dump();
}

public static List<List<int>> GetAllPaths(TreeNode root)
{
	if (root == null)
	{
		return null;
	}
	
	List<List<int>> result = new List<List<int>>();
	
	GetRootToLeafPath(root, new List<int>(), result);
	
	return result;
}

private static void GetRootToLeafPath(TreeNode root, List<int> currentPath, List<List<int>> result)
{
	if (root == null)
	{
		return;
	}
	
	currentPath.Add(root.Value);
	if (root.Left == null && root.Right == null)
	{
		result.Add(new List<int>(currentPath));
		return;
	}

	GetRootToLeafPath(root.Left, currentPath, result);
	currentPath.RemoveAt(currentPath.Count - 1);
	GetRootToLeafPath(root.Right, currentPath, result);
	currentPath.RemoveAt(currentPath.Count - 1);
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
