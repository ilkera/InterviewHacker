<Query Kind="Program" />

void Main()
{
	HashSet<string> words = new HashSet<string>();
	ReadWords(@"D:\Github\coding_interviews\Input\BoggleWords.txt", words);
	
	Boggle b = new Boggle(4, words);
	
	words.Count.Dump();
	b.Solve().Dump();
}

public class Boggle
{
	private HashSet<string> words;
	private char[,] matrix;
	private bool[,] visited;
	private int length;
	
	public Boggle(int length, HashSet<string> words)
	{
		this.length = length;
		this.matrix = new char[this.length, this.length];
		this.visited = new bool[this.length, this.length];
		this.words = words;
		
		this.InitializeMatrix(); // todo
	}
	
	public HashSet<string> Solve()
	{
		HashSet<string> result = new HashSet<string>();
		
		for (int row = 0; row < this.length; row++)
		{
			for (int col = 0; col < this.length; col++)
			{
				FindWord("", row, col, result);
			}
		}
		
		return result;
	}
	
	private void FindWord(string prefix, int row, int col, HashSet<string> result)
	{
		if (row < 0 ||
			row >= this.length ||
			col < 0 ||
			col >= this.length || 
			this.visited[row, col] ||
			!this.HasPrefix(prefix))
		{
			return;
		}
		
		this.visited[row, col] = true;
		prefix += this.matrix[row, col];
		
		if (this.IsWord(prefix))
		{
			result.Add(prefix);
		}
		
		for (int neighbor_row = -1; neighbor_row <= 1; neighbor_row++)
		{
			for (int neighbor_col = -1; neighbor_col <= 1; neighbor_col++)
			{
				FindWord(prefix, row + neighbor_row, col + neighbor_col, result);
			}
		}
		
		this.visited[row, col] = false;
	}
	
	private bool IsWord(string str)
	{
		return this.words.Contains(str);
	}
	
	private bool HasPrefix(string prefix)
	{
		foreach (var word in this.words)
		{
			if (word.StartsWith(prefix))
			{
				return true;
			}
		}
		
		return false;
	}
	
	private void InitializeMatrix()
	{
		this.matrix[0,0] = 'o';
		this.matrix[0,1] = 'a';
		this.matrix[0,2] = 'a';
		this.matrix[0,3] = 'n';
		
		this.matrix[1,0] = 'e';
		this.matrix[1,1] = 't';
		this.matrix[1,2] = 'r';
		this.matrix[1,3] = 'i';

		this.matrix[2,0] = 'i';
		this.matrix[2,1] = 'h';
		this.matrix[2,2] = 'k';
		this.matrix[2,3] = 'r';
		
		this.matrix[3,0] = 'i';
		this.matrix[3,1] = 'f';
		this.matrix[3,2] = 'l';
		this.matrix[3,3] = 'v';
		
	}
}

public static void ReadWords(string file, HashSet<string> dictionary)
{
	string[] words = File.ReadAllLines(file);
	
	foreach (var line in words)
	{
		string boggle_word = line.Split(' ')[1];
		dictionary.Add(boggle_word);
	}
}

// Define other methods and classes here