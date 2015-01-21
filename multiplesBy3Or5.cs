using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) 
    {
        var t_count = Int32.Parse(Console.ReadLine());
        for (int t = 0; t < t_count; t++)
        {
            var n = Int64.Parse(Console.ReadLine());   
            long sum = 0;
            for (int i = 3; i < n; i += 3) sum += i;
            for (int i = 5; i < n; i += 5) if (i % 3 != 0) sum += i;
            
            Console.WriteLine(sum);
        }
    }
}