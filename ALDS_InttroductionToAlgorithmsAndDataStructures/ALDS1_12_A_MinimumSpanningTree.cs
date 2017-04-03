using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
 
class Program
{
    static int n;
    static int[,] A;

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        A = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Trim().Split(' ');
            for (int j = 0; j < n; j++)
            {
                A[i, j] = inputs[j] == "-1" ? int.MaxValue : int.Parse(inputs[j]);
            }
        }

        Prim();
        Console.WriteLine(TotalWeight());
    }

    static int[] parent;
    static void Prim()
    {
        int[] weight = Enumerable.Repeat(int.MaxValue, n).ToArray();
        weight[0] = 0;
        bool[] isFinal = new bool[n];
        parent = Enumerable.Repeat(-1, n).ToArray();
        while (true)
        {
            int u = -1;
            int minv = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if(minv > weight[i] && !isFinal[i])
                {
                    u = i;
                    minv = weight[i];
                }
            }
            if(u == -1) break;
            isFinal[u] = true;
            for (int i = 0; i < n; i++)
            {
                if(!isFinal[i] && weight[i] > A[u, i])
                {
                    weight[i] = A[u, i];
                    parent[i] = u;
                }
            }
        }
    }
    static int TotalWeight()
    {
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            if(parent[i] != -1) sum += A[parent[i], i];
        }
        return sum;
    }
}
