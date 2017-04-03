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
    //static int[] discoveryTime;
    //static int[] finishTime;
    //static int time = 0;
    static int[] distance;
    static Queue<int> queue = new Queue<int>();

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        adja = new bool[n, n];
        distance = Enumerable.Repeat<int>(-1, n).ToArray();
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
        BreadthFirstDinstance();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0} {1}", i + 1, distance[i]);
        }
    }

    /*
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
    */

    static void BreadthFirstDinstance()
    {
        int d = 0;
        distance[0] = d;
        queue.Enqueue(0);
        while(queue.Count() > 0)
        {
            int nodeNum = queue.Dequeue();
            for (int i = 0; i < adja.GetLength(1); i++)
            {
                if(adja[nodeNum, i] && distance[i] == -1)
                {
                    queue.Enqueue(i);
                    distance[i] = distance[nodeNum] + 1;
                }
            }
        }
        
    }
}
