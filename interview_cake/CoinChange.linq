<Query Kind="Program" />

void Main()
{
	CoinChange(4).Dump();
}

public int CoinChange(int amount)
{
	return CoinChange_Helper(amount, 3);
}

public int CoinChange_Helper(int amount, int currentCoin)
{
	if (amount < 0)
	{
		return 0;
	}
	
	if (amount == 0)
	{
		return 1;
	}	
	
	if (currentCoin <= 0 && amount > 0)
	{
		return 0;
	}

	return CoinChange_Helper(amount, currentCoin - 1) + CoinChange_Helper(amount - currentCoin, currentCoin);
}

// Define other methods and classes here