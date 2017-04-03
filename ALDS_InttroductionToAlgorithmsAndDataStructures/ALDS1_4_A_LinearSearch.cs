using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int.Parse(Console.ReadLine());  //int n
        int[] S = Console.ReadLine().Split(' ')
                                         .Select(val => int.Parse(val))
                                         .ToArray();
        int.Parse(Console.ReadLine());  //int q
        int[] T = Console.ReadLine().Split(' ')
                                         .Select(val => int.Parse(val))
                                         .ToArray();
        int cnt = 0;
        foreach (int i in T)
        {
            if(S.Contains(i)) cnt++;
        }
        Console.WriteLine(cnt);
    }
}