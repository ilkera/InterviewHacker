<Query Kind="Program" />

void Main()
{
	Encoder encoder = new Encoder("thisisthetest");
	encoder.EncodedString.Dump();
}

public class Encoder
{
	private Dictionary<char, int> frequencies;
	private Dictionary<char, byte[]> symbolEncoding;
	private List<byte> encodedBits;
	private Node huffmanTree;
	
	public string EncodedString
	{
		get
		{
			return 	Encoding.ASCII.GetString(this.encodedBits.ToArray());
		}
	}
	
	public Encoder(string text)
	{
		this.frequencies = new Dictionary<char, int>();
		this.symbolEncoding = new Dictionary<char, byte[]>();
		this.encodedBits = new List<byte>();
		
		// Count frequencies
		this.CountFrequencies(text);
		
		// Build Tree
		this.BuildTree();
		
		// Generate Symbol Encoding
		this.GenerateSymbolEncoding();
		
		// Generate Encoded bits
		this.GenerateEncodedBits(text);
	}
	
	private void CountFrequencies(string text)
	{
		foreach (var symbol in text)
		{
			if (this.frequencies.ContainsKey(symbol))
			{
				this.frequencies[symbol] += 1;
			}
			else
			{
				this.frequencies.Add(symbol, 1);
			}
		}
	}
	
	private void BuildTree()
	{	
		List<KeyValuePair<char, int>> sortedFrequencies = this.frequencies.ToList();
		sortedFrequencies.Sort((first, second) =>
		{
			return first.Value.CompareTo(second.Value);
		});
		
		if (sortedFrequencies.Count == 0)
		{
			return;
		}
		
		Node root = new Node(sortedFrequencies[0].Value, sortedFrequencies[0].Key);;
		int index = 1;
		
		while (index < sortedFrequencies.Count)
		{
			Node current = new Node(sortedFrequencies[index].Value, sortedFrequencies[index].Key);
			Merge(current, ref root);
			index++;
		}
		
		this.huffmanTree = root;
	}
	
	private void Merge(Node current, ref Node root)
	{
		Node newNode = new Node(current.Frequency + root.Frequency,' ', root, current);
		root = newNode;
	}
	
	private void GenerateSymbolEncoding()
	{
		this.GenerateSymbolHelper(this.huffmanTree, "");
	}
	
	private void GenerateSymbolHelper(Node root, string current)
	{
		if (root == null)
		{
			return;
		}
		
		if (root.Left == null && root.Right == null)
		{
			if (root.Symbol != ' ' && this.frequencies.ContainsKey(root.Symbol))
			{
				this.symbolEncoding.Add(root.Symbol, Encoding.ASCII.GetBytes(current));
			}
			return;
		}
		
		GenerateSymbolHelper(root.Left, current + "0");
		GenerateSymbolHelper(root.Right, current + "1");
	}
	
	private void GenerateEncodedBits(string text)
	{	
		foreach (var element in text)
		{
			this.encodedBits.AddRange(this.symbolEncoding[element]);
		}
	}
}

public class Node
{
	public int Frequency { get; set; }
	public char Symbol { get; set; }
	public Node Left { get; set; }
	public Node Right { get; set; }
	
	public Node(int frequency, char symbol, Node left = null, Node right = null)
	{
		this.Frequency = frequency;
		this.Symbol = symbol;
		this.Left = left;
		this.Right = right;
	}
}

// Define other methods and classes here
