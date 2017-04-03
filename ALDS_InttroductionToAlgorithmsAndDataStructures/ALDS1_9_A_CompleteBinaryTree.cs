using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program
{
    static void Main()
    {
        int l = int.Parse(Console.ReadLine());
        int[] heap = Console.ReadLine().Split(' ')
                                    .Select(val => int.Parse(val))
                                    .ToArray();
        for (int i = 1; i < l + 1; i++)
        {
            Console.Write("node {0}: key = {1}, ", i, heap[i - 1]);
            if((i / 2) > 0) Console.Write("parent key = {0}, ", heap[i / 2 - 1]);
            if((2 * i) < l + 1) Console.Write("left key = {0}, ", heap[2 * i - 1]);
            if(((2 * i + 1) < l + 1)) Console.Write("right key = {0}, ", heap[2 * i]);
            Console.WriteLine();
        }
    }
}
