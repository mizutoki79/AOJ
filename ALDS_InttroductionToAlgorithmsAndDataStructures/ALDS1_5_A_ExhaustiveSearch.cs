using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static bool[,] calculated;

    static void Main(){
        const int MaxM = 2000;
        int n = int.Parse(Console.ReadLine());
        int[] A = Console.ReadLine().Split(' ')
                        .Select(elem => int.Parse(elem))
                        .ToArray();
        int q = int.Parse(Console.ReadLine());
        int[] m = Console.ReadLine().Split(' ')
                        .Select(elem => int.Parse(elem))
                        .ToArray();
        
        calculated = new bool[n, MaxM];
        for (int i = 0; i < q; i++)
        {
            Console.WriteLine(TryMake(A, 0, m[i]) ? "yes" : "no");
        }
    }

    static bool TryMake(int[] source, int index, int target){
        if(index < source.Length && target >= 0){
            if(calculated[index, target] || target == 0 
            || TryMake(source, index + 1, target - source[index]) 
            || TryMake(source, index + 1, target)) {
                calculated[index, target] = true;
                return true;
            }
            else return false;
        }
        else if(target == 0) return true;
        else return false;
    }
}
