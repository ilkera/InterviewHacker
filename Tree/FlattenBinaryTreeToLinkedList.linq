<Query Kind="Program" />

void Main()
{
	TreeNode tree = new TreeNode(1, new TreeNode(2, new TreeNode(3), new TreeNode(4)), new TreeNode(5, null, new TreeNode(6)));
	
//tree.Dump();
	
	Flatten(tree);
	
	tree.Dump();
}

public static void Flatten(TreeNode root)
{
	if (root == null)
	{
		return;
	}
	
	Stack<TreeNode> stack = new TreeNode<TreeNode>();
	TreeNode current =  root;
	
	while (current != null || stack.Count != 0)
	{
		if (current.Right != null)
		{
			stack.Push(current.Right);
		}
		
		if (current.Left != null)
		{
			current.Right = current.Left;
			current.Left = null;
		}
		else if (stack.Count != 0)
		{
			TreeNode temp = stack.Pop();
			current.Right = temp;
		}
		
		current = current.Right;
	}
}

public static void Flatten_Recursive(TreeNode root)
{
	if (root == null)
	{
		return;
	}
	
	if (root.Left != null)
	{
		Flatten(root.Left);
		
		TreeNode flattened = root.Left;
		flattened.Right = root.Right;
		root.Right = flattened;
		root.Left = null;
	}
	
	if (root.Right != null)
	{
		Flatten(root.Right);
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
