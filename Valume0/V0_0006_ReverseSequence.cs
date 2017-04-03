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
        var str = Console.ReadLine();
        Console.WriteLine(str.Reverse().ToArray());
    }
}