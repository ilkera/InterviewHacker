<Query Kind="Program" />

void Main()
{
	ConvertToBST(new int[] {1}).Dump();
	ConvertToBST(new int[] {1, 2}).Dump();
	ConvertToBST(new int[] {1, 2, 3, 4, 5}).Dump();
}

public static TreeNode ConvertToBST(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return null;
	}
	
	return Converter_Helper(array, 0, array.Length - 1);
}

private static TreeNode Converter_Helper(int[] array, int low, int high)
{
	if (low > high)
	{
		return null;
	}
	
	if (low == high)
	{
		return new TreeNode(array[low]);
	}
	
	int mid = low + (high -low)/2;
	
	TreeNode root = new TreeNode(array[mid]);
	root.Left = Converter_Helper(array, low, mid - 1);
	root.Right = Converter_Helper(array, mid + 1, high);
	
	return root;
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
