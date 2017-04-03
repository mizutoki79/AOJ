using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
 
class Program
{
    static bool[,] adja;
    static int[] discoveryTime;
    static int[] finishTime;
    static int time = 0;
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        adja = new bool[n, n];
        discoveryTime = new int[n];
        finishTime = new int[n];
        for (int i = 0; i < n; i++)
        {
            int[] inputs = Console.ReadLine().Split(' ')
                                        .Select(val => int.Parse(val))
                                        .ToArray();
            for (int j = 0; j < inputs[1]; j++)
            {
                adja[inputs[0] - 1, inputs[2 + j] - 1] = true;
            }
        }
        for (int i = 0; i < n; i++)
        {
            if(discoveryTime[i] == 0) DepthFirstSearch(i);
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0} {1} {2}", i + 1, discoveryTime[i], finishTime[i]);
        }
    }

    static void DepthFirstSearch(int nodeNum)
    {
        discoveryTime[nodeNum] = ++time;
        for (int i = 0; i < adja.GetLength(1); i++)
        {
            if(adja[nodeNum, i] && discoveryTime[i] == 0)
            {
                DepthFirstSearch(i);
            } 
        }
        finishTime[nodeNum] = ++time;
    }
}
