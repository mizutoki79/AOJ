using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program
{
    static string str1, str2;
    static int[,] _lcs;
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            str1 = Console.ReadLine();
            str2 = Console.ReadLine();
            _lcs = new int[str1.Length, str2.Length];
            Console.WriteLine(Lcs(str1.Length - 1, str2.Length - 1));
        }
    }

    static int Lcs(int i, int j)
    {
        if(i < 0 || j < 0 || i >= str1.Length || j >= str2.Length) return 0;
        else if(_lcs[i, j] != 0) return _lcs[i, j];
        else if(str1[i] == str2[j]) return _lcs[i, j] = Lcs(i - 1, j - 1) + 1;
        else return _lcs[i, j] = Math.Max(Lcs(i, j - 1), Lcs(i - 1, j));
    }
}
