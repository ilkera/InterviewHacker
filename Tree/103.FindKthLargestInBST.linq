<Query Kind="Program" />

void Main()
{
	// 	      5	
	// 	  3		    10
	// 	2   4  	  8		 12
	// 1			   11	14
	
	TreeNode root = new TreeNode(5,
							new TreeNode(3, new TreeNode(2, new TreeNode(1)), new TreeNode(4)), 
							new TreeNode(10, new TreeNode(8), new TreeNode(12, new TreeNode(11), new TreeNode(14))));
							
	Util.FindKThLargestItemInBST_Recursive(root, 1);
	Util.FindKThLargestItemInBST_Recursive(root, 7);
	Util.FindKthLargestInBST_Iterative_Faster(root,1).Value.Dump();
	Util.FindKthLargestInBST_Iterative_Faster(root,7).Value.Dump();
	
}
public static class Util
{
	public static TreeNode FindKthLargestInBST_Iterative_Faster(TreeNode root, int k)
	{
		if (root == null || k <= 0)
		{
			return null;
		}
		
		TreeNode current = root;
		int sizeOfRightSubTree = 0;
		int count = k;
		
		while (current != null)
		{
			sizeOfRightSubTree = current.Right != null ? current.Right.Size() : 0;
			
			if (sizeOfRightSubTree + 1 == count)
			{
				return current;
			}
			else if (sizeOfRightSubTree < count)
			{
				current = current.Left;
				count -= (sizeOfRightSubTree + 1);
			}
			else
			{
				current = current.Right;
			}
		}
		
		return null;
	}
	
	public static void FindKThLargestItemInBST_Recursive(TreeNode root, int k)
	{
		if (root == null || k <= 0)
		{
			return;
		}
		
		int current = 0;
		
		FindKThLargestItemInBST_Recursive_Helper(root, k, ref current);
	}
	
	private static void FindKThLargestItemInBST_Recursive_Helper(TreeNode root, int k, ref int index)
	{
		if (root == null)
		{
			return;
		}
		
		FindKThLargestItemInBST_Recursive_Helper(root.Right, k, ref index);
		index++;
		if (index == k)
		{
			Console.WriteLine("{0}th largest {1}", k, root.Value);
			return;
		}
		
		FindKThLargestItemInBST_Recursive_Helper(root.Left, k, ref index);
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
	
	public int Size()
	{
		int leftSize = 0;
		int rightSize = 0;
		
		if (this.Left != null)
		{
			leftSize = this.Left.Size();
		}
		
		if (this.Right != null)
		{
			rightSize = this.Right.Size();
		}
		
		return 1 + leftSize + rightSize;
	}
}

// Define other methods and classes here
