/*
Serialize/deserialize a vector of strings
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
class Solution 
{
    const int maxWordLength = 10; //max word lenght
    static void Main()
    {
        
        string[] strings = {"AAA", "BB", "CCCC", "MNAxjdv"};

        Console.WriteLine("Given vector: ");
        foreach(string item in strings)
        {
            Console.Write(item.ToString() + " ");        
        }

        byte[] serialized = Serialize2(strings);

        Console.WriteLine("\nSerialized: {0}", BitConverter.ToString(serialized));

        string[] deserialized = Deserialize2(serialized);

        Console.WriteLine("Vector after deserialization: ");
        foreach(string item in deserialized)
        {
            Console.Write(item.ToString() + " ");
        }
        Console.WriteLine();
    }

    static byte[] Serialize2(string[] strings) 
    {
        var bytes = new List<byte>();
        foreach(var word in strings)
        {
            bytes.AddRange(BitConverter.GetBytes(word.Length));
            bytes.AddRange(Encoding.UTF8.GetBytes(word));
        }

        return bytes.ToArray();
    }

    static byte[] Serialize(string[] strings)
    {
        int n = strings.Length;
        byte[] serialized = new byte[n * (maxWordLength + sizeof(int))];

        int j = 0;
        for (int i = 0 ; i < n; i++)
        {
            string word = strings[i];

            byte[] wordLength = BitConverter.GetBytes(word.Length); //letter count
            for (int k = 0; k < wordLength.Length; k++)
                serialized[j++] = wordLength[k];
            
            byte[] wordInBytes = System.Text.Encoding.UTF8.GetBytes(word); //letters to byte[]
            for (int k = 0; k < wordInBytes.Length; k++)
                serialized[j++] = wordInBytes[k];
        }

        return serialized;
    }

    static string[] Deserialize2(byte[] bytes) 
    {
        var strings = new List<string>();

        int i = 0;
        while(i < bytes.Length)
        {
            int size = BitConverter.ToInt32(bytes, i);
            i += sizeof(int);
            byte[] wordInBytes = new byte[size];
            for (int j = 0; j < size; j++)
            {
                wordInBytes[j] = bytes[i++];
            }
            strings.Add(Encoding.UTF8.GetString(wordInBytes));
        }

        return strings.ToArray();
    }

    static string[] Deserialize(byte[] bytes)
    {
        var n = bytes.Length;
        string[] strings = new string[n / (sizeof(int) + maxWordLength)];
        
        int i = 0, k = 0;
        while (i < n)
        {
            int size = BitConverter.ToInt32(bytes, i);
            if (size == 0) break;
            i += sizeof(int);

            byte[] wordInBytes = new byte[size];
            for (int j = 0; j < size; j++)
                wordInBytes[j] = bytes[i++];
 
            strings[k++] = System.Text.Encoding.UTF8.GetString(wordInBytes);
        }

        return strings;
    }
}