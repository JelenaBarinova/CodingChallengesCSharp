/*
The cube, 41063625 (3453), can be permuted to produce two other cubes: 56623104 (3843) and 66430125 (4053).
In fact, 41063625 is the smallest cube which has exactly three permutations of its digits which are also cube.
You are given N, find the smallest cube for which exactly K permutations of its digits are cube of some number which is (<N). If there are multiple sets, print the minimal element of each in sorted order.

Input Format 
Input contains two space separated integers N and K.

Output Format 
Print the answer corresponding to the test case. If there are more than one number, print them on separate lines.

Constraints 
1000≤N≤106 
3≤K≤49

Sample Input

1000 3
Sample Output

41063625
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
class Solution 
{
    static void Main(String[] args) 
    {
        string input = Console.ReadLine();
        var n = Int32.Parse(input.Split(' ')[0]);
        var k = Int32.Parse(input.Split(' ')[1]);
        
        var premutationSet = new Dictionary<string, HashSet<int>>(n);
        for (int i = 0; i <= n; i++)
        {
            char[] cubeChars = ((double)Math.Pow(i, 3)).ToString().ToCharArray();
            Array.Sort(cubeChars);
            string cube = new string(cubeChars);

            if (!premutationSet.ContainsKey(cube))
            {
                premutationSet.Add(cube, new HashSet<int>());
            }
            premutationSet[cube].Add(i);
        }       

        var resultSets = from item in premutationSet where item.Value.Count == k select item.Value;
        var result = new List<int>();

        foreach (var resultSet in resultSets) 
        {
            int[] intArray = new int[resultSet.Count];
            resultSet.CopyTo(intArray);
            Array.Sort(intArray);
            result.Add(intArray[0]);
        }
        
        result.Sort();
        foreach (var i in result)
        {
            Console.WriteLine(Math.Pow(i,3));
        }
    }
}