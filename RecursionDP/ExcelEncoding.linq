<Query Kind="Program" />

void Main()
{
	ToExcelId("A").Dump();
	ToExcelId("B").Dump();
	ToExcelId("AA").Dump();
	ToExcelId("AB").Dump();
	ToExcelId("Y").Dump();
	ToExcelId("YZ").Dump();
	ToExcelId("ZZ").Dump();
	ToExcelId("ABC").Dump();
	
	Console.WriteLine("\nId to Code");
	ToExcelCode(676, "").Dump();
	ToExcelCode(702, "").Dump();
	ToExcelCode(731, "").Dump();
	ToExcelCode(1, "").Dump();
	ToExcelCode(2, "").Dump();
	ToExcelCode(27, "").Dump();
	ToExcelCode(28, "").Dump();
	ToExcelCode(25, "").Dump();
}

public static int ToExcelId(string code)
{
	int result = 0;
	
	for (int i = 0; i < code.Length; i++)
	{
		result = result * 26 + code[i] - 'A' + 1;
	}
	
	return result;
}

public static string ToExcelCode(int id, string current)
{
	if (id == 0)
	{
		return Reverse(current);
	}
	
	int last = id % 26;
	if (last == 0)
	{
		last = 26;
	}
	current += (char)('A' + last - 1);
	id -= last;
	
	return ToExcelCode(id / 26, current);
}

private static string Reverse(string str)
{
	char[] array = str.ToCharArray();
	Array.Reverse(array);
	
	return new string(array);
}

// Define other methods and classes here