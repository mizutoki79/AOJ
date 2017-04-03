using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        int[] S = Console.ReadLine().Split(' ')
                                         .Select(val => int.Parse(val))
                                         .ToArray();
        int q = int.Parse(Console.ReadLine());
        int[] T = Console.ReadLine().Split(' ')
                                         .Select(val => int.Parse(val))
                                         .ToArray();
        int cnt = 0;
        for (int i = 0; i < q; i++)
        {
            if(BinarySearch(S, T[i])) cnt++;
        }
        Console.WriteLine(cnt);
    }

    static bool BinarySearch<T>(IEnumerable<T> col, T key)
        where T : IComparable
    {
        int l = 0, r = col.Count();
        while(l < r){
            int mid = (r + l) / 2;
            if(col.ElementAtOrDefault<T>(mid).CompareTo(key) == 0) return true;
            else if(col.ElementAtOrDefault<T>(mid).CompareTo(key) < 0) l = mid + 1;
            else r = mid;
        }
        return false;
    }
}