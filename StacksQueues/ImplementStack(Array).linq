<Query Kind="Program" />

void Main()
{
	Stack s = new Stack(10);
	for (int i = 0; i < 9; i++)
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
	private int top;
	private int count;
	private int[] stack;
	
	public Stack(int capacity)
	{
		this.capacity = capacity;
		this.stack = new int[capacity];
		this.top = -1;
		this.count = 0;
	}
	
	public bool IsEmpty()
	{
		return this.count == 0;
	}
	
	public bool IsFull()
	{
		return this.count == this.capacity;
	}
	
	public void Push(int item)
	{
		if (this.IsFull())
		{
			throw new Exception("Stack is overflow");
		}
		
		this.stack[++this.top] = item;
		++this.count;
	}
	
	public int Pop()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Stack is empty");
		}
		
		int item = this.stack[this.top];
		--this.top;
		--this.count;
		
		return item;
	}
	
	public int Top()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Stack is empty");
		}
		
		int item = this.stack[this.top];
		
		return item;
	}
}
// Define other methods and classes here