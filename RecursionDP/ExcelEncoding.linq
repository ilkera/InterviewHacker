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

// Define other methods and classes here
