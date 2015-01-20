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
        var n = str1.Length;
        if (n != str2.Length) return false;

        //find the beginning of the first string in second string
        var i = 0;
        while (i < n && str1[0] != str2[i]) i++;

        if (i == n) return false;

        //iterate through first string and compare to cycled second
        for (int j = 0; j < n; j++) if (str1[j] != str2[(j + i) % n]) return false; 

        return true;
    }
}