using System;
using System.Collections.Generic;
using System.IO;
class Solution 
{
    static void Main(String[] args) 
    {
       var T = Int32.Parse(Console.ReadLine());
       
       for (int i = 11; i <= T; i++)
       {
            int d = i;
            int f_sum = 0;
            while (d > 0)
            {
                f_sum += Factorial(d % 10); 
                d = d / 10;
            }

            if (f_sum % i == 0)
            {
                Console.WriteLine(i);
            }
       }

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
    /*
    static int Factorial(int x)
    {
        int result = x < 0 ? -1 : x == 0 || x == 1 ? 1 : 1;
        if (x > 0)
        {
            Enumerable.Range(1, x).ToList<int>().ForEach(element => result = result * element);
        }
        return result;
    }*/
}