<Query Kind="Program" />

void Main()
{
	(strStr("Test", null) == null).Dump();
	(strStr(null, "test") == null).Dump();
	(strStr("This is a test", "is") == "is").Dump();
	(strStr("This is a test", "at") == null).Dump();
	(strStr("This is a test", "this") == null).Dump();
	(strStr("This is a test", "This") == "This").Dump();
	(strStr("This is a test", "est") == "est").Dump();
	(strStr("This is a test", "a") == "a").Dump();
	(strStr("This is a test", "i") == "i").Dump();
	(strStr("This is a test", "este") == null).Dump();
	(strStr("abababbabc", "abc") == "abc").Dump();
}

public static string strStr(string haystack, string needle)
{
	if (needle == null || haystack == null)
	{
		return null;
	}
	
	int iHaystack = 0;
	
	while (iHaystack < haystack.Length)
	{
		if (haystack[iHaystack] != needle[0])
		{
			iHaystack++;
			continue;
		}
		
		int start = iHaystack + 1;
		int iNeedle = 1;
		
		while (start < haystack.Length && iNeedle < needle.Length && haystack[start] == needle[iNeedle])
		{
			start++;
			iNeedle++;
		}
		
		if (iNeedle == needle.Length)
		{
			return haystack.Substring(iHaystack, needle.Length);
		}
		
		iHaystack++;
	}
	
	return null;
}

// Define other methods and classes here