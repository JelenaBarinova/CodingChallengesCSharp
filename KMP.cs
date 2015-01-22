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

        Console.WriteLine(StringContainsAt(str1, str2));

    }
    static int StringContainsAt(string s, string word)
    {
        var arr = BuildKmpTable(word);
        int m = 0;
        int i = 0;

        while (m + i < s.Length)
        {
            if (word[i] == s[m + i])
            {
                if (i == word.Length - 1) return m;
                i++;
            }
            else 
            {
                if (arr[i] > -1)
                {
                    m = m + i - arr[i];
                    i = arr[i];
                }
                else
                {
                    i = 0;
                    m++;
                }
            }
        }
        return -1;
    }
    static int[] BuildKmpTable(string word) 
    {
        int[] arr = new int[word.Length];
        arr[0] = -1;
        arr[1] = 0;

        int p = 2;
        int c = 0; //the zero-based index in WORD of the next character of the current candidate substring

        while (p < word.Length)
        {
            //substring continues
            if (word[p - 1] == word[c])
            {
                c++;
                arr[p] = c;
                p++;
            }
            //sunbstring does not continue, but we can fallback to some point
            else if (c > 0)
            {
                c = arr[c];
            }
            //we have run out of candidates.  Note c = 0
            else
            {
                arr[c] = 0;
                p++;
            }
        }
        return arr;
    }
}