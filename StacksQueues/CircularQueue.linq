<Query Kind="Program" />

void Main()
{
	CircularQueue<int> q = new CircularQueue<int>(5);
	q.Enqueue(1);
	q.Enqueue(2);
	q.Enqueue(3);
	q.Enqueue(4);
	q.Enqueue(5);
	
	// Q is full
	q.Enqueue(6);
	q.Enqueue(7);
	q.Enqueue(8);
	
	Console.WriteLine("\nDequeuing");
	Console.WriteLine(q.Dequeue());
	Console.WriteLine(q.Dequeue());
	
	// 
	q.Enqueue(9);
	q.Enqueue(10);
	
	while (q.Count != 0)
	{
		q.Dequeue().Dump();
	}
	
}

public class CircularQueue<T>
{
	private T[] data;
	private int capacity;
	private int count = 0;
	private int front;
	private int rear;
	
	public CircularQueue(int capacity)
	{
		this.capacity = capacity;
		this.data = new T[this.capacity];
		this.front = 0;
		this.rear = 0;
		this.count = 0;
	}
	
	public void Enqueue(T item)
	{	
	 	if (this.count == this.capacity)
		{
			return;
		}
		
		this.data[rear] = item;
		++this.count;
		this.rear = (this.rear + 1) % this.capacity;
	}
	
	public T Dequeue()
	{
		if (count == 0)
		{
			throw new Exception("Queue is empty");
		}
		
		T result = this.data[this.front];
		this.count--;
		this.front = (this.front + 1) % this.capacity;
		return result;
	}
	
	public int Count 
	{
		get
		{
			return this.count;
		}
	}
}

// Define other methods and classes here