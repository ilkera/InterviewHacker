<Query Kind="Program" />

void Main()
{
	// [1, 3, 5]
	// [2, 11]
	
	WordDistance w1 = new WordDistance(new List<string> {"I","am","a","good","girl"});
	(w1.FindDistance("I","good") == 3).Dump();
	(w1.FindDistance("I","am") == 1).Dump();
	(w1.FindDistance("I","girl") == 4).Dump();
	
	(w1.FindDistance("I","hello") == -1).Dump();
	(w1.FindDistance("hello","am") == -1).Dump();
	(w1.FindDistance("hello","hello") == -1).Dump();
	
	(w1.FindDistance("good","I") == 3).Dump();
	(w1.FindDistance("good","a") == 1).Dump();
	(w1.FindDistance("girl","good") == 1).Dump();
	
	WordDistance w2 = new WordDistance(new List<string> {"hello", "how", "are", "hello","you"});
	(w2.FindDistance("hello","you") == 1).Dump();
	
	WordDistance w3 = new WordDistance(new List<string> {"the", "quick", "brown", "fox","quick"});
	(w3.FindDistance("fox","the") == 3).Dump();
}

public class WordDistance
{
	private Dictionary<string, List<int>> wordPosition;
	
	public WordDistance(List<string> words)
	{
		wordPosition = new Dictionary<string, List<int>>();	
		
		this.ConstructWordPositions(words);
	}
	
	public int FindDistance(string first, string second)
	{
		if (!this.ContainsWord(first) || !this.ContainsWord(second))
		{
			return -1;
		}
		
		int shortestDistance = this.FindShortestDistance(this.wordPosition[first], this.wordPosition[second]);
		
		return shortestDistance;
	}
	
	private bool ContainsWord(string word)
	{
		return this.wordPosition.ContainsKey(word);
	}
	
	private void ConstructWordPositions(List<string> words)
	{
		for (int i = 0; i < words.Count; i++)
		{
			if (!this.wordPosition.ContainsKey(words[i]))
			{
				this.wordPosition.Add(words[i], new List<int>());
			}
			this.wordPosition[words[i]].Add(i+1);
		}
	}
	
	private int FindShortestDistance(List<int> positionsA, List<int> positionsB)
	{
		int minDistance = int.MaxValue;
		
		foreach (var element in positionsA)
		{
			int closestValue = BinarySearchUtils.SearchClosest(positionsB, element);
			
			if (Math.Abs(closestValue-element) < minDistance)
			{
				minDistance = Math.Abs(closestValue-element);
			}	
		}
		
		return minDistance;
	}
}

public class BinarySearchUtils
{
	public static int SearchClosest(List<int> array, int target)
	{
		if (array == null || array.Count < 1)
		{
			return 0;
		}
		
		int low = 0;
		int high= array.Count - 1;
		int minDiff = int.MaxValue;
		int closest = 0;
		
		while (low <= high)
		{
			int mid = low + (high-low)/2;
			
			if (target == array[mid])
			{
				return target;
			}
			else
			{
				if (Math.Abs(array[mid] - target) <= minDiff)
				{
					minDiff = Math.Abs(array[mid] - target);
					closest = array[mid];
				}
				
				if (array[mid] < target)
				{
					low = mid + 1;
				}
				else
				{
					high = mid - 1;
				}
			}
		}
		
		return closest;
	}
}

// Define other methods and classes here
