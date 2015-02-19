<Query Kind="Program" />

void Main()
{
	GetLongestConsecutiveSequence(new int[] {4, 100, 1, 3, 200, 2}).Dump();
}

public static int GetLongestConsecutiveSequence(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return 0;
	}
	
	Dictionary<int, int> map = new Dictionary<int, int>();
	
	for (int i = 0; i < array.Length; i++)
	{
		map.Add(array[i], i);
	}
	
 	int[] sequenceLength = new int[array.Length];
	
	for (int i = 0; i < array.Length; i++)
	{
		if (sequenceLength[i] > 0)
		{
			continue;
		}
		
		sequenceLength[i] = GetConsecutiveSequenceLength(array[i], map, sequenceLength);
	}
	
	int longest = int.MinValue;
	
	for (int i = 0; i < sequenceLength.Length; i++)
	{
		longest = Math.Max(sequenceLength[i], longest);
	}

	return longest;
}

private static int GetConsecutiveSequenceLength(int number, Dictionary<int, int> map, int[] sequenceLength)
{
	if(!map.ContainsKey(number))
	{
		return 0;
	}
	
	int index = map[number];
	
	if (sequenceLength[index] == 0)
	{
		sequenceLength[index] = 1 + GetConsecutiveSequenceLength(number - 1, map, sequenceLength);
	}
	
	return sequenceLength[index];
}

// Define other methods and classes here
