<Query Kind="Program" />

void Main()
{
	MaxInSlidingWindows(new int[]{2, 3, 4, 2, 6, 2, 5, 1}, 3).Dump();
}

public List<int> MaxInSlidingWindows(int[] array, int windowSize)
{
		List<int> result = new List<int>();
			
		if (array != null && array.Length >= windowSize && windowSize > 1)
		{
			LinkedList<int> dequeue = new LinkedList<int>();
		
			for (int i = 0; i < windowSize; i++)
			{
				while(dequeue.Count != 0 && array[i] >= array[dequeue.Last.Value])
				{
					dequeue.RemoveLast();
				}
				dequeue.AddLast(i);
			}
		
			for (int i = windowSize; i < array.Length; i++)
			{		
				result.Add(array[dequeue.First.Value]);
				while (dequeue.Count != 0 && array[i] >= array[dequeue.Last.Value])
				{
					dequeue.RemoveLast();
				}
			
				while (dequeue.Count != 0 && dequeue.First.Value <= i - windowSize)
				{
					dequeue.RemoveFirst();
				}
			
				dequeue.AddLast(i);
			}	
			
			result.Add(array[dequeue.First.Value]);			
		}
		
		return result;
}

// Define other methods and classes here