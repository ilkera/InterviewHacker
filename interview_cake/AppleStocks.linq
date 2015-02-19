<Query Kind="Program" />

void Main()
{
	int[] stockPricesYesterday = {520, 510, 504, 525, 512, 530, 518, 505, 490, 515, 524 };
	BestProfit(stockPricesYesterday).Dump();
}

public static int BestProfit(int[] stockPricesYesterday)
{
	if (stockPricesYesterday == null || stockPricesYesterday.Length < 1)
	{
		return 0;
	}
	
	int maxProfit = 0;
	int min_price = stockPricesYesterday[0];
	
	for (int i = 0; i < stockPricesYesterday.Length; i++)
	{
		int current_price = stockPricesYesterday[i];
		min_price = Math.Min(min_price, current_price);
		int currentProfit = current_price - min_price;
		maxProfit = Math.Max(maxProfit, currentProfit);
	}
	
	return maxProfit;
}

// Define other methods and classes here
