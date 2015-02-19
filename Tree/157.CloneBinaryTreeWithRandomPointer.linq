<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(1,
				new TreeNode(2, 
						new TreeNode(4), 
						new TreeNode(5)),
				new TreeNode(3, 
						new TreeNode(6),
						new TreeNode(9)));
						
						
	root.Random = root.Left.Left; // 1 -4
	root.Left.Random = root.Right; // 2 - 3
	root.Right.Random = root.Left; // 3 - 2
	root.Left.Left.Random = root.Right.Left; // 4 - 6
	root.Left.Right.Random = root.Right.Right; // 5 - 9
	root.Right.Left.Random = root.Left.Right; // 6 - 5 
	root.Right.Right.Random = root.Left.Left; // 9 - 4
	
	TreeNode clone = Util.CloneBinaryTreeWithRandom(root);
	
	assertEqual(root.Random.Key, clone.Random.Key);
	assertEqual(root.Left.Random.Key, root.Right.Key);
	assertEqual(root.Right.Random.Key, root.Left.Key);
	assertEqual(root.Left.Left.Random.Key, root.Right.Left.Key);
	assertEqual(root.Left.Right.Random.Key, root.Right.Right.Key);
	assertEqual(root.Right.Left.Random.Key, root.Left.Right.Key);
	assertEqual(root.Right.Right.Random.Key, root.Left.Left.Key);
	
//	clone.Dump();
}

public static void assertEqual(int a, int b)
{
	Console.WriteLine("{0}", a==b);
}

public class Util
{
	public static TreeNode CloneBinaryTreeWithRandom(TreeNode root)
	{
		if (root == null)
		{
			return null;
		}
		
		Dictionary<TreeNode, TreeNode> mapNode = new Dictionary<TreeNode, TreeNode>();
		
		TreeNode cloneTree = CopyLeftRightNode(root, mapNode);
		CopyRandom(root, cloneTree, mapNode);
		
		return cloneTree;
	}
	
	private static void CopyRandom(TreeNode root, TreeNode clone, Dictionary<TreeNode, TreeNode> mapNode)
	{
		if (root == null)
		{
			return;
		}
			
		clone.Random = mapNode[root.Random];
		
		CopyRandom(root.Left, clone.Left, mapNode);
		CopyRandom(root.Right, clone.Right, mapNode);
	}
	
	private static TreeNode CopyLeftRightNode(TreeNode root, Dictionary<TreeNode, TreeNode> mapNode)
	{
		if (root == null)
		{
			return null;
		}
		
		TreeNode cloneNode = new TreeNode(root.Key);
		mapNode.Add(root, cloneNode);
		cloneNode.Left = CopyLeftRightNode(root.Left, mapNode);
		cloneNode.Right = CopyLeftRightNode(root.Right, mapNode);
		
		return cloneNode;
	}
}

public class TreeNode
{	
	public int Key { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	public TreeNode Random { get; set; }
	
	public TreeNode(int key, TreeNode left = null, TreeNode right = null, TreeNode random = null)
	{
		this.Key = key;
		this.Left = left;
		this.Right = right;
		this.Random = random;
	}
}

// Define other methods and classes here
