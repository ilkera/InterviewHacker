<Query Kind="Program" />

void Main()
{
	FindIntersection(new int[]{2,8,10,12,14}, new int[]{3,8, 11, 14,15,18,20,22}).Dump();
	FindIntersection(new int[]{2}, new int[]{3,8, 11, 14,15,18,20,22}).Dump();
	FindIntersection(new int[]{22}, new int[]{3,8, 11, 14,15,18,20,22}).Dump();
}

// Solution 1: Brute force. For each item in A, check if item exists in B O(m*n)
// Solution 2: Hash Table. For each item in A, add it into hash table. For each item in B, check if it exists in the hash map. O(m + n) => extra space 
// Solution 3: Binary search: For each item in A, search it in B via Binary Search. O(m*lg(n))
// Solution 4: Since both are sorted. Have two index pointers. i and j. If A[i] > B[j] then j++, if A[i] < B[j] then i++ else A[i] == B[i] add into the intersection set. O(m+n) no extra space.

public static List<int> FindIntersection(int[] sortedA, int[] sortedB)
{
	List<int> intersection = new List<int>();
	
	if (sortedA != null && sortedB != null)
	{
		int indexA = 0;
		int indexB = 0;
		
		while (indexA < sortedA.Length && indexB < sortedB.Length)
		{
			if (sortedA[indexA] > sortedB[indexB])
			{
				indexB++;
			}
			else if (sortedA[indexA] < sortedB[indexB])
			{
				indexA++;
			}
			else
			{
				intersection.Add(sortedA[indexA]);
				indexA++;
				indexB++;
			}
		}
	}
	
	return intersection;
}

// Define other methods and classes here
