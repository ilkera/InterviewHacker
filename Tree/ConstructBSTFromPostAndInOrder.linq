<Query Kind="Program" />


void Main()
{
	int[] postArray = {2, 5, 8, 6, 4, 12, 16, 14, 10};
	int[] inArray = {2, 4, 5, 6, 8, 10, 12, 14, 16};
	
	Utils.Construct(postArray, inArray).Dump();
}


public class Utils
{
	private static Dictionary<int, int> mapToIndex;
	
	public static TreeNode Construct(int[] postArray, int[] inArray)
	{
		if (postArray == null || inArray == null)
		{
			return null;
		}
		
		mapToIndex = new Dictionary<int, int>();
		for (int i = 0; i < inArray.Length; i++)
		{
			mapToIndex.Add(inArray[i], i);
		}
		
		TreeNode result = ConstructBSTHelper(postArray, inArray, inArray.Length - 1, 0, inArray.Length - 1);
		
		return result;
	}
	
	private static TreeNode ConstructBSTHelper(int[] postArray, int[] inArray, int rootIndex, int left, int right)
	{
		if (left >= right)
		{
			return new TreeNode(inArray[left]);
		}
		
		TreeNode root = new TreeNode(postArray[rootIndex]);
		int rootIndexAtInArray = mapToIndex[postArray[rootIndex]];
		int rightChildCount =  right - rootIndexAtInArray;
		
		root.Left = ConstructBSTHelper(postArray, inArray, rootIndex - rightChildCount - 1, left, rootIndexAtInArray - 1);
		root.Right = ConstructBSTHelper(postArray, inArray, rootIndex - 1, rootIndexAtInArray + 1, right);
		
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


// Define other methods and classes here
