using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) 
    {
        var t_count = Int32.Parse(Console.ReadLine());
        
        Dictionary<int, Int64> sumByNumbers = new Dictionary<int, Int64>();
        sumByNumbers.Add(0, 0);
        int maxCachedNumber = 0;

        for (int t = 0; t < t_count; t++)
        {
            int n = Int32.Parse(Console.ReadLine());   
            Int64 sum = 0;
            n--;
            if (n <= maxCachedNumber)
            {
                int i = n;
                while (i > 0 && (i % 3 != 0 && i % 5 != 0)) i--;
                sum = sumByNumbers[i];
            }
            else
            {
                sum = sumByNumbers[maxCachedNumber];
                for (int i = maxCachedNumber + 1; i <= n; i++)
                {
                    if (i % 3 == 0 || i % 5 == 0)
                    {
                        sum += i;
                        sumByNumbers.Add(i, sum);  
                        maxCachedNumber = Math.Max(maxCachedNumber, i);
                    }
                }          
            }
            Console.WriteLine(sum);
        }
    }
}