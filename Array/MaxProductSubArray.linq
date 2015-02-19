<Query Kind="Program" />

void Main()
{
	MaxProductSubArray(new int[] {2, 3, -2, 4}).Dump();
	MaxProductSubArray(new int[] {-2, 3, -2, 4}).Dump();
	MaxProductSubArray(new int[] {1, 2, 3, 4}).Dump();
	MaxProductSubArray(new int[] {1, 2, 3, -2}).Dump();
	MaxProductSubArray(new int[] {-1, -2, -3, 2}).Dump();
	MaxProductSubArray(new int[] {6, -3, -10, 0, 2}).Dump(); // 180
	MaxProductSubArray(new int[] {-1, -3, -10, 0, 60}).Dump(); // 60
	MaxProductSubArray(new int[] {-2, -3, 0, -2, -40}).Dump(); // 80
}

public static int MaxProductSubArray(int[] array)
{
	int maxProduct = int.MinValue;
	
	if (array != null && array.Length > 0)
	{
		int current_max_product = array[0];
		int current_min_product = array[0];
		int previous_max_product = array[0];
		int previous_min_product = array[0];
		
		for (int i = 1; i < array.Length; i++)
		{		
			current_max_product = Math.Max(array[i], Math.Max(previous_max_product * array[i], previous_min_product * array[i]));
			current_min_product = Math.Min(array[i], Math.Min(previous_max_product * array[i], previous_min_product * array[i]));
			
			maxProduct = Math.Max(maxProduct, current_max_product);
			
			previous_max_product = current_max_product;
			previous_min_product = current_min_product;		
		}	
	}
	
	return maxProduct;	
}

// Define other methods and classes here
