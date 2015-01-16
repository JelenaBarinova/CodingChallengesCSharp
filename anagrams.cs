using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main() {
     var T = Int32.Parse(Console.ReadLine());
     for (int t = 0; t < T; t++)
     {
        string line = Console.ReadLine();
        int res = 0;
        if (line.Length % 2 == 0)
        {
            Dictionary<char, int> hashMap = new Dictionary<char, int>();
            var k = line.Length / 2;
            for (int i = 0; i < k; i++)
            {
                if (!hashMap.ContainsKey(line[i]))
                {
                    hashMap.Add(line[i], 1);
                }
                else
                {
                    hashMap[line[i]] = (int)hashMap[line[i]] + 1;    
                }
            }
            for (int i = k; i < line.Length; i++)
            {
                if (!hashMap.ContainsKey(line[i]))
                {
                    res++;    
                }
                else
                {
                    hashMap[line[i]] = (int)hashMap[line[i]] - 1;
                    if ((int)hashMap[line[i]] == 0) 
                    {
                        hashMap.Remove(line[i]);
                    }
                }
            }
        }
        else
        {
            res = -1;
        }
        Console.WriteLine(res);
     }
    }
}