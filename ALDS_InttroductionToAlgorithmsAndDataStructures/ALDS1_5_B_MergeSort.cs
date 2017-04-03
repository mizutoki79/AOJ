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
        
        Sort.MergeSort(ref S, 0, n);
        for (int i = 0; i < n; i++)
        {
            if(i != 0) Console.Write(" ");
            Console.Write(S[i]);
        }
        Console.WriteLine("\n{0}", Sort.cnt);
    }

    
}

class Sort{
    public static int cnt = 0;

    public static void Merge(ref int[] A, int left, int mid, int right){
        //Console.Error.WriteLine("left: {0}, mid: {1}, right: {2}", left, mid, right);
        int n1 = mid - left;
        int n2 = right - mid;
        //Console.Error.WriteLine("n1:{0}, n2:{1}", n1, n2);
        int[] L = new int[n1 + 1];
        Array.Copy(A, left, L, 0, n1);
        L[n1] = int.MaxValue;
        //Console.Error.WriteLine("L: {0}", string.Join(" ", L));
        int[] R = new int[n2 + 1];
        Array.Copy(A, mid, R, 0, n2);
        R[n2] = int.MaxValue;
        //Console.Error.WriteLine("R: {0}", string.Join(" ", R));
        int i = 0, j = 0;
        for (int k = left; k < right; k++)
        {
            cnt++;
            //Console.Error.WriteLine("L[i]:{0}, R[j]: {1}", L[i], R[j]);
            if(L[i] <= R[j]){
                A[k] = L[i];
                i++;
            }
            else{
                A[k] = R[j];
                j++;
            }
            //Console.Error.WriteLine("A[{0}] = {1}", k, A[k]);
        }
        //Console.Error.WriteLine(string.Join(" ", A));
    }

    public static void MergeSort(ref int[] A, int left, int right){
        if(left + 1 < right){
            int mid = (left + right) / 2;
            MergeSort(ref A, left, mid);
            MergeSort(ref A, mid, right);
            Merge(ref A, left, mid, right);
        }
    }
}
