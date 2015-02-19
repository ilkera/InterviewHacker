<Query Kind="Program" />

void Main()
{
	string[] values = { "+13230", "-0", "1,390,146", "$190,235,421,127",
                          "0xFA1B", "163042", "-10", "2147483647", 
                          "2147483648", "16e07", "134985.0", "-12034", "-2147483647",
                          "-2147483648", "-2147483649", "-2147483650", "0123","-21474836481" };
      foreach (string value in values)
      {
         try {
          //  int numberParse = Int32.Parse(value); 
			int numberATOI = ToInteger(value);
            Console.WriteLine("{0} -->  ATOI: {1}", value, numberATOI);
         }
         catch (FormatException) {
            Console.WriteLine("{0}: Bad Format", value);
         }   
         catch (OverflowException) {
            Console.WriteLine("{0}: Overflow", value);   
         }  
      }
}

public static int ToInteger(string str)
{
	if (string.IsNullOrEmpty(str))
	{
		throw new ArgumentNullException("empty/null string");
	}
	
	int left = 0;
	int right = str.Length - 1;
	
	while (left < str.Length && str[left] == ' ')
	{
		left++;
	}
	
	if (left == str.Length)
	{
		throw new FormatException("string with whitespaces");
	}
	
	while (right >= 0 && str[right] == ' ')
	{
		right--;
	}
	
	bool isNegative = false;
	
	if (str[left] == '+' || str[left] == '-')
	{
		isNegative = str[left] == '-';
		left++;
	}
	
	long result = 0;
	
	while (left <= right)
	{
		if (str[left] >= '0' && str[left] <= '9')
		{
			int currentDigit = (int) str[left] - '0';
			result = (result * 10) + currentDigit;
			
			if (result > int.MaxValue)
			{
				if (isNegative && left == right && (-result) == int.MinValue)
				{
					return int.MinValue;
				}
				
				throw new OverflowException();
			}
		}
		else
		{
			throw new FormatException("bad format");
		}
		left++;
	}
	
	if (isNegative)
	{	
		result *= -1;
	}
	
	return (int)result;
}

// Define other methods and classes here
