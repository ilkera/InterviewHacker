<Query Kind="Program" />

void Main()
{

	/*
					6
			2					8
		0		  4			7		9
	 #	 #		3	5	#	 #	  #	   #	
			   # #  # #
	*/
	TreeNode root  = new TreeNode(6,
			new TreeNode(2, new TreeNode(0),new TreeNode(4, new TreeNode(3), new TreeNode(5))), 
			new TreeNode(8, new TreeNode(7), new TreeNode(9)));
	List<string> serialized = Serialize(root);
	
	serialized.Dump();
	
	Deserialize(serialized).Dump();
	
}

public static TreeNode Deserialize(List<string> serialized)
{
	if (serialized == null || serialized.Count < 1)
	{
		return null;
	}
	int index = 0;
	TreeNode root = DeserializeHelper(serialized, ref index);
	
	return root;
}

private static TreeNode DeserializeHelper(List<string> serialized,ref int index)
{
	if (index > serialized.Count || serialized[index] == "#")
	{
		return null;
	}
	
	TreeNode root = new TreeNode(Convert.ToInt32(serialized[index]));
	index++;
	root.Left = DeserializeHelper(serialized, ref index);
	index++;
	root.Right = DeserializeHelper(serialized, ref index);
	
	return root;
}

public static List<string> Serialize(TreeNode root)
{	
	List<string> output = new List<string>();
	
	SerializeHelper(root, output);
	
	return output;
}

private static void SerializeHelper(TreeNode root, List<string> output)
{
	if (root == null)
	{
		output.Add("#");
		return;
	}
	
	output.Add(root.Value.ToString());
	SerializeHelper(root.Left, output);
	SerializeHelper(root.Right, output);
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
