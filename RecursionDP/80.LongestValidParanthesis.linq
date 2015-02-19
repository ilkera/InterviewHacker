<Query Kind="Program" />

void Main()
{
	FindLongestValidParenthesisLength(")()())").Dump();
	FindLongestValidParenthesisLength("((())()))").Dump();
}

public static int FindLongestValidParenthesisLength(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		return 0;
	}
	
	Stack<int> stack = new Stack<int>();
	int maxLen = 0;
	int last = -1;
	
	for (int i = 0; i < str.Length; i++)
	{
		if (str[i] == '(')
		{
			stack.Push(i);
		}
		else
		{
			if (stack.Count == 0)
			{
				last = i;
			}
			else
			{
				stack.Pop();
				
				if (stack.Count == 0)
				{
					maxLen = Math.Max(maxLen, i - last);
				}
				else
				{
					maxLen = Math.Max(maxLen, i - stack.Peek());
				}
			}
		}
	}
	
	return maxLen;
}

// Define other methods and classes here
