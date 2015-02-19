<Query Kind="Program" />

void Main()
{
	Console.WriteLine("Regular tree");
	Util.Level_Order_Traversal(
			new TreeNode(1, 
				new TreeNode(2, new TreeNode(4), new TreeNode(5)),
				new TreeNode(3, new TreeNode(6), new TreeNode(7))));
			
	Console.WriteLine("\nNull root");
	Util.Level_Order_Traversal(null);
	
	Console.WriteLine("\nOne item");
	Util.Level_Order_Traversal(new TreeNode(1));
	
	Console.WriteLine("\nOnly two children");
	Util.Level_Order_Traversal(new TreeNode(1, new TreeNode(2), new TreeNode(3)));
}

public class Util
{
	public static void Level_Order_Traversal(TreeNode root)
	{
		if (root == null)
		{	
			return;
		}
		
		Queue<TreeNode> queue = new Queue<TreeNode>();
		queue.Enqueue(root);
		queue.Enqueue(null);
		
		while (queue.Count != 0)
		{
			TreeNode current = queue.Dequeue();
			
			if (current == null)
			{
				Console.WriteLine("");
				
				if (queue.Count == 0)
				{
					break;
				}
				
				queue.Enqueue(null);	
				continue;
			}
			
			Console.Write("{0} ", current.Value);
			
			if (current.Left != null)
			{
				queue.Enqueue(current.Left);
			}
			
			if (current.Right != null)
			{
				queue.Enqueue(current.Right);
			}	
		}
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
