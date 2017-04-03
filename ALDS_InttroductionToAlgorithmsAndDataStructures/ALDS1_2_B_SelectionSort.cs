using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static int numberOfSwap = 0;
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        int[] A = Console.ReadLine().Split(' ')
                                    .Select(val => int.Parse(val))
                                    .ToArray();
        SelectionSort(ref A, n);
        Console.WriteLine(String.Join(" ", A.Select(val => val.ToString()).ToArray()));
        Console.WriteLine(numberOfSwap);
    }

    static void SelectionSort(ref int[] arr, int n){
        for (int i = 0; i < n; i++)
        {
            int minj = i;
            for (int j = i; j < n; j++)
            {
                if(arr[j] < arr[minj]) minj = j;
            }
            if(i != minj) Swap(ref arr, i, minj);
        }
    }

    static void Swap(ref int[] arr, int index1, int index2){
        int tmp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = tmp;
        numberOfSwap++;
    }
}