<Query Kind="Program" />

void Main()
{
	Stack s = new Stack(10);
	
	for (int i = 0; i < 10; i++)
	{
		s.Push(i);
		Console.WriteLine("Added {0} peek is {1}", i, s.Top());
	}
	
	while (!s.IsEmpty())
	{
		int item = s.Pop();
		Console.WriteLine("Popped " + item);
	}
}

public class Stack
{
	private int capacity;
	private LinkedList<int> stack;
	
	public Stack(int capacity)
	{
		this.capacity = capacity;
		this.stack = new LinkedList<int>();
	}
	
	public bool IsEmpty()
	{
		return this.stack.Count == 0;
	}
	
	public bool IsFull()
	{
		return this.stack.Count == this.capacity;
	}
	
	public void Push(int item)
	{
		if (this.IsFull())
		{
			throw new Exception("Stack is overflown");
		}
		
		this.stack.AddFirst(item);
	}
	
	public int Pop()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Stack is empty");
		}	
		
		int item = this.stack.First.Value;
		this.stack.RemoveFirst();
		
		return item;
	}
	
	public int Top()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Stack is empty");
		}
		
		return this.stack.First.Value;
	}
}

// Define other methods and classes here
