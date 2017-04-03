using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("{0}x{1}={2}", i + 1, j + 1, (i + 1) * (j + 1));
            }
        }
    }
}