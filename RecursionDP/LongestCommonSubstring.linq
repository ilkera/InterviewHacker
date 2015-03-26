<Query Kind="Program" />

void Main()
{
	LongestCommonSubstring_Naive("ACAR", "DASHCAR").Dump();
	LongestCommonSubstring_Naive("NOCOMMON", "YES").Dump();

	LongestCommonSubstringLength("ACAR", "DASHCAR").Dump();
	LongestCommonSubstringLength("NOCOMMON", "YES").Dump();

	LongestCommonSubstring("ACAR", "DASHCAR").Dump();
	LongestCommonSubstring("NOCOMMON", "YES").Dump();


}

public static string LongestCommonSubstring_Naive(string s1, string s2)
{
	if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
	{
		return null;
	}
	
	int longestBegin = -1;
	int longestEnd = -1;
	int maxLen = int.MinValue;
	
	for (int left = 0; left < s1.Length; left++)
	{
		for (int right = left; right < s1.Length; right++)
		{
			string substring = s1.Substring(left, right - left + 1);
			if (s2.Contains(substring))
			{
				if (substring.Length > maxLen)
				{
					maxLen = substring.Length;
					longestBegin = left;
					longestEnd = right;
				}
			}
		}
	}
	
	if (longestBegin != -1 && longestEnd != -1)
	{
		return s1.Substring(longestBegin, longestEnd - longestBegin + 1);
	}
	
	return null;
}

public static string LongestCommonSubstring(string s1, string s2)
{
	if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
	{
		return null;
	}
	
	int[,] scoreTable = new int[s1.Length, s2.Length];
	int maxLen = 0;
	int longestBegin = -1;
	int longestEnd = -1;
	
	for (int iFirst = 0; iFirst < s1.Length; iFirst++)
	{
		for (int iSecond = 0; iSecond < s2.Length; iSecond++)
		{
			if (s1[iFirst] != s2[iSecond])
			{
				continue;
			}
			else
			{
				if (iFirst == 0 || iSecond == 0)
				{
					scoreTable[iFirst, iSecond] = 1;
				}
				else
				{
					scoreTable[iFirst, iSecond] = scoreTable[iFirst - 1, iSecond - 1] + 1;
				}
				
				if (scoreTable[iFirst, iSecond] > maxLen)
				{
					maxLen = scoreTable[iFirst, iSecond];
					int thisSubBegin = iFirst - scoreTable[iFirst, iSecond] + 1;
					
					if (thisSubBegin == longestBegin)
					{
						longestEnd = iFirst;
					}
					else
					{
						longestBegin = thisSubBegin;
					}
				}
			}
		}
	}
	
	if (longestBegin == -1 && longestEnd == -1)
	{
		return null;
	}
	
	return s1.Substring(longestBegin, longestEnd - longestBegin + 1);
}


public static int LongestCommonSubstringLength(string s1, string s2)
{
	if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
	{
		return 0;
	}
	
	int[,] scoreTable = new int[s1.Length, s2.Length];
	int maxLen = 0;
	
	for (int iFirst = 0; iFirst < s1.Length; iFirst++)
	{
		for (int iSecond = 0; iSecond < s2.Length; iSecond++)
		{
			if (s1[iFirst] != s2[iSecond])
			{
				continue;
			}
			else
			{
				if ( iFirst == 0 || iSecond == 0)
				{
					scoreTable[iFirst, iSecond] = 1;
				}
				else
				{
					scoreTable[iFirst, iSecond] = scoreTable[iFirst - 1, iSecond - 1] + 1;
				}
				
				maxLen = Math.Max(maxLen, scoreTable[iFirst, iSecond]);
			}
		}
	}
	
	return maxLen;
}

// Define other methods and classes here