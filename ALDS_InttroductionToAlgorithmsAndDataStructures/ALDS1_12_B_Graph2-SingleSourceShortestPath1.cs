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
    static Node[] G;

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        G = Enumerable.Range(0, n).Select(val => new Node(val)).ToArray();
        for (int i = 0; i < n; i++)
        {
            int[] inputs = Console.ReadLine().Split(' ')
                        .Select(elem => int.Parse(elem))
                        .ToArray();
            for (int j = 0; j < inputs[1]; j++)
            {
                G[inputs[0]].CreateLink(G[inputs[2 + 2 * j]], inputs[3 + 2 * j]);
            }
        }

        var result = Dijkstra();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0} {1}", i, result[i]);
        }
    }

    static int[] Dijkstra()
    {
        int[] d = Enumerable.Repeat(int.MaxValue, n).ToArray();
        d[0] = 0;
        bool[] isFinal = new bool[n];
        while(true)
        {
            int minv = int.MaxValue;
            int u = -1;
            for (int i = 0; i < n; i++)
            {
                if(!isFinal[i] && minv > d[i])
                {
                    minv = d[i];
                    u = i;
                }
            }
            if(u == -1) break;
            isFinal[u] = true;
            foreach (var item in G[u].Link)
            {
                if(!isFinal[item.Item1.Value] && d[u] + item.Item2 < d[item.Item1.Value])
                {
                    d[item.Item1.Value] = d[u] + item.Item2;
                }
            }
        }
        return d;
    }
}

class Node
{
    public int Value {get; private set;}
    public Node(int val)
    {
        this.Value = val;
    }
    public List<Tuple<Node, int>> Link {get; private set;} = new List<Tuple<Node, int>>();
    public void CreateLink(Node destination, int weight)
    {
        this.Link.Add(Tuple.Create(destination, weight));
    }
}
