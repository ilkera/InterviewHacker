<Query Kind="Program" />

void Main()
{
	SimpleQueue q = new SimpleQueue(10);
	
	Random rnd = new Random();
	
	int item = 0;
	
	do
	{
		item = rnd.Next(1, 10);
		Console.WriteLine("Inserting " + item);
	}
	while (q.Enqueue(item));
	
	int result = 0;
	while (q.Dequeue(ref result))
	{
		Console.WriteLine("Deque " + result);
	}
}

public class SimpleQueue
{
	private int head;
	private int capacity;
	private int length;
	private int[] array;
	
	public SimpleQueue(int capacity)
	{
		this.capacity = capacity;
		this.array = new int[this.capacity];
		this.length = 0;
		this.head = 0;
	}
	
	public bool Enqueue(int item)
	{
		if (this.length < this.capacity)
		{
			int index = (this.head + this.length) % this.capacity;
			this.array[index] = item;
			this.length++;
			return true;
		}
		
		return false;
	}
	
	public bool Dequeue(ref int result)
	{
		if (this.length > 0)
		{
			result = this.array[head];
			this.head = (this.head + 1) % this.capacity;
			this.length--;
			return true;
		}
		return false;
	}
	
	public bool IsEmpty()
	{
		return this.length == 0;
	}
	
	public bool IsFull()
	{
		return this.length == this.capacity;
	}
}

// Define other methods and classes here
