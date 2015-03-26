<Query Kind="Program" />

void Main()
{
	for (int i = 0; i < 11; i++)
	{
		Console.WriteLine("Rotating " + i );
		//RotateArray(new int[] {1, 2, 3, 4, 5}, i);
		RotateArray_Faster(new int[] {1, 2, 3, 4, 5}, i);
	}
}

public static void RotateArray(int[] array, int timesToRotate)
{
	if (array == null || array.Length < 2 || timesToRotate < 1)
	{
		return;
	}
	
	if (timesToRotate > array.Length)
	{
		timesToRotate = timesToRotate % array.Length;
	}
		
	if (timesToRotate == array.Length)
	{
		return;
	}
	
	for (int i = 0; i < timesToRotate; i++)
	{
		Rotate(array);
	}
	
	array.Dump();
}

public static void RotateArray_Faster(int[] array, int timesToRotate)
{
	if (array == null || array.Length < 2 || timesToRotate < 1)
	{
		return;
	}
	
	if (timesToRotate > array.Length)
	{
		timesToRotate = timesToRotate % array.Length;
	}
		
	if (timesToRotate == array.Length || timesToRotate == 0)
	{
		return;
	}
	
	int[] newArray = new int[array.Length];
	
	for (int i = 0; i < array.Length; i++)
	{
		int newIndex = i + timesToRotate < array.Length ? i + timesToRotate : (i + timesToRotate) % array.Length;
		newArray[newIndex] = array[i];
	}
	
	for (int i = 0; i < array.Length; i++)
	{
		array[i] = newArray[i];
	}
	
	array.Dump();
}

private static void Rotate(int[] array)
{
	int last = array[array.Length - 1];
	
	for (int i = array.Length -2; i >=0; i--)
	{
		array[i + 1] = array[i];
	}
	
	array[0] = last;
}

// Define other methods and classes here