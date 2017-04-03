using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
 
class Program
{
    const int MaxNum = 1000000;
    static bool[] isPrime = Enumerable.Repeat(true, MaxNum).ToArray();

    static void Main()
    {
        InitializePrimeArray();
        int n = 0;
        while (int.TryParse(Console.ReadLine(), out n))
        {
            var cnt = isPrime.Where((flg, idx) => flg && idx <= n).Count();
            Console.WriteLine(cnt);
        }
    }

    static void InitializePrimeArray()
    {
        for (int i = 0; i <= Math.Sqrt(MaxNum); i++)
        {
            if(i == 0 || i == 1) isPrime[i] = false;
            else if(isPrime[i])
            {
                for (int j = i * 2; j < MaxNum; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }
    }
}
