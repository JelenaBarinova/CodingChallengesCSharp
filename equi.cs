using System;
class Solution {

    static void Main()
    {
        
        //int[] vector = {1, 5, 4, 6, 9, 3, 0, 0, 5, 3, 0, 0, 7, 0, 0, 2, 4, 7}; //vector with 0, result 4
        //int[] vector = {500, 1, -2, -1, 2};
        //int[] vector = {2147483640, -2147483640};
        int[] vector = {-1, 0, 1};
        Console.WriteLine("Given vector: ");
        foreach(int item in vector)
        {
            Console.Write(item.ToString() + " ");        
        }

        int equi = Equi(vector);
        Console.WriteLine("\nEquilibrium = {0}", equi);
    }
    static int Equi(int[] A) {
        int n = A.Length;
        if (n == 0) return -1;

        int[] sum_to_right = new int[n]; 
        int[] sum_to_left = new int[n];
        sum_to_right[0] = A[0];
        sum_to_left[n - 1] = A[n - 1];

        int i = 1, j = n - 2;        
        while (i < n - 1 && j > 0)
        {
            sum_to_right[i] = sum_to_right[i - 1] + A[i];
            sum_to_left[j] = sum_to_left[j + 1] + A[j];
            i++;
            j--;
        }
        Console.WriteLine();
        foreach(long item in sum_to_right)
        {
            Console.Write(item.ToString() + " ");        
        }
        Console.WriteLine();
        foreach(long item in sum_to_left)
        {
            Console.Write(item.ToString() + " ");        
        }
        Console.WriteLine();
        
        if (n > 1 && sum_to_right[n - 2] == 0) return n - 1;
        if (n > 1 && sum_to_left[1] == 0) return 0;

        for (int ii = 0; ii < n; ii++)
        {
            if (sum_to_right[ii] == sum_to_left[ii])
            {
                return ii;
            }
        }
        return -1;
    }
}