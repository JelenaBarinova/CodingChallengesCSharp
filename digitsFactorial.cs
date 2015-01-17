using System;
using System.Collections.Generic;
using System.IO;
class Solution 
{
    static void Main(String[] args) 
    {
       var T = Int32.Parse(Console.ReadLine());
       var factorialbyDigit = new Dictionary<int, int>(); 
       for (int i = 0; i <= 9; i++)
       {
            factorialbyDigit.Add(i, Factorial(i));
       }

       int t_sum = 0;
       for (int i = 11; i <= T; i++)
       {
            int d = i;
            int f_sum = 0;
            while (d > 0)
            {
                f_sum += factorialbyDigit[d % 10]; 
                d = d / 10;
            }

            if (f_sum % i == 0)
            {
                t_sum += i;
            }
       }
       Console.WriteLine(t_sum);
    }
    
    static int Factorial(int x)
    {
        if ( x < 0)
        {
            return -1;
        }
        else if (x == 1 || x == 0)
        {
            return 1;
        }
        else
        {
            return x * Factorial(x - 1);
        }
    }
}