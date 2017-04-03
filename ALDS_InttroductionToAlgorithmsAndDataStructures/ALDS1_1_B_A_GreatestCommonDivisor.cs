using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        string[] inputs = Console.ReadLine().Split(' ');
        int x = int.Parse(inputs[0]);
        int y = int.Parse(inputs[1]);
        Console.WriteLine(Gcd(x, y));
    }

    static int Gcd(int x, int y){
        int larger, smaller;
        if(x >= y){
            larger = x;
            smaller = y;
        }
        else{
            larger = y;
            smaller = x;
        }
        while(larger % smaller != 0){
            int tmp = smaller;
            smaller = larger % smaller;
            larger = tmp;
        }
        return smaller;
    }
}