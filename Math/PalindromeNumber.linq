<Query Kind="Program" />

void Main()
{
	Console.WriteLine("Invalid");
	IsPalindrome(123).Dump();	
	IsPalindrome(120).Dump();
	IsPalindrome_Recursive(123).Dump();
	IsPalindrome_Recursive(120).Dump();
	
	Console.WriteLine("\nValid");
	IsPalindrome(121).Dump();	
	IsPalindrome_Recursive(121).Dump();
	IsPalindrome(13231).Dump();	
	IsPalindrome_Recursive(13231).Dump();	
	IsPalindrome(1221).Dump();	
	IsPalindrome_Recursive(1221).Dump();
	IsPalindrome(22).Dump();
	IsPalindrome_Recursive(22).Dump();
	IsPalindrome(2).Dump();
	IsPalindrome_Recursive(2).Dump();
}

public bool IsPalindrome(int number)
{
	if (number < 0)
	{
		return false;
	}
	
	if (number == 0)
	{
		return true;
	}
	
	int div = 1;
	while ( number / div >= 10)
	{
		div *= 10;
	}
	
	while (number != 0)
	{
		int left = number / div;
		int right = number % 10;
		
		if (left != right)
		{
			return false;
		}
		
		number = (number % div) / 10;
		div /= 100;
	}
	
	return true;
}

public static bool IsPalindrome_Recursive(int number)
{
	return IsPalindromeHelper(number, ref number);
}

private static bool IsPalindromeHelper(int x, ref int y)
{
	if (x < 0)
	{
		return false;
	}
	
	if (x == 0)
	{
		return true;
	}
	
	if (IsPalindromeHelper(x / 10, ref y) && (x % 10 == y % 10))
	{
		y /= 10;
		return true;
	}
	else
	{
		return false;
	}
}

// Define other methods and classes here
