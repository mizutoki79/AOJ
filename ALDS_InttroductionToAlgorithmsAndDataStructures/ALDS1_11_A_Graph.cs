using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program
{
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        bool[,] adja = new bool[n, n];
        for (int i = 0; i < n; i++)
        {
            int[] inputs = Console.ReadLine().Split(' ')
                                        .Select(val => int.Parse(val))
                                        .ToArray();
            for (int j = 0; j < inputs[1]; j++)
            {
                adja[inputs[0] - 1, inputs[2 + j] - 1] = true;
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(j != 0) Console.Write(" ");
                Console.Write(adja[i, j] ? 1 : 0);
            }
            Console.WriteLine();
        }
    }
}
