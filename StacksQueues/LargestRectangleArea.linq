<Query Kind="Program" />

void Main()
{
	FindLargestRectangleArea(new int[] {2,1,5,6,2,3}).Dump();
	FindLargestRectangleArea_v2(new int[] {2,1,5,6,2,3}).Dump();
	FindLargestRectangleArea_v3(new int[] {2,1,5,6,2,3}).Dump();
}

public static int FindLargestRectangleArea(int[] height)
{
	Stack<int> stack = new Stack<int>();
	int maxArea = 0;
	
	for (int i = 0; i <= height.Length; i++)
	{
		while(stack.Count != 0 && (i == height.Length || height[i] < height[stack.Peek()]))
		{
			int currentHeight = height[stack.Pop()];
			maxArea = Math.Max(maxArea, currentHeight * (stack.Count == 0 ? i : i - stack.Peek() - 1));
		}
		stack.Push(i);
	}
	
	return maxArea;
}
public static int FindLargestRectangleArea_v2(int[] height)
{
	int maxArea = 0;
	
	for (int i = 0; i < height.Length; i++)
	{
		int minHeight = height[i];
		
		for (int j = i; j >= 0; j--)
		{
			minHeight = Math.Min(minHeight, height[j]);
			int area = minHeight * (i - j + 1);
			maxArea = Math.Max(area, maxArea);
		}
	}
	
	return maxArea;
}

public static int FindLargestRectangleArea_v3(int[] height)
{
	int maxArea = 0;
	
	for (int i = 0; i < height.Length; i++)
	{
		if (i + 1 < height.Length && height[i] <= height[i+1])
		{
			continue;
		}
		
		int minHeight = height[i];
		
		for (int j = i; j >= 0; j--)
		{	
			minHeight = Math.Min(minHeight, height[j]);
			int area = minHeight * (i - j + 1);
			maxArea = Math.Max(area, maxArea);
		}
	}
	
	return maxArea;
}


// Define other methods and classes here