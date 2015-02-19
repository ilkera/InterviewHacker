<Query Kind="Program" />

void Main()
{
	TreeNode test1 = new TreeNode(5, new TreeNode(2), new TreeNode(12, new TreeNode(8), new TreeNode(20)));
	TreeNode test2 = new TreeNode(5, new TreeNode(2), new TreeNode(12, new TreeNode(8), new TreeNode(20, new TreeNode(15, new TreeNode(14), new TreeNode(17)))));
	
	Utils.FindSecondLargest(test1).Data.Dump();
	Utils.FindSecondLargest(test2).Data.Dump();
}

public class Utils
{

	public static TreeNode FindSecondLargest(TreeNode root)
	{
		if (root == null)
		{
			return null;
		}
		
		TreeNode current = root;
		
		while (current != null)
		{
			if (current.Right == null && current.Left != null)
			{
				// current is the largest
				return FindLargest(current.Left);
			}			
			
			if (current.Right != null && current.Right.Left == null && current.Right.Right == null)
			{
				return current;
			}
			
			current = current.Right;
		}
		
		return current;
	}

	public static TreeNode FindLargest(TreeNode root)
	{		
		TreeNode current = root;
		while (current != null)
		{
			if (current.Right != null)
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
}

public class TreeNode
{
	public int Data { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	
	public TreeNode(int data, TreeNode left = null, TreeNode right = null)
	{
		this.Data = data;
		this.Left = left;
		this.Right = right;
	}
}
// Define other methods and classes here
