using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        var Mountains = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            Mountains.Add(int.Parse(Console.ReadLine()));
        }
        var ans = Mountains.OrderByDescending(val => val)
                        .Where((val, idx) => idx < 3)
                        .ToArray();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(ans[i]);
        }
    }
}