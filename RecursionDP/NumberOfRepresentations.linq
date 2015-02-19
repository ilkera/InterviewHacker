<Query Kind="Program" />

void Main()
{
	FindNumberOfReps("1").Dump();
	FindNumberOfReps("10").Dump();
	FindNumberOfReps("12").Dump();
	FindNumberOfReps("2421").Dump();  // (24,2,1) (24,21), (2,4,21), (2,4,2,1)
}

public static int FindNumberOfReps(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		return 0;
	}
	
	if (str.Length == 1)
	{
		return str[0] != '0' ? 1 : 0; 
	}
	
	char current = str[0];
	char next = str[1];
	
	if (current == '1' || (current == '2' && next <= '6'))
	{
		return 1 + FindNumberOfReps(str.Substring(1));
	}
	
	return FindNumberOfReps(str.Substring(1));
}

/*

def numreps(s):
    length = len(s)
    if length == 0:
        return 1
    if length >= 2 and 10 < int(s[:2]) <= 26:
        return numreps(s[1:]) + numreps(s[2:])
    else:
        return numreps(s[1:])

*/
// Define other methods and classes here
