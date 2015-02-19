<Query Kind="Program" />

void Main()
{
	BuildWordCloud("We came, we saw, we ate cake.").Dump();
	BuildWordCloud("Friends, Romans, countrymen! Let us eat cake.").Dump();
	BuildWordCloud("New tourists in New York often wait in long lines for cronuts.").Dump();
   	BuildWordCloud("We came, we saw, we conquered...then we ate Bill's (Mille-Feuille) cake.").Dump();
	BuildWordCloud("This is a test and test is my task").Dump();
	BuildWordCloud("This is a test, and test is my task.").Dump();
	BuildWordCloud("Add milk and eggs, then add flour and sugar.").Dump();
	BuildWordCloud("After beating the eggs, Dana read the next step:").Dump();
}

public static Dictionary<string, int> BuildWordCloud(string sentence)
{
	Dictionary<string, int> word_cloud = new Dictionary<string, int>();
	
	if (!string.IsNullOrEmpty(sentence))
	{
		List<string> words = Split(sentence);
		
		foreach (var word in words)
		{
			string key = word.ToLower();
			
			if (!word_cloud.ContainsKey(key))
			{
				word_cloud.Add(key, 0);
			}
			word_cloud[key] += 1;
		}
	}
	
	return word_cloud;
}

private static List<string> Split(string sentence)
{
	List<string> words = new List<string>();
	
	int current = 0;
	StringBuilder currentWord = new StringBuilder();
	
	while (current <= sentence.Length)
	{
		if (current == sentence.Length || sentence[current] == ' ')
		{
			words.Add(currentWord.ToString());
			currentWord.Clear();
		}
		else if (char.IsLetter(sentence[current]))
		{
			currentWord.Append(sentence[current]);			
		}
		current++;
	}
	
	return words;
}

// Define other methods and classes here