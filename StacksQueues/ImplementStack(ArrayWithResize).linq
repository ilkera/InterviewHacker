<Query Kind="Program" />

void Main()
{
	Stack s = new Stack();
	
	for (int i = 0; i < 22; i++)
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
	private int initialCapacity = 5;
	private int capacity;
	private int top;
	private int count;
	private int[] stack;
	
	public Stack()
	{
		this.stack = new int[this.initialCapacity];
		this.capacity = this.initialCapacity;
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
			Resize(2 * this.capacity);
		}
		
		this.stack[++this.top] = item;
		this.count++;
	}
	
	public int Pop()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Stack is empty");
		}
		
		int item = this.stack[this.top];
		this.top--;
		this.count--;
		
		if (this.count > this.initialCapacity && this.count == this.capacity / 4)
		{
			Resize(this.capacity / 2);
		}
		
		return item;
	}
	
	public int Top()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Stack is empty");
		}
		
		return this.stack[this.top];
	}
	
	private void Resize(int newCapacity)
	{
		Console.WriteLine("Count {2} Resizing... from {0} to {1}", this.capacity, newCapacity, this.count);
		
		this.capacity = newCapacity;
		int[] newArray = new int[newCapacity];
		
		for (int i = 0; i < this.count; i++)
		{
			newArray[i] = stack[i];
		}
		
		stack = newArray;
	}
}