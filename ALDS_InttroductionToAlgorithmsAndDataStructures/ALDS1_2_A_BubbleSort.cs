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
        int[] A =  Console.ReadLine().Split(' ')
                                     .Select(val => int.Parse(val))
                                     .ToArray();
        BubbleSort(ref A, n);
        Console.WriteLine(string.Join(" ", A.Select(val => val.ToString()).ToArray()));
        Console.WriteLine(numberOfSwap);
    }

    static void BubbleSort(ref int[] arr, int n){
        bool flag = true;
        while(flag){
            flag = false;
            for (int i = n - 1; i >= 1 ; i--)
            {
                if(arr[i] < arr[i - 1]){
                    Swap(ref arr, i, i - 1);
                    flag = true;
                }
            }
        }
    }

    static void Swap(ref int[] arr, int index1, int index2){
        int tmp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = tmp;
        numberOfSwap++;
    }
}