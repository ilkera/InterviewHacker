<Query Kind="Program">
  <Reference Relative="..\Collections\PowerCollections.dll">D:\Github\coding_interviews\Collections\PowerCollections.dll</Reference>
  <Namespace>Wintellect.PowerCollections</Namespace>
</Query>

void Main()
{
	List<Node> lists = new List<Node>();
	lists.Add(new Node(1, new Node(4, new Node(7))));
	lists.Add(new Node(0, new Node(2, new Node(6, new Node(11)))));
	lists.Add(new Node(5, new Node(6, new Node(9, new Node(15)))));
	lists.Add(new Node(2, new Node(13, new Node(18, new Node(20)))));
	
	ListUtils.Print(ListUtils.Merge(lists));
}

public class ListUtils
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
	}
	public static Node Merge(List<Node> lists)
	{
		Node result = null;
		
		if (lists != null && lists.Count > 0)
		{
			OrderedBag<Node> heap = new OrderedBag<Node>(
									lists, 
									delegate(Node a, Node b) { return a.Data.CompareTo(b.Data); });
			result = new Node(-1);
			Node merged = result;
			
			while (heap.Count != 0)
			{
				Node current = heap.RemoveFirst();
				merged.Next = current;
				merged = merged.Next;
				
				if (current.Next != null)
				{
					current = current.Next;
					heap.Add(current);
				}
			}
		}
		
		return result != null ? result.Next : null;
	}
}

public class Node
{
	public int Data { get; set; }
	public Node Next { get; set; }
	
	public Node(int data, Node next = null)
	{
		this.Data = data;
		this.Next = next;
	}
}

// Define other methods and classes here
