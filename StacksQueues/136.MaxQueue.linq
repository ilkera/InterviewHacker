<Query Kind="Program" />

void Main()
{
	MaxQueue m = new MaxQueue(10);

	for (int i = 10; i > 0; i--)
	{
		m.Enqueue(i);
		Console.WriteLine("Added {0} and max {1}", i, m.Max());
	}
	
	for (int i = 0; i < 9; i++)
	{
		int item = m.Dequeue();
		Console.WriteLine("Removed {0} and current max {1}", item, m.Max());
	}	
}

public class Deque
{
	private int capacity;
	private LinkedList<int> list;
	
	public Deque(int capacity)
	{
		this.capacity = capacity;
		this.list = new LinkedList<int>();
	}
	
	public void Push_Back(int item)
	{
		if (this.IsFull())
		{
			throw new Exception("full");
		}
	
		this.list.AddLast(item);
	}
	
	public void Push_Front(int item)
	{
		if (this.list.Count == this.capacity)
		{
			throw new Exception("full");
		}
		this.list.AddFirst(item);
	}
	
	public int Front()
	{
		if (this.IsEmpty())
		{
			throw new Exception("empty");
		}
		
		return this.list.First.Value;
	}
	
	public int Last()
	{
		if (this.IsEmpty())
		{
			throw new Exception("empty");
		}
		
		return this.list.Last.Value;
	}
	
	public int Pop_Back()
	{
		if (this.IsEmpty())
		{
			throw new Exception("empty");
		}
		
		int last = this.list.Last.Value;
		this.list.RemoveLast();
		return last;
	}
	
	public int Pop_Front()
	{
		if (this.IsEmpty())
		{
			throw new Exception("empty");
		}
		int first = this.list.First.Value;
		this.list.RemoveFirst();
		return first;
	}
	
	public bool IsFull()
	{
		return this.list.Count == this.capacity;
	}
	
	public bool IsEmpty()
	{
		return this.list.Count == 0;
	}
}

public class MaxQueue
{
	private Queue<int> queue;
	private Deque maxQueue;
	
	private int capacity;
	
	public MaxQueue(int capacity)
	{
		this.capacity = capacity;
		queue = new Queue<int>(capacity);	
		maxQueue = new Deque(capacity);
	}
	
	public void Enqueue(int item)
	{
		if (this.IsFull())
		{
			throw new Exception("Queue is full");
		}
		
		this.queue.Enqueue(item);
		
		while (!this.maxQueue.IsEmpty() && item >= this.maxQueue.Last())
		{
			this.maxQueue.Pop_Back();	
		}
		
		this.maxQueue.Push_Back(item);
	}
	
	public int Dequeue()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Queue is empty");
		}
		
		int item = this.queue.Dequeue();
		
		if (item == this.maxQueue.Front())
		{
			this.maxQueue.Pop_Front();
		}
		
		return item;
	}
	
	public int Max()
	{
		if (this.maxQueue.IsEmpty())
		{
			throw new Exception("Queue is empty");
		}
		
		return this.maxQueue.Front();
	}
	
	public bool IsEmpty()
	{
		return this.queue.Count == 0;
	}
	
	public bool IsFull()
	{
		return this.queue.Count == this.capacity;
	}
}

// Define other methods and classes here
