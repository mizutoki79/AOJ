using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program
{
    static int[] dimention;
    static int[,] numOfMulti;
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        dimention = new int[n + 1];
        numOfMulti = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            int[] inputs = Console.ReadLine().Split(' ')
                                        .Select(val => int.Parse(val))
                                        .ToArray();
            if(i == 0) dimention[0] = inputs.First();
            dimention[i + 1] = inputs.Last();
        }
        //Console.Error.WriteLine(string.Join(" ", dimention));
        Console.WriteLine(NumberOfMultiplication(0, n - 1));
    }

    
    static int NumberOfMultiplication(int i, int j)
    {
        //Console.Error.Write("i = {0}, j = {1}: ", i, j);
        if(i == j) return 0;
        else if(numOfMulti[i, j] != 0) return numOfMulti[i, j];
        else if(i + 1 == j) return numOfMulti[i, j] = dimention[i] * dimention[j] * dimention[j + 1];
        else return numOfMulti[i, j] = Enumerable.Range(i, j - i)
                                                 .Select(k => NumberOfMultiplication(i, k) 
                                                   + NumberOfMultiplication(k + 1, j) 
                                                   + dimention[i] * dimention[k + 1] * dimention[j + 1])
                                                 .Min();
        //Console.WriteLine("numOfMulti[{0}, {1}] = {2}", i, j, numOfMulti[i, j]);
        // return numOfMulti[i, j];
    }
}
