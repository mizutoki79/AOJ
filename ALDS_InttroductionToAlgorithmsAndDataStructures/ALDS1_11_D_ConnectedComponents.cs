using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
 
class Program
{
    static List<int>[] friendsList;
    static int[] linkedId;

    static void Main()
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        friendsList = new List<int>[n];
        linkedId = new int[n];
        for (int i = 0; i < n; i++) friendsList[i] = new List<int>();
        for (int i = 0; i < m; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int s = int.Parse(inputs[0]);
            int t = int.Parse(inputs[1]);
            friendsList[s].Add(t);
            friendsList[t].Add(s);
        }
        int q = int.Parse(Console.ReadLine());
        AssignId();
        for (int i = 0; i < q; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int s = int.Parse(inputs[0]);
            int t = int.Parse(inputs[1]);
            Console.WriteLine(linkedId[s] == linkedId[t] ? "yes" : "no");
        }
    }

    static void AssignId()
    {
        int id = 1;
        for (int i = 0; i < linkedId.Length; i++)
        {
            AssignId(i, id++);
        }
    }
    private static void AssignId(int num, int id)
    {
        if(linkedId[num] != 0) return;
        linkedId[num] = id;
        foreach (var item in friendsList[num])
        {
            AssignId(item, id);
        }
    }
}
