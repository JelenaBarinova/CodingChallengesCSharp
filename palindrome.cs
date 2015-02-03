
//A palindrome is a word or phrase that has the same letters backwards and forwards.

//ex. "Elk rap song? No sparkle."
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution 
{
    static void Main() 
    {
       Console.WriteLine(isPalindrome("a nmmnka").ToString());
    }

    static bool isPalindrome(string str)
    {
        int i = 0, n = str.Length;
        string letters = "";
        while (i < n)
        {
            if (char.IsLetter(str[i]))
            {
                letters += char.ToUpper(str[i]);
            }
            i++;
        }
        i = 0;
        n = letters.Length;
        while (i < n/2)
        {
            if (letters[i] != letters[n - i - 1])
            {
                return false;
            }
            i++;
        }
        return true;
    }
}