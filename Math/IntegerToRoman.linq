<Query Kind="Program" />

void Main()
{	
	for (int i = 1; i < 1000; i++)
	{
		Console.WriteLine("{0} in roman {1}", i, ConvertIntToRoman(i));
	}
		
}

public static string ConvertIntToRoman(int number)
{
	if (number < 1)
	{
		return string.Empty;
	}
	
	Dictionary<int, string> numberToRomanMap = new Dictionary<int ,string>();
	numberToRomanMap.Add(1000, "M");
	numberToRomanMap.Add(900, "CM");
	numberToRomanMap.Add(500, "D");
	numberToRomanMap.Add(400, "CD");
	numberToRomanMap.Add(100, "C");
	numberToRomanMap.Add(90, "XC");
	numberToRomanMap.Add(50, "L");
	numberToRomanMap.Add(40, "XL");
	numberToRomanMap.Add(10, "X");
	numberToRomanMap.Add(9, "IX");
	numberToRomanMap.Add(5, "V");
	numberToRomanMap.Add(4, "IV");
	numberToRomanMap.Add(1, "I");
	
	int[] romanValues = new int[] {100, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
	
	StringBuilder roman= new StringBuilder();
	
	for (int i = 0; i < romanValues.Length; i++)
	{
		while (romanValues[i] <= number)
		{
			roman.Append(numberToRomanMap[romanValues[i]]);
			number -= romanValues[i];
		}
	}
	
	return roman.ToString();
	
}

// Define other methods and classes here