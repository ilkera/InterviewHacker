<Query Kind="Program" />

void Main()
{
	int[] preArray = {10, 4, 2, 6, 5, 8, 14, 12, 16};
	int[] inArray = {2, 4, 5, 6, 8, 10, 12, 14, 16};
	
	Utils.Construct(preArray, inArray).Dump();
}


public class Utils
{
	private static Dictionary<int, int> mapToIndex;
	
	public static TreeNode Construct(int[] preArray, int[] inArray)
	{
		if (preArray == null || inArray == null)
		{
			return null;
		}
		
		mapToIndex = new Dictionary<int, int>();
		for (int i = 0; i < inArray.Length; i++)
		{
			mapToIndex.Add(inArray[i], i);
		}
		
		TreeNode result = ConstructBSTHelper(preArray, inArray, 0, 0, inArray.Length - 1);
		
		return result;
	}
	
	private static TreeNode ConstructBSTHelper(int[] preArray, int[] inArray, int rootIndex, int left, int right)
	{
		if (left >= right)
		{
			return new TreeNode(inArray[left]);
		}
		
		TreeNode root = new TreeNode(preArray[rootIndex]);
		int rootIndexAtInArray = mapToIndex[preArray[rootIndex]];
		int leftChildCount = rootIndexAtInArray - left;
		root.Left = ConstructBSTHelper(preArray, inArray, rootIndex + 1, left, rootIndexAtInArray - 1);
		root.Right = ConstructBSTHelper(preArray, inArray, rootIndex + leftChildCount + 1, rootIndexAtInArray + 1, right);
		
		return root;
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
