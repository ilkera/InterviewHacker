<Query Kind="Program" />

void Main()
{
	GetLetterCombinations("43").Dump();
}

public static List<string> GetLetterCombinations(string digits)
{
	string[] letters = {"","", "abc","def","ghi","jkl","mno","pqrs","tuv","wxyz"};
	
	List<string> result = new List<string>();
	
	Generate(letters, digits, new StringBuilder(), 0, result);
	
	return result;
}

private static void Generate(
		string[] letters, 
		string digits,
		StringBuilder currentSequence,
		int index,
		List<string> result)
{
	if (index == digits.Length)
	{
		result.Add(currentSequence.ToString());
		return;
	}
	
	int currentDigit = Convert.ToInt32(digits[index]) - 48;

	for (int i = 0; i < letters[currentDigit].Length; i++)
	{
		currentSequence.Append(letters[currentDigit][i]);
		
		Generate(letters, digits, currentSequence, index + 1, result);
		
		currentSequence.Remove(currentSequence.Length - 1, 1);
	}
}

// Define other methods and classes here
