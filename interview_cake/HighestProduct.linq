<Query Kind="Program" />

void Main()
{
	HighestProduct(new int[] {4, 1, 2, 3, 0}).Dump();
	HighestProduct(new int[] {-4, 1, 2, 3, 0}).Dump();
	HighestProduct(new int[] {-4, 1, 2, 0, 0}).Dump();
	HighestProduct(new int[] {-4, 1, -3, 1, 2}).Dump();
	HighestProduct(new int[] {-10,-10,1,3,2}).Dump();
	HighestProduct(new int[] {-4, -3, 2, -6, 3}).Dump();
	
	Console.WriteLine("\nOptimized");
	HighestProduct_Optimized(new int[] {4, 1, 2, 3, 0}).Dump();
	HighestProduct_Optimized(new int[] {-4, 1, 2, 3, 0}).Dump();
	HighestProduct_Optimized(new int[] {-4, 1, 2, 0, 0}).Dump();
	HighestProduct_Optimized(new int[] {-4, 1, -3, 1, 2}).Dump();
	HighestProduct_Optimized(new int[] {-10,-10,1,3,2}).Dump();
	HighestProduct_Optimized(new int[] {-4, -3, 2, -6, 3}).Dump();
}

public static int HighestProduct(int[] array)
{
	int maxProduct = int.MinValue;
	Array.Sort(array);

	for (int index = 0; index < array.Length - 2; index++)
	{
		int left = index + 1;
		int right = array.Length - 1;
		
		while (left < right)
		{
			int currentProduct = array[index] * array[left] * array[right];
			maxProduct = Math.Max(maxProduct, currentProduct);
			
			if (currentProduct < maxProduct)
			{
				left++;
			}
			else
			{
				right--;
			}
		}
	}
	
	return maxProduct;
}

public static int HighestProduct_Optimized(int[] array)
{
	int highest = Math.Max(array[0], array[1]);
	int lowest = Math.Min(array[0], array[1]);
	
	int highest_product_of_two = array[0] * array[1];
	int lowest_product_of_two = array[0] * array[1];
	
	int highest_product_of_three = array[0] * array[1] * array[2];
	
	for (int i = 2; i < array.Length; i++)
	{
		int current = array[i];
		
		highest_product_of_three = Math.Max(
						highest_product_of_three,
						Math.Max(current * highest_product_of_two, current * lowest_product_of_two));
		
		highest_product_of_two = Math.Max(
						highest_product_of_two, 
						Math.Max(current * highest, current * lowest));
		
		lowest_product_of_two = Math.Min(
						lowest_product_of_two, 
						Math.Min(current * lowest, current * highest));
						
		highest = Math.Max(highest, current);
		
		lowest = Math.Min(lowest, current);
	}
	
	return highest_product_of_three;
}

// Define other methods and classes here
