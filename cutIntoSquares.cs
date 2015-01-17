/*
Problem Statement:
    Martha is interviewing at Subway. One of the rounds of the interview requires her to cut a bread of size l×b into smaller identical pieces such that each piece is a square having maximum possible side length with no left over piece of bread.
Input format: 
    The first line contains an integer T. T lines follow. Each line contains two space separated integers l and b which denote length and breadth of the bread.
Output format:
    T lines, each containing an integer that denotes the number of squares of maximum size, when the bread is cut as per the given condition.
Constraints:
    1 <= T <= 1000
    1 <= l, b <= 1000
Sample Input:
    2
    2 2
    6 9
Sample Output:
    1
    6
*/
using System;
using System.Collections.Generic;
using System.IO;
class Solution 
{
    static void Main(String[] args) 
    {
        var T = Int32.Parse(Console.ReadLine());
        for (int t = 0; t < T; t++)
        {
            string[] input = Console.ReadLine().Split();
            int l = Int32.Parse(input[0]);
            int b = Int32.Parse(input[1]);
            int res = l * b;
            int m = Math.Min(l, b);
            for (int i = m; i > 0; i--)
            {
                if (l % i == 0 && b % i == 0)
                {
                    res = (l / i) * (b / i);
                    break;
                }
            }
            Console.WriteLine(res);
        }       
    }
}