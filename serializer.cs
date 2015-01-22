/*
Serialize/deserialize a vector of strings
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution 
{
    static void Main()
    {
        
        string[] strings = {"AAA", "BB", "CCCC"};

        Console.WriteLine("Given vector: ");
        foreach(string item in strings)
            Console.Write(item.ToString() + " ");        
        
        byte[][] serialized = Serialize(strings);

        Console.WriteLine("\nSerialized: ");
        Console.WriteLine(BytesToString(serialized));

        string[] deserialized = Deserialize(serialized);

        Console.WriteLine("Vector after deserialization: ");
        foreach(string item in deserialized)
            Console.Write(item.ToString() + " ");
        Console.WriteLine();
    }

    static byte[][] Serialize(string[] strings)
    {
        int n = strings.Length;

        byte[][] serialized = new byte[n * 2][];

        int j = 0;
        for (int i = 0 ; i < n; i++)
        {
            string s = strings[i];

            serialized[j] = BitConverter.GetBytes(s.Length);
            j++;
            serialized[j] = new byte[s.Length];
            
            serialized[j++] = System.Text.Encoding.UTF8.GetBytes(s);  

        }
        return serialized;
    }

    static string[] Deserialize(byte[][] bytes)
    {
        var n = bytes.Length;

        string[] strings = new string[n / 2];
        
        for (int i = 0; i < n; i += 2)
        {
            //int size = BitConverter.ToInt32(bytes[i], 0);
            string word = "";
            
            byte[] wordInBytes = bytes[i + 1];
            word = System.Text.Encoding.UTF8.GetString(wordInBytes);
            Console.WriteLine("adding word = {0} into vector at {1}", word, i / 2);
            strings[i / 2] = word;
        }

        return strings;
    }

    static string BytesToString(byte[][] bytes)
    {
        var strBulder = new System.Text.StringBuilder();
        foreach (byte[] word in bytes)
        {
            strBulder.Append((BitConverter.ToString(word) + " "));
        }
        return strBulder.ToString();
    }
}