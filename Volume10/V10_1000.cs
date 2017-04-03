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
        string inputs;
        while((inputs = Console.ReadLine()) != null)
        {
            var tmp = inputs.Split(' ');
            Console.WriteLine(int.Parse(tmp[0]) + int.Parse(tmp[1]));
        }
    }
}
