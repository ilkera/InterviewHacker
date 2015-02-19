<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(1,
						new TreeNode(2, new TreeNode(4), new TreeNode(5)),
						new TreeNode(3, new TreeNode(6, null,new TreeNode(8)), new TreeNode(7, null, new TreeNode(9))));
	
	PrintVerticalOrder(root);
}

public static void PrintVerticalOrder(TreeNode root)
{
	if (root == null)
	{
		return;
	}
	
	Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
	VerticalOrderTraversal(root, 0, map);
	
	foreach (var element in map.OrderBy(hd => hd.Key).ToList())
	{
		foreach (var item in element.Value)
		{
			Console.Write("{0} ", item);
		}
		Console.WriteLine("");
	}
}

private static void VerticalOrderTraversal(TreeNode root, int hd, Dictionary<int, List<int>> map)
{
	if (root == null)
	{
		return;
	}
	
	if (!map.ContainsKey(hd))
	{
		map.Add(hd, new List<int>());
	}
	
	map[hd].Add(root.Key);
	
	VerticalOrderTraversal(root.Left, hd - 1, map);
	VerticalOrderTraversal(root.Right, hd + 1, map);
}

public class TreeNode
{	
	public int Key { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	
	public TreeNode(int key, TreeNode left = null, TreeNode right = null)
	{
		this.Key = key;
		this.Left = left;
		this.Right = right;
	}
}

// Define other methods and classes here
