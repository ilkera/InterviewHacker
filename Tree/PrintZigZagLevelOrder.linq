<Query Kind="Program" />

void Main()
{
	// 	   1
	//  2	  5
	// 4 6 	10 12
	TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(6)), new TreeNode(5, new TreeNode(10), new TreeNode(12)));
	Util.PrintZigzagLevelOrder(root);
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

public class Util
{
	public static void PrintZigzagLevelOrder(TreeNode root)
	{
		if (root == null)
		{
			return;
		}
		
		Stack<TreeNode> currentLevel = new Stack<TreeNode>();
		Stack<TreeNode> nextLevel = new Stack<TreeNode>();
		bool leftToRight = true;
		
		currentLevel.Push(root);
		
		while (currentLevel.Count != 0)
		{
			TreeNode current = currentLevel.Pop();
			Console.Write("{0} ", current.Value);
			
			if (leftToRight)
			{
				if (current.Left != null)
				{
					nextLevel.Push(current.Left);				
				}

				if (current.Right != null)
				{
					nextLevel.Push(current.Right);	
				}				
			}
			else
			{
				if (current.Right != null)
				{
					nextLevel.Push(current.Right);
				}
				
				if (current.Left != null)
				{
					nextLevel.Push(current.Left);				
				}
			}
			
			if (currentLevel.Count == 0)
			{
				Console.WriteLine("");
				Swap(ref currentLevel, ref nextLevel);
				leftToRight = !leftToRight;
			}
			
		}
	}
	
	private static void Swap(ref Stack<TreeNode> a, ref Stack<TreeNode> b)
	{
		Stack<TreeNode> temp = a;
		a = b;
		b = temp;
	}
}

// Define other methods and classes here
