/*
A Program to check if strings are rotations of each other or not
Given a string s1 and a string s2, write a snippet to say whether s2 is a rotation of s1 using only one call to strstr routine?
(eg given s1 = ABCD and s2 = CDAB, return true, given s1 = ABCD, and s2 = ACBD , return false)
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution 
{
    static void Main()
    {
        var str1 = Console.ReadLine();
        var str2 = Console.ReadLine();
        Console.WriteLine(IsRotation(str1, str2));
    }

    static bool IsRotation(string str1, string str2) 
    {
        if (str1.Length != str2.Length) return false;
        
        string s = str1 + str2;
        int[] t = BuildKmpTable(str2);

        int i = 0, j = 0;
        while (s[i] != str2[0]) i++; 
        
        while (i < s.Length && j < str2.Length)
        {        
            if (s[i] == str2[j])
            {
                i++;
                j++;
            } 
            else
            {
                i -= t[j];
                j = t[j];
            }
            if (j == str2.Length) 
                return true;
        }
        return false;
    }

    static int[] BuildKmpTable(string word)
    {
        int[] t = new int[word.Length];
        t[0] = -1;
        t[1] = 0;
        int p = 2, c = 0;

        while (p < word.Length)
        {
            //we have a countinuous pattern match
            if (word[p - 1] == word[c])
            {
                c++;
                t[p] = c;
                p++;
            }
            //if no match, but we were comparint not to the first letter in prefix
            else if (c > 0)
            {
                c = t[c];
            }
            //no match, move on
            else
            {
                t[p] = 0;
                p++;
            }
        }
        return t;
    }
}