<Query Kind="Program" />

void Main()
{
	HashSet<string> dict = new HashSet<string>();
	dict.Add("hi");
	dict.Add("go");
	
	Dictionary<string, List<string>> near_by_chars = new Dictionary<string, List<string>>();
	near_by_chars.Add("g", new List<string>() {"g", "h", "f"});
	near_by_chars.Add("i", new List<string>() {"i", "o", "k"});
	
	NearByWords words = new NearByWords(dict, near_by_chars);
	words.FindNearbyWords("gi").Dump();
}

public class NearByWords
{
	private HashSet<string> dict;
	private Dictionary<string, List<string>> nearby_chars;
	
	public NearByWords(HashSet<string> dict, Dictionary<string, List<string>> nearby_chars)
	{
		this.dict = dict;
		this.nearby_chars = nearby_chars;
	}
	
	public List<string> FindNearbyWords(string str)
	{
		List<string> nearByWords = new List<string>();
		
		if (!string.IsNullOrEmpty(str))
		{
			// Find all permutations of near by letters
			//List<string> permutations = FindNearByWordsHelper(str);
			List<string> permutations = FindNearByWordsHelper_v2(str, 0);
			
			// Filter the ones which are not word
			FilterByWord(permutations, nearByWords);
		}
		
		return nearByWords;
	}
	
	private void FilterByWord(List<string> permutations, List<string> result)
	{
		foreach (var permutation in permutations)
		{
			if (this.IsWord(permutation))
			{
				result.Add(permutation);
			}
		}
	}
	
	private List<string> FindNearByWordsHelper(string str)
	{
		if (str.Length <= 1)
		{
			return new List<string>(GetNearbyChars(str));
		}
		
		string first_char = str[0].ToString();
		List<string> remaining_nearby_permutations = FindNearByWordsHelper(str.Substring(1));
		List<string> near_by_permutations = new List<string>();
				
		foreach (var near_by_letter in GetNearbyChars(first_char))
		{
			foreach (var remaining_nearby_permutation in remaining_nearby_permutations)
			{
				string permuation = near_by_letter + remaining_nearby_permutation;
				near_by_permutations.Add(permuation);
			}
		}
		
		return near_by_permutations;
	}
	
	private List<string> FindNearByWordsHelper_v2(string str, int index)
	{
		if (index == str.Length - 1)
		{
			return new List<string>(GetNearbyChars(str[index].ToString()));
		}
		
		string first_char = str[index].ToString();
		List<string> remaining_nearby_permutations = FindNearByWordsHelper_v2(str, index + 1);
		List<string> near_by_permutations = new List<string>();
		
		foreach (var near_by_letter in GetNearbyChars(first_char))
		{
			foreach (var remaining_nearby_permutation in remaining_nearby_permutations)
			{
				string permuation = near_by_letter + remaining_nearby_permutation;
				near_by_permutations.Add(permuation);
			}
		}
		
		return near_by_permutations;
	}
	
	private List<string> GetNearbyChars(string ch)
	{
		if (!this.nearby_chars.ContainsKey(ch))
		{
			return new List<string>();
		}
		
		return this.nearby_chars[ch];
	}
	
	private bool IsWord(string str)
	{
		return this.dict.Contains(str);
	}
}

// Define other methods and classes here
