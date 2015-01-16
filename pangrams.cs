/*
Problem Statement:
    Roy wanted to increase his typing speed for programming contests. So, his friend advised him to type the sentence "The quick brown fox jumps over the lazy dog" repeatedly because it is a pangram. ( pangrams are sentences constructed by using every letter of the alphabet at least once. )
    After typing the sentence several times, Roy became bored with it. So he started to look for other pangrams.
    Given a sentence s, tell Roy if it is a pangram or not.
Input Format:
    Input consists of a line containing s.
Constraints: 
    Length of s can be atmost 103 (1≤|s|≤103) and it may contain spaces, lowercase and uppercase letters. Lowercase and uppercase instances of a letter are considered same.
Output Format:
    Output a line containing pangram if s is a pangram, otherwise output not pangram.
Sample Input #1:
    We promptly judged antique ivory buckles for the next prize    
Sample Output #1:
    pangram
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution 
{
    static void Main(String[] args) 
    {
        var str = Console.ReadLine();
        int R = 'Z' - 'A' + 1;
        if (str.Length < R)
        {
            Console.WriteLine("not pangram");
        }
        else
        {
            HashSet<char> ht = new HashSet<char>();
            for (int i = 0; i < str.Length; i++)
            {
                char c = char.ToUpper(str[i]);
                if (c >= 'A' && c <= 'Z')
                {
                    if (!ht.Contains(c))
                        ht.Add(c);
                }
            }
            if (ht.Count == R)
                Console.WriteLine("pangram");
            else
                Console.WriteLine("not pangram");
        }
    }
}