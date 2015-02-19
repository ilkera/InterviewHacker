<Query Kind="Program" />

void Main()
{
	Node root = new Node(1);
	Node n1 = new Node(2);
	Node n2 = new Node(3);
	Node n3 = new Node(4);
	Node n4 = new Node(5);
	
	root.Next = n1;
	n1.Next = n2;
	n2.Next = n3;
	n3.Next = n4;

	root.Random = n2;
	n1.Random = n3;
	n2.Random = root;
	n3.Random = n4;
	n4.Random = n1;
	
	Utils.Print(root);
	
	Node copy = Utils.Copy(root);
	
	Utils.Print(copy);
	
	Node test1 = new Node(3);
	Node test2 = new Node(5);
	test1.Random = test1;
	test1.Next = test2;
	test2.Random = test1;
	
	Node copy2 = Utils.Copy(test1);
	
	Utils.Print(copy2);
}

public class Utils
{
	public static void Print(Node head)
	{
		if (head == null)
		{
			return;
		}
		
		Node current = head;
		
		while (current != null)
		{
			Console.Write("{0} - ", current.Data);
			current = current.Next;
		}
		Console.WriteLine("");
		
		current = head;
		while (current != null)
		{
			Console.Write("{0} :: ", current.Random.Data);
			current = current.Next;
		}
		Console.WriteLine("");
	}
	
	public static Node Copy(Node head)
	{
		if (head == null)
		{
			return null;
		}
		
		Dictionary<Node, Node> nodeMap = new Dictionary<Node, Node>();
		Node clone = CloneList(head, nodeMap);
		CloneRandomPointers(head, clone, nodeMap);
		
		return clone;
	}
	
	private static void CloneRandomPointers(Node original, Node clone, Dictionary<Node, Node> nodeMap)
	{
		Node current_original = original;
		Node current_clone = clone;
		
		while (current_original != null)
		{
			current_clone.Random = nodeMap[current_original.Random];
			current_clone = current_clone.Next;
			current_original = current_original.Next;
		}
	}
	
	private static Node CloneList(Node head, Dictionary<Node, Node> nodeMap)
	{
		// Create new list & copy next
		Node clone = new Node(0);
		Node current_original = head;
		Node current_clone = clone;
		
		while (current_original != null)
		{
			current_clone.Next = new Node(current_original.Data);;
			current_clone = current_clone.Next;
			nodeMap.Add(current_original, current_clone);
			current_original = current_original.Next;
		}	
		
		return clone.Next;
	}
}

public class Node
{
	public int Data { get; set; }
	public Node Next { get; set; }
	public Node Random { get; set; }
	
	public Node(int data, Node next = null, Node random = null)
	{
		this.Data = data;
		this.Next = next;
		this.Random = random;
	}
}

// Define other methods and classes here