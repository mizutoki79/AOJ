using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
 
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double debt = 100000.0;
        const double point = 1000.0;
        for (int i = 0; i < n; i++)
        {
            debt *= 1.05;
            debt = Math.Ceiling(debt / point) * point;
        }
        Console.WriteLine(debt);
    }
}
