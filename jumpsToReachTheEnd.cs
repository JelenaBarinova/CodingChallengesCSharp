/*
Minimum number of jumps to reach end
Given an array of integers where each element represents the max number of steps that can be made forward from that element. Write a function to return the minimum number of jumps to reach the end of the array (starting from the first element). If an element is 0, then cannot move through that element.

Example:
Input: arr[] = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9}
Output: 3 (1-> 3 -> 8 ->9)
First element is 1, so can only go to 3. Second element is 3, so can make at most 3 steps eg to 5 or 8 or 9.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution 
{
    static void Main()
    {
        
        //int[] vector = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9};
        //int[] vector = {2 , 4 , 1 , 2 , 3 , 2 , 4 , 2};
        //int[] vector = {1, 3, 5, 6, 7, 5, 4, 3, 3, 3, 0, 0, 9};
        //int[] vector = {1, 1, 0, 3}; //unreachable
        int[] vector = {1, 5, 4, 6, 9, 3, 0, 0, 5, 3, 0, 0, 7, 0, 0, 2, 4, 7}; //vector with 0, result 4
        
        Console.WriteLine("Given vector: ");
        foreach(int item in vector)
        {
            Console.Write(item.ToString() + " ");        
        }
        Console.WriteLine();
        
        int n = vector.Length;
        
        Nullable<int>[] jumps = new Nullable<int>[n];
        int[] predecessor = new int[n];
        
        jumps[0] = 1;
        predecessor[0] = -1;

        bool stop = false;
        int i = 0;
        while (i < n && !stop)
        {
            int k = vector[i];
            int j = i + 1;
            while (j <= i + k && j < n)
            {
                if (jumps[j] == null || jumps[i] > jumps[i] + 1)
                {
                    jumps[j] = jumps[i] + 1;
                    predecessor[j] = i;
                }

                if (j + vector[j] >= n - 1 && (jumps[n - 1] == null || jumps[n - 1] > jumps[i] + 1)) // the end
                {
                    jumps[n - 1] = jumps[j] + 1;
                    predecessor[n - 1] = j;
                    stop = true;
                    break;
                }
                j++;
            }
            i++;
        }
        /*
        Console.WriteLine("\nJumps: ");
        foreach (var a in jumps) Console.Write(a.ToString() + " ");
        Console.WriteLine("\n Predecessors: "); 
        foreach (int a in predecessor) Console.Write(a.ToString() + " ");
        */
        if (jumps[n - 1] == null)
        {
            Console.WriteLine("Result: end is unreachable");
        }
        else
        {
            Stack<int> result = new Stack<int>();
            i = n - 1;
            while (i > -1)
            {
                result.Push(i);
                i = predecessor[i];
            }
            Console.WriteLine("Result: {0} jumps to the end, through these items:", result.Count - 1); 
            foreach (int item in result)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}