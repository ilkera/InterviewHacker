<Query Kind="Program" />

void Main()
{
	IsInterleaving("", "", "").Dump();
	IsInterleaving("aabcc", "dbbca", "aadbbcbcac").Dump();
	IsInterleaving("aabcc", "dbbca", "aadbbbaccc").Dump();
}

public static bool IsInterleaving(string s1, string s2, string s3)
{
	if (string.IsNullOrEmpty(s1))
	{
		return s2 == s3;
	}
	
	if (string.IsNullOrEmpty(s2))
	{
		return s1 == s3;
	}
	
	if (string.IsNullOrEmpty(s3))
	{
		return false;
	}
	
	if (s1.Length + s2.Length != s3.Length)
	{
		return false;
	}
	
	return IsInterleavingHelper(s1, s2, s3);
}

private static bool IsInterleavingHelper(string s1, string s2, string s3)
{
	if (s1 == string.Empty && s2 == string.Empty)
	{
		return s3 == string.Empty;
	}
	
	if (s1 == string.Empty)
	{
		return s2 == s3;
	}
	
	if (s2 == string.Empty)
	{
		return s1 == s3;
	}
	
	if (s1[0] != s3[0] && s2[0] != s3[0])
	{
		return false;
	}
	else if (s1[0] == s3[0] && s2[0] == s3[0])
	{
		return IsInterleavingHelper(s1.Substring(1), s2, s3.Substring(1)) ||
			   IsInterleavingHelper(s1, s2.Substring(1), s3.Substring(1));
	}
	else if (s1[0] == s3[0])
	{
		return IsInterleavingHelper(s1.Substring(1), s2, s3.Substring(1));
	}
	else if (s2[0] == s3[0])
	{
		return IsInterleavingHelper(s1, s2.Substring(1), s3.Substring(1));
	}
	
	return false;
}

// Define other methods and classes here
