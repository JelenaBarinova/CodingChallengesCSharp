/*
split given array to two parts, each one must have dall the umbers atleast once. return the number of possible splits
*/
using System;
using System.Collections.Generic;

class Solution 
{
    public static void Main()
    {
        int[] arr = {1, 4, 6, 1, 6, 6, 1, 4, 4}; //res = 3
        //int[] arr = {1, 1, 1, 1, 1}; //res = 4
        //int[] arr = {1, 2}; //res = 0
        int res = WaysToSplit(arr);
        Console.WriteLine(res);
    }

    public static int WaysToSplit(int[] arr) 
    {
        var total = new Dictionary<int, int>();
        var current = new HashSet<int>();
        int res = 0;
        foreach (int item in arr)
        {
            if (!total.ContainsKey(item))
            {
                total.Add(item, 0);
            }
            total[item]++;
        }
        int i = 0;
        while (i < arr.Length - total.Count)
        {
            int item = arr[i];
            current.Add(item);
            total[item]--;

            if (total[item] == 0) return res;
            if (current.Count == total.Count)
            {
                res++;
            }
            i++;
        }
        return res;
    }
}
