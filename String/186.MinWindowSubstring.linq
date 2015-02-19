<Query Kind="Program" />

void Main()
{
	MinWindowString("ADOBECODEBANC", "ABC").Dump();
}

public static int MinWindowString(string haystack, string needle)
{
	if (string.IsNullOrEmpty(haystack) || string.IsNullOrEmpty(needle))
	{
		return 0;
	}
	
	HashSet<char> charsNeeded = new HashSet<char>(needle.ToCharArray());
	Dictionary<LinkedListNode<char>, int> indexMap = new Dictionary<LinkedListNode<char>, int>();
	Dictionary<char, LinkedListNode<char>> charMap = new Dictionary<char, LinkedListNode<char>>();
	
	int minWindow = int.MaxValue;
	for (int i = 0; i < haystack.Length; i++)
	{
		if (charsNeeded.Contains(haystack[i]))
		{
			if (charMap.ContainsKey(haystack[i]))
			{
				indexMap.Remove(charMap[haystack[i]]);
				indexMap.Add(new LinkedListNode<char>(haystack[i]), i);
				
				if (indexMap.Count == charsNeeded.Count)
				{
					int window = indexMap.Values.Max() - indexMap.Values.Min() + 1;
					minWindow = Math.Min(window, minWindow);
				}
			}
			else
			{
				LinkedListNode<char> newNode = new LinkedListNode<char>(haystack[i]);
				charMap.Add(haystack[i], newNode);
				indexMap.Add(newNode, i);
			}
		}
	}
	
	return minWindow;
}

// Define other methods and classes here
