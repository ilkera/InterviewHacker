<Query Kind="Program" />

void Main()
{
	/* 
	Push(1)
	In: 1
	Out: {}
	
	Push(2)
	In: 2, 1
	Out: {}
	
	Push(3)
	In: 3, 2, 1
	Out: {}
	
	Pop()
	In:{}
	Out: 1, 2 , 3
	
	result: 1
	In: {}
	Out: 2, 3
	
	Pop()
	In: {}
	Out: 2, 3
	
	In: {}
	Out: 3
	
	result: 2
	
	Push(4)
	In: 4
	Out: 3
	
	Push(5)
	In: 5, 4
	Out: 3
	
	Pop()
	In: 5, 4
	Out: {}
	result 3
	
	Pop()
	In: {}
	Out: 5
	result : 4

	Pop()
	In: {}
	Out: {}
	result : 5
	
	
	*/
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
	private uint capacity;
	private Stack<T> incoming;
	private Stack<T> outgoing;
	
	public Queue(uint capacity)
	{
		this.capacity = capacity;
		this.incoming = new Stack<T>(capacity);
		this.outgoing = new Stack<T>(capacity);
	}
	
	public void Enqueue(T item)
	{
		if (this.IsFull())
		{
			throw new Exception("Queue is full");
		}
		
		this.incoming.Push(item);
	}
	
	public T Dequeue()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Queue is empty");
		}
		
		if (this.outgoing.IsEmpty())
		{
			while (!this.incoming.IsEmpty())
			{
				this.outgoing.Push(this.incoming.Pop());
			}
		}
		
		T result = this.outgoing.Pop();
		
		return result;
	}
	
	public bool IsFull()
	{
		return this.incoming.IsFull() || this.outgoing.IsFull();
	}
	
	public bool IsEmpty()
	{
		return this.incoming.IsEmpty() && this.outgoing.IsEmpty();
	}
}

public class Stack<T> 
{
	private List<T> items;
	private uint capacity;
	
	public Stack(uint capacity)
	{
		this.capacity = capacity;
		this.items = new List<T>();
	}
	
	public bool IsEmpty()
	{
		return this.items.Count == 0;
	}
	
	public bool IsFull()
	{
		return this.items.Count == this.capacity;
	}
	
	public void Push(T item)
	{
		if (this.IsFull())
		{
			throw new Exception("Stack is full");
		}
		
		this.items.Insert(0, item);
	}
	
	public T Pop()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Stack is empty");
		}
		
		T result = this.items[0];
		
		this.items.RemoveAt(0);
		
		return result;
	}
}


// Define other methods and classes here
