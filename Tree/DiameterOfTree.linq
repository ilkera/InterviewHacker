<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));

	TreeUtils.Diameter(root).Dump();

	int height = 0;
	TreeUtils.DiameterOpt(root, ref height).Dump();
}

public class TreeUtils
{
	public static int Diameter(TreeNode root)
	{
		if (root == null)
		{
			return 0;
		}
		
		int leftHeight = Height(root.Left);
		int rightHeight = Height(root.Right);
		
		int leftDiameter = Diameter(root.Left);
		int rightDiameter = Diameter(root.Right);
		
		return Math.Max(leftHeight + rightHeight + 1, Math.Max(leftDiameter, rightDiameter));
	}
	
	public static int DiameterOpt(TreeNode root, ref int height)
	{
		int left_height = 0;
		int right_height = 0;
		int left_diameter = 0;
		int right_diameter = 0;
		
		if (root == null)
		{
			height = 0;
			return 0;
		}
		
		left_diameter = DiameterOpt(root.Left, ref left_height);
		right_diameter = DiameterOpt(root.Right, ref right_height);
		
		height = Math.Max(left_height, right_height) + 1;
		
		return Math.Max(left_height + right_height + 1, Math.Max(left_diameter, right_diameter));
	}
	
	public static int Height(TreeNode root)
	{
		if (root == null)
		{
			return 0;
		}
		
		return 1 + Math.Max(Height(root.Left), Height(root.Right));
	}
	
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
