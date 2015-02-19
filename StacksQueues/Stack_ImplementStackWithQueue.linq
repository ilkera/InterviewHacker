<Query Kind="Program" />

void Main()
{
	/*
	Push(1)
	
	q1 : 1
	q2 : {}
	
	Push(2)
	q2 : 2
	q1 : 1
	
	q2: 2, 1
	q1: {}
	
	Push(3)
	q1: 3
	q2: 2, 1
	
	q1: 3, 2, 1
	q2: {}
	
	Pop()
	Pop from q1 -> 3
	q1: 2, 1
	q2: {}
	
	Pop()
	Pop from q1 -> 2
	q1: 1
	q2: {}
	
	Push(4)
	q2: 4
	q1: 1
	
	q2: 4, 1
	q1: {}
	
	
	
	
	*/
	Stack<int> stack = new Stack<int>(5);
	(stack.IsEmpty() == true).Dump();
	
	stack.Push(1);
	(stack.IsEmpty() == false).Dump();
	
	stack.Push(2);
	(stack.Pop() == 2).Dump();
	(stack.Pop() == 1).Dump();
	(stack.IsEmpty() == true).Dump();
	
	for (int i = 0; i < 5; i++)
	{
		stack.Push(i);
	}
	
	(stack.IsFull() == true).Dump();
	
	(stack.Pop() == 4).Dump();
}

public class Stack<T>
{
	private uint capacity;
	private Queue<T> queue1;
	private Queue<T> queue2;
	
	public Stack(uint capacity)
	{
		this.capacity = capacity;
		this.queue1 = new Queue<T>(capacity);
		this.queue2 = new Queue<T>(capacity);
	}
	
	public void Push(T item)
	{
		if (this.IsFull())
		{
			throw new Exception("Stack is full");
		}
		
		Queue<T> enqueue = queue1.IsEmpty() ? queue1 : queue2;
		Queue<T> dequeue = queue1.IsEmpty() ? queue2 : queue1;
		
		enqueue.Enqueue(item);
		
		while (!dequeue.IsEmpty())
		{
			enqueue.Enqueue(dequeue.Dequeue());
		}
	}
	
	public T Pop()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Stack is empty");
		}
		
		return !queue1.IsEmpty() ? queue1.Dequeue() : queue2.Dequeue();
	}
	
	public bool IsEmpty()
	{
		return this.queue1.IsEmpty() && this.queue2.IsEmpty();
	}
	
	public bool IsFull()
	{
		return this.queue1.IsFull() || this.queue2.IsFull();
	}
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
