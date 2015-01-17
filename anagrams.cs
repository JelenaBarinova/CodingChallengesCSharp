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
            Dictionary<char, int> countByLetter = new Dictionary<char, int>();
            var k = line.Length / 2;
            for (int i = 0; i < k; i++)
            {
                char letter = line[i];
                if (!countByLetter.ContainsKey(letter))
                {
                    countByLetter.Add(letter, 1);
                }
                else
                {
                    countByLetter[letter] = countByLetter[letter] + 1;    
                }
            }

            for (int i = k; i < line.Length; i++)
            {
                char letter = line[i];
                if (!countByLetter.ContainsKey(letter))
                {
                    res++;    
                }
                else
                {
                    countByLetter[letter] = countByLetter[letter] - 1;
                    if (countByLetter[letter] == 0) 
                    {
                        countByLetter.Remove(letter);
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