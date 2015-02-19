<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static Queue<int> buffer = new Queue<int>();	
static Producer p = new Producer(buffer, 5);
static Consumer c = new Consumer(buffer);
	
void Main()
{	
	Thread worker = new Thread(Produce);
	Thread consumer = new Thread(Consume);
	
	worker.Start();
	consumer.Start();
}

public static void Consume()
{
	for (int i = 0; i < 50; i++)
	{
		c.Consume();
		Thread.Sleep(Util.Wait("Consumer"));
	}
}

public static void Produce()
{
	for (int i = 0; i < 50; i++)
	{
		p.Produce();
		Thread.Sleep(2 * Util.Wait("Producer"));
	}
}

public class Producer
{
	private Queue<int> buffer;
	private int capacity;
	
	public Producer(Queue<int> buffer, int capacity)
	{
		this.buffer = buffer;
		this.capacity = capacity;
	}
	
	public void Produce()
	{
		lock(this.buffer)
		{
			while (this.buffer.Count == this.capacity)
			{
				Console.WriteLine("Buffer is full.. waiting");
				Monitor.Wait(this.buffer);
			}
			
			int item = Util.GenerateRandomNumber();
			this.buffer.Enqueue(item);
			Util.PrintProducer(item);
			Monitor.Pulse(this.buffer);
		}
	}
}

public class Util
{
	private static Random random = new Random();
	
	public static int Wait(string who)
	{
		int wait = Util.GenerateWait(100,1000);
		Console.WriteLine("{0} Waiting -- > {1} ms", who, wait);
		return wait;
	}
	
	public static int GenerateRandomNumber()
	{
		return random.Next(0, 1000);
	}
	
	public static int GenerateWait(int min, int max)
	{
		return random.Next(min, max);
	}
	
	public static void PrintConsumer(int item)
	{
		Console.WriteLine("[CCCC] - > Consuming item {0}", item);
	}
	
	public static void PrintProducer(int item)
	{
		Console.WriteLine("[PPPP] - > Producing item {0}", item);
	}
}

public class Consumer
{
	private Queue<int> buffer;
	
	public Consumer(Queue<int> buffer)
	{
		this.buffer = buffer;	
	}
	
	public void Consume()
	{
		lock(this.buffer)
		{
			while (this.buffer.Count == 0)
			{
				Console.WriteLine("Buffer is empty");
				Monitor.Wait(this.buffer);
			}
	
			int item = this.buffer.Dequeue();
			Util.PrintConsumer(item);
			Monitor.Pulse(this.buffer); // optimization: only wake up threads when the buffer was full and dequed one item.
		}
	}
}

// Define other methods and classes here
