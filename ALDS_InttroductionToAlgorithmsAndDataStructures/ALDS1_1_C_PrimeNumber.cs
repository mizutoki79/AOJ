using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if(IsPrime(num)) cnt++;
        }
        Console.WriteLine(cnt);
    }

    static bool IsPrime(int x){
        if(x == 2) return true;
        if(x % 2 == 0) return false;
        for (int i = 3; i <= Math.Sqrt(x); i += 2)
        {
            if(x % i == 0) return false;
        }
        return true;
    }
}