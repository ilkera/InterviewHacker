<Query Kind="Program" />

void Main()
{
	WordLadderLength("hit","cog", new HashSet<string>() {"hot", "dot","dog","lot", "log"}).Dump();
}

public class WordNode
{
	public string Word { get; set; }
	public int Distance { get; set; }
	
	public WordNode(string word, int distance)
	{
		this.Word = word;
		this.Distance = distance;
	}
}

public static int WordLadderLength(string startWord, string endWord, HashSet<string> dict)
{
	if (dict == null || dict.Count == 0)
	{
		throw new ArgumentNullException("empty dict");
	}
	
	if (string.IsNullOrEmpty(startWord) || 
		string.IsNullOrEmpty(endWord) || 
		startWord == endWord || 
		startWord.Length != endWord.Length)
	{
		return 0;
	}
	
	Queue<WordNode> queue = new Queue<WordNode>();
	queue.Enqueue(new WordNode(startWord, 1));
	Dictionary<string, bool> visited = new Dictionary<string, bool>();
	visited.Add(startWord, true);
	int length = 0;
	
	while (queue.Count != 0)
	{
		WordNode currentNode = queue.Dequeue();
		string word = currentNode.Word;
		int distance = currentNode.Distance;
		
		foreach (var neighbor_word in GetNeighborWords(word, dict))
		{
			if (!visited.ContainsKey(neighbor_word))
			{
				length++;
				if (neighbor_word == endWord)
				{
					return distance + 1;
				}
				
				visited.Add(neighbor_word, true);
				queue.Enqueue(new WordNode(neighbor_word, distance + 1));	
			}
		}
	}
	
	return length;
}

private static IEnumerable<string> GetNeighborWords(string word, HashSet<string> dict)
{
	for (int i = 0; i < word.Length; i++)
	{
		StringBuilder sb = new StringBuilder(word);
		for (char ch = 'a'; ch <= 'z'; ch++)
		{
			if (ch == sb[i])
			{
				break;
			}
			
			sb[i] = ch;
			string temp = sb.ToString();
			if (dict.Contains(temp))
			{
				yield return temp;
			}
		}
	}
	
	yield break;
}

// Define other methods and classes here
