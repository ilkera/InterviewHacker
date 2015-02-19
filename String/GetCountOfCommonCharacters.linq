<Query Kind="Program" />

void Main()
{
	List<string> words = new List<string> { "aghkafgkit", "dfghako", "qwemnaarkf"};
	GetCountOfCommonCharacters(words).Dump();
}

public static int GetCountOfCommonCharacters(List<string> strList)
{
	Dictionary<char, int> mapCount = new Dictionary<char, int>();
	
	foreach (var str in strList)
	{
		UpdateMapCount(mapCount, GetUniqueChars(str));
	}
	
	int count = 0;
	
	foreach (KeyValuePair<char, int> charMap in mapCount)
	{
		if (charMap.Value == strList.Count)
		{
			count++;
		}
	}
	
	return count;
}

private static string GetUniqueChars(string word)
{
	HashSet<char> allUnique = new HashSet<char>();
	
	foreach (var character in word)
	{
		if (!allUnique.Contains(character))
		{
			allUnique.Add(character);
		}
	}
	
	return new string(allUnique.ToArray());
}

private static void UpdateMapCount(Dictionary<char, int> charMap, string word)
{
	for (int i = 0; i < word.Length; i++)
	{
		if (charMap.ContainsKey(word[i]))
		{
			charMap[word[i]]++;
		}
		else
		{
			charMap.Add(word[i], 1);
		}
	}
}

// Define other methods and classes here
