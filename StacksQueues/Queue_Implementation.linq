<Query Kind="Program" />

void Main()
{
	Queue<int> test = new Queue<int>(5);
	(test.IsEmpty() == true).Dump();
	
	test.Enqueue(1);
	(test.IsEmpty() == false).Dump();
	
	test.Enqueue(2);
	test.Enqueue(3);
	(test.Dequeue() == 1).Dump();
	(test.Dequeue() == 2).Dump();
	(test.Dequeue() == 3).Dump();
	
	(test.IsEmpty() == true).Dump();
	
	(test.IsFull() == false).Dump();
	for (int i = 0; i < 5; i++)
	{
		test.Enqueue(i);
	}
	(test.IsFull() == true).Dump();
}

public class Queue<T>
{
	private List<T> items;
	private uint capacity;
	
	public Queue(uint capacity)
	{
		this.capacity = capacity;
		this.items = new List<T>();
	}
	
	public void Enqueue(T item)
	{
		if (this.IsFull())
		{
			throw new Exception("Queue is full");
		}
		
		this.items.Add(item);
	}
	
	public T Dequeue()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Queue is empty");
		}
		
		T result = this.items[0];
		this.items.RemoveAt(0);
		
		return result;
	}
	
	public bool IsFull()
	{
		return this.capacity == this.items.Count;
	}
	
	public bool IsEmpty()
	{
		return this.items.Count == 0;
	}
}

// Define other methods and classes here
