using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution 
{
    static void Main(String[] args) 
    {
        var T = Int32.Parse(Console.ReadLine());
        for (int t = 0; t < T; t++)
        {
            var N = Int64.Parse(Console.ReadLine());   
            string words = "";
            if (N == 0)
                words = "Zero";
            else
                words = numberToWords(N);
            Console.WriteLine(words);
       }
    }
    static string numberToWords(Int64 N)
    {
            var toTwenty = new[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var afterTwenty = new[] { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string res = "";
            if ((N / 1000000000) > 0)
            {
                res += numberToWords(N / 1000000000) + " Billion ";
                N = N % 1000000000;
            }
            if ((N / 1000000) > 0)
            {
                res += numberToWords(N / 1000000) + " Million ";
                N = N % 1000000;
            }
            if ((N / 1000) > 0)
            {
                res += numberToWords(N / 1000) + " Thousand ";
                N = N % 1000;
            }
            if ((N / 100) > 0)
            {
                res += numberToWords(N / 100) + " Hundred ";
                N = N % 100;
            }
            if (N < 20)
                res += toTwenty[N];
            else
            {
                res += afterTwenty[N / 10];
                if ((N % 10) > 0)
                    res += " " + toTwenty[N % 10];
            }
            return res;
    }  
}