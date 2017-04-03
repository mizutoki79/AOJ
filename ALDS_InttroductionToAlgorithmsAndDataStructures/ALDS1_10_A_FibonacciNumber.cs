using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(Fibonacci(n));
    }

    const int MaxN = 44;
    static int[] F = new int[MaxN + 1];
    static int Fibonacci(int i)
    {
        if(F[i] != 0) return F[i];
        else if(i == 0 || i == 1) return F[i] = 1;
        else return F[i] = Fibonacci(i - 1) + Fibonacci(i - 2);
    }
}
