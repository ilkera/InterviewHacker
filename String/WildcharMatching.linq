<Query Kind="Program" />

void Main()
{
	test("g*ks", "geeks"); // Yes
    test("ge?ks*", "geeksforgeeks"); // Yes
    test("g*k", "gee");  // No because 'k' is not in second
    test("*pqrs", "pqrst"); // No because 't' is not in first
    test("abc*bcd", "abcdhghgbcd"); // Yes
    test("abc*c?d", "abcd"); // No because second must have 2 instances of 'c'
    test("*c*d", "abcd"); // Yes
    test("*?c*d", "abcd"); // Yes
}

public static void test(string s1, string s2)
{
	Console.WriteLine("{0} and {1} => {2}",s1, s2, Match(s1, s2)); 
}

public static bool Match(string first, string second)
 {
 	Console.WriteLine("First " + first + " Second " + second);
   	// If both strings are null, then we reached to end => return true
   	if(string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second))
    {
        return true;
    }
	
	if (first.Length == 0)
	{
		return false;
	}
	
	if (second.Length == 0)
	{
		if (first[0] == '*')
		{
			return Match(first.Substring(1), second); 
		}
		return false;
	}
	
	// If the first char is ?, or current chars of both strings are equal
    if(first[0] == '?' || first[0] == second[0])
    {
         return Match(first.Substring(1), second.Substring(1));
    }
	
	// If there is *, then there are two possibilities
	// 1) We consider current character of second string 
	// 2) We ignore current character of second string
    if(first[0] == '*')
    {
        return Match(first.Substring(1), second) || Match(first, second.Substring(1));
    }

	return false;
}