<Query Kind="Program" />

static void T1_CacheGet_NotExist()
{
	Console.WriteLine("\nT1_CacheGet_NotExist - Start");
	LRUCache cache = new LRUCache(5);
	(cache.Get(1) == -1).Dump();
	Console.WriteLine("T1_CacheGet_NotExist - End");
}

static void T2_CacheGet_Exist()
{
	Console.WriteLine("\nT2_CacheGet_Exist - Start");
	LRUCache cache = new LRUCache(5);
	cache.Set(1, 100);
	(cache.Get(1) == 100).Dump();
	Console.WriteLine("T2_CacheGet_Exist - End");
}

static void T3_CacheSet_LRU_IS_Vacated()
{
	Console.WriteLine("\nT3_CacheSet_LRU_IS_Vacated - Start");
	LRUCache cache = new LRUCache(3);
	cache.Set(1, 100);
	cache.Set(2, 200);
	cache.Set(3, 300);
	cache.Set(4, 400);
	(cache.Get(1) == -1).Dump();
	(cache.Get(4) == 400).Dump();
	(cache.Get(3) == 300).Dump();
	(cache.Get(2) == 200).Dump();
	Console.WriteLine("T3_CacheSet_LRU_IS_Vacated - End");
}

static void T3_Cache_LeastRecentlyUsed_IS_Updated()
{
	Console.WriteLine("\nT3_Cache_LeastRecentlyUsed_IS_Updated - Start");
	LRUCache cache = new LRUCache(4);
	cache.Set(1, 100);
	cache.Set(2, 200);
	cache.Set(3, 300);
	cache.Set(4, 400);
	
	cache.Get(1); // LRU is 2
	cache.Set(5, 500);
	(cache.Get(2) == -1).Dump(); // LRU is 3
	cache.Set(6, 600); 
	(cache.Get(3) == -1).Dump(); // LRU is 4
	cache.Get(4); // LRU is 1
	cache.Set(7,700);
	(cache.Get(1) == -1).Dump(); // LRU is 5
	
	Console.WriteLine("T3_Cache_LeastRecentlyUsed_IS_Updated - End");
}

static void T4_Cache_AlreadyExistKey_Update()
{
	Console.WriteLine("\nT4_Cache_AlreadyExistKey_Update - Start");
	LRUCache cache = new LRUCache(4);
	cache.Set(1, 100);
	(cache.Get(1) == 100).Dump();
	cache.Set(1, 200);
	(cache.Get(1) == 200).Dump();
	Console.WriteLine("\nT4_Cache_AlreadyExistKey_Update - End");
	
}

void Main()
{
	T1_CacheGet_NotExist();
	
	T2_CacheGet_Exist();

	T3_CacheSet_LRU_IS_Vacated();
	
	T3_Cache_LeastRecentlyUsed_IS_Updated();
}

public class LRUCache
{
	private LinkedList<CacheEntry> entries;
	private Dictionary<int, LinkedListNode<CacheEntry>> map;
	private int capacity;
	
	public LRUCache(int capacity)
	{
		this.capacity = capacity;	
		this.map = new Dictionary<int, LinkedListNode<CacheEntry>>();
		this.entries = new LinkedList<CacheEntry>();
	}
	
	public void Set(int key, int value)
	{
		if (map.ContainsKey(key))
		{
			map[key].Value.Value = value;
			
			// Update location 
			this.MoveToHead(key);
		}
		else
		{
			if (this.capacity == map.Count)
			{
				// Vacate least recently used item
				this.VacateLeastRecentlyUsed();
			}
			CacheEntry newEntry = new CacheEntry(key, value);
			LinkedListNode<CacheEntry> node = new LinkedListNode<CacheEntry>(newEntry);
			
			if (this.entries.Count == 0)
			{
				this.entries.AddFirst(node);
			}
			else
			{
				this.entries.AddBefore(this.entries.First, node);
			}
			this.map.Add(key, node);
		}
	}
	
	public int Get(int key)
	{
		if (!map.ContainsKey(key))
		{
			return -1;
		}
		
		// Update location
		this.MoveToHead(key);
		
		return map[key].Value.Value;
	}
	
	private void VacateLeastRecentlyUsed()
	{
		if (this.entries.Count > 0)
		{
			int key = this.entries.Last.Value.Key;
			this.entries.RemoveLast();
			this.map.Remove(key);
		}
	}
	
	private void MoveToHead(int key)
	{
		if (!map.ContainsKey(key))
		{
			return;
		}
		
		LinkedListNode<CacheEntry> node = map[key];	
		this.entries.Remove(node);
		this.entries.AddFirst(node);
	}
	
}

public class CacheEntry
{
	public int Key { get; set; }
	public int Value { get; set; }
	
	public CacheEntry(int key, int value)
	{
		this.Key = key;
		this.Value = value;
	}
}

// Define other methods and classes here
