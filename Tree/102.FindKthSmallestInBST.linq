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
							
	int smallest = 1;
	Util.FindKthSmallestInBST_Recursive(root, ref smallest);
	Util.FindKthSmallestInBST_Iterative_Faster(root,0).Dump();
	Util.FindKthSmallestInBST_Iterative_Faster(root,1).Value.Dump();
	Util.FindKthSmallestInBST_Iterative_Faster(root,6).Value.Dump();
	Util.FindKthSmallestInBST_Iterative_Faster(root,5).Value.Dump();
	Util.FindKthSmallestInBST_Iterative_Faster(root,9).Value.Dump();
	Util.FindKthSmallestInBST_Iterative_Faster(root,10).Value.Dump();
	Util.FindKthSmallestInBST_Iterative_Faster(root,11).Dump();
	
}

public static class Util
{
	// Via Inorder traversal => O(n)
	public static void FindKthSmallestInBST_Recursive(TreeNode root, ref int k)
	{
		if (root == null || k < 0)
		{
			return;
		}
		
		FindKthSmallestInBST_Recursive(root.Left, ref k);
		k--;
		
		if (k == 0)
		{
			Console.WriteLine("Smallest " + root.Value);
			return;
		}
		
		FindKthSmallestInBST_Recursive(root.Right, ref k);
	}
	
	public static TreeNode FindKthSmallestInBST_Iterative_Faster(TreeNode root, int k)
	{
		if (root == null || k <= 0)
		{
			return null;
		}
		
		TreeNode current = root;
		int sizeOfLeftSubTree = 0;
		int count = k;
		
		while (current != null)
		{
			sizeOfLeftSubTree = current.Left != null ? current.Left.Size() : 0;
			
			if (sizeOfLeftSubTree + 1 == count)
			{
				return current;
			}
			else if (sizeOfLeftSubTree < count)
			{
				current = current.Right;
				count -= (sizeOfLeftSubTree + 1);
			}
			else
			{
				current = current.Left;
			}
		}
		
		return null;
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
