using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can use Console.WriteLine for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public static void Main()
    {
        string number = "132";
        string happy = solution(number);
        Console.WriteLine(happy);
    }

    public static string solution(string S) {
        int digits = S.Length;
        long number = long.Parse(S);
        
        if (number <= 10) return "11";
        
        if (digits % 2 == 0)
        {
            var left = S.Substring(0,digits / 2);
            //var right = S.Substring(digits / 2);
            
            var candidate = long.Parse(left + left);
            while (candidate <= number)
            {
                left = (long.Parse(left) + 1).ToString();
                candidate = long.Parse(left + left);
            }
            
            return candidate.ToString();
        }
        else
        {
            var left = (Math.Pow(10, digits/2)).ToString();
            
            return left + left;   
        }
    }
}
