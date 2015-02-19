<Query Kind="Program" />

void Main()
{
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
