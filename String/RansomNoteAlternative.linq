<Query Kind="Program" />

void Main()
{
	string note = "tag me tea";
	string magazine = "this is a nice magazine so you can create danger";
	
	CanConstruct(magazine, note).Dump();
	
	CanConstruct("ABCD", "CB").Dump();
	CanConstruct("ABCD", "CBB").Dump(); // FALSE
	
}

public static bool CanConstruct(string mag, string letter)
{
	if (string.IsNullOrEmpty(mag))
	{
		return string.IsNullOrEmpty(letter);
	}
	
	Dictionary<char, int> map = new Dictionary<char, int>();
	int iMag = 0;
	int iLetter = 0;
	
	while (iLetter < letter.Length)
	{
		char current = letter[iLetter];
		
		if (!map.ContainsKey(current) || map[current] == 0)
		{
			while (iMag < mag.Length && mag[iMag] != current)
			{
				if (!map.ContainsKey(mag[iMag]))
				{
					map.Add(mag[iMag], 0);
				}
				++map[mag[iMag]];
				++iMag;
			}
			
			if (iMag == mag.Length)
			{
				return false;
			}
			
			++iMag;
			if (!map.ContainsKey(current))
			{
				map.Add(current, 1);
			}
			else
			{
				++map[current];
			}
		}
		--map[current];
		++iLetter;
	}
	
	return true;
	
}

// Define other methods and classes here
