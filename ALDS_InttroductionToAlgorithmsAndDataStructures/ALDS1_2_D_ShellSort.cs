using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static int cnt = 0;
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        int[] A = new int[n];
        for (int i = 0; i < n; i++)
        {
            A[i] = int.Parse(Console.ReadLine());
        }
        ShellSort(ref A, n);
        Console.WriteLine();
        Console.WriteLine(cnt);
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(A[i]);
        }
    }

    static void InsertionSort(ref int[] arr, int n, int g){
        for (int i = g; i <= n - 1; i++)
        {
            int tmp = arr[i];
            int j = i - g;
            while (j >= 0 && arr[j] > tmp)
            {
                arr[j + g] = arr[j];
                j = j - g;
                cnt++;
            }
            arr[j + g] = tmp;
        }
    }

    static void ShellSort(ref int[] arr, int n){
        cnt = 0;
        List<int> lg = new List<int>();
        int h = 1;
        while(h <= n){
            lg.Add(h);
            h = 3 * h + 1;
        }
        int m = lg.Count();
        Console.WriteLine(m);
        int[] G = lg.ToArray();
        for (int i = m - 1; i >= 0; i--)
        {
            if(i != m - 1) Console.Write(" ");
            Console.Write(G[i]);
            InsertionSort(ref arr, n, G[i]);
        }
    }
}