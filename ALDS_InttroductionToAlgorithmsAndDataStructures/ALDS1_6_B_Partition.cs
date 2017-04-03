using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        int[] A = Console.ReadLine().Split(' ')
                                    .Select(val => int.Parse(val))
                                    .ToArray();
        int q = Partition(ref A, 0, A.Length - 1);
        //Console.WriteLine(string.Join(" ", A));
        for (int i = 0; i < n; i++)
        {
            if(i != 0) Console.Write(" ");
            if(i == q) Console.Write("[");
            Console.Write(A[i]);
            if(i == q) Console.Write("]");
        }
        Console.WriteLine();
    }

    static int Partition(ref int[] A, int p, int r){
        int x = A[r];
        int i = p - 1;
        for (int j = p; j < r; j++)
        {
            if(A[j] <= x){
                i++;
                Swap(ref A, i, j);
            }
        }
        Swap(ref A, i + 1, r);
        return i + 1;
    }

    static void Swap(ref int[] A, int i, int j){
        try{
            int tmp = A[i];
            A[i] = A[j];
            A[j] = tmp;
        }
        catch(IndexOutOfRangeException ex){
            Console.Error.WriteLine(ex.Message);
        }
    }
}
