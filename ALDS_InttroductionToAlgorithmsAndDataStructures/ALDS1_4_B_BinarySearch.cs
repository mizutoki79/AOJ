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
        int i = 0;
        Array.Sort(T);
        for(int j = 0; j < q; j++)
        {
            while(i < n - 1 && S[i] < T[j]) i++;
            if(i < n && S[i] == T[j]) {
                cnt++;
                i++;
            }
        }
        Console.WriteLine(cnt);
    }
}