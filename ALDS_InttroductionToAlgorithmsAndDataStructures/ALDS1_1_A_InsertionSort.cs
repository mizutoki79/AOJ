using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        int[] A = new int[n];
        for (int i = 0; i < n; i++)
        {
            A[i] = int.Parse(inputs[i]);
        }
        InsertionSort(ref A, n);
    }

    static void InsertionSort(ref int[] arr, int n){
        for (int i = 0; i < n; i++)
        {
            int tmp = arr[i];
            int j = i - 1;
            while(j >= 0 && arr[j] > tmp){
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = tmp;
            
            Console.WriteLine(String.Join(" ", arr.Select(val => val.ToString()).ToArray()));
        }
    }
}