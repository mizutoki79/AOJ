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
        int.Parse(Console.ReadLine());
        List<int> elements = Console.ReadLine().Split(' ')
                                    .Select(val => int.Parse(val))
                                    .ToList();
        int m = int.Parse(Console.ReadLine());
        int[] targets = Console.ReadLine().Split(' ')
                                    .Select(val => int.Parse(val))
                                    .ToArray();
        elements.Sort();
        for (int i = 0; i < m; i++)
        {
            Console.WriteLine(ExhaustiveSearch(targets[i], elements) ? "yes" : "no");
        }
    }

    static bool ExhaustiveSearch(int target, List<int> elements)
    {
        if(target == 0) return true;
        List<int> lst = new List<int>();
        lst.AddRange(elements);
        for (int i = lst.Count - 1; i >= 0 ; i--)
        {
            if(target < lst[i]) lst.RemoveAt(i);
            else
            {
                int elem = lst[i];
                lst.RemoveAt(i);
                return ExhaustiveSearch(target - elem, lst) 
                  || ExhaustiveSearch(target, lst);
            }
        }
        return false;
    }
}