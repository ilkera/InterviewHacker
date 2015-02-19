<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(0, 
							new TreeNode(1,
									new TreeNode(0,
											new TreeNode(7), 
											new TreeNode(19)),
							new TreeNode(11, new TreeNode(15))),
						new TreeNode(2));
//	root.Dump();
//	SinkZero_BruteForce(root);

	SinkZero(root, new LinkedList<TreeNode>());
	
	root.Dump();
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

public static void SinkZero_BruteForce(TreeNode root)
{
	if (root == null)
	{
		return;
	}
	
	if (root.Value == 0)
	{
		TreeNode nonZero = FindNonZeroNode(root.Left);
		
		if (nonZero == null)
		{
			nonZero = FindNonZeroNode(root.Right);
		}
		
		if (nonZero != null)
		{
			SwapValue(root, nonZero);
		}
	}
	
	SinkZero_BruteForce(root.Left);
	SinkZero_BruteForce(root.Right);
}

private static TreeNode FindNonZeroNode(TreeNode root)
{
	if (root == null)
	{
		return null;
	}
	
	if (root.Value != 0)
	{
		return root;
	}
	
	TreeNode node = FindNonZeroNode(root.Left);
	
	if (node == null)
	{
		node = FindNonZeroNode(root.Right);
	}
	
	return node;
}

public static void SinkZero(TreeNode root, LinkedList<TreeNode> dequeue)
{
	if (root == null)
	{
		return;
	}
	
	if (root.Value == 0)
	{
		dequeue.AddLast(root);
	}
	else
	{
		if (dequeue.Count > 0)
		{
			SwapValue(root, dequeue.First.Value);
			dequeue.RemoveFirst();
			dequeue.AddLast(root);
		}
	}
	
	SinkZero(root.Left, dequeue);
	SinkZero(root.Right, dequeue);
	
	if (dequeue.Count != 0 && dequeue.Last.Value == root)
	{
		dequeue.RemoveLast();
	}
}

private static void SwapValue(TreeNode a, TreeNode b)
{
	int temp = a.Value;
	a.Value = b.Value;
	b.Value = temp;
}

// Define other methods and classes here
