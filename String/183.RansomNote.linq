<Query Kind="Program" />

void Main()
{
	string note = "tag me tea";
	string magazine = "this is a nice magazine so you can create danger";
	
	RansomNote(magazine, note).Dump();
	RansomNote2(magazine, note).Dump();
}

public static bool RansomNote(string magazine, string note)
{
	if (string.IsNullOrEmpty(magazine))
	{
		return string.IsNullOrEmpty(note);
	}
	
	Dictionary<char, int> magMap = new Dictionary<char, int>();
	foreach (var magCharacter in magazine)
	{
		if (magMap.ContainsKey(magCharacter))
		{
			magMap[magCharacter] +=1;
		}
		else
		{
			magMap.Add(magCharacter, 1);
		}
	}
	bool canCreateNote = true;
	
	for (int i = 0; i < note.Length; i++)
	{
		if (!magMap.ContainsKey(note[i]))
		{
			canCreateNote = false;
			break;
		}
		
		magMap[note[i]]--;
		if (magMap[note[i]] < 0)
		{
			canCreateNote = false;
			break;
		}
	}
	
	return canCreateNote;
}

public static bool RansomNote2(string magazine, string note)
{
	if (string.IsNullOrEmpty(magazine))
	{
		return string.IsNullOrEmpty(note);
	}
	
	Dictionary<char, int> magMap = new Dictionary<char, int>();	
	int current_mag = 0;
	bool canCreateNote = true;
	
	for (int i = 0; i < note.Length; i++)
	{
		if (!magMap.ContainsKey(note[i]))
		{
			while (current_mag < magazine.Length && note[i] != magazine[current_mag])
			{
				if (magMap.ContainsKey(magazine[current_mag]))
				{
					magMap[magazine[current_mag]]++;
				}
				else
				{
					magMap.Add(magazine[current_mag], 1);
				}
				current_mag++;
			}
			
			if (current_mag == magazine.Length)
			{
				canCreateNote = false;
				break;
			}
			current_mag++;
		}
		else
		{
			magMap[note[i]]--;
			if (magMap[note[i]] < 0)
			{	
				canCreateNote = false;
				break;
			}
		}
	}
	
	return canCreateNote;
}

// Define other methods and classes here
