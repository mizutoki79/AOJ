using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int[] inputs = Console.ReadLine().Split(' ')
                                         .Select(val => int.Parse(val))
                                         .ToArray();
        int n = inputs[0];
        int k = inputs[1];
        int[] w = new int[n];
        for (int i = 0; i < n; i++)
        {
            w[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(Solve(w, k));
    }

    static long Solve(int[] baggage, int k){
        long l = 0;
        long r = 100000 * 10000 + 1;
        long mid = (r + l) / 2;
        while(l < r - 1){
        //for(int i = 0; i < 10; i++){
            mid = (r + l) / 2;
            int num = NumberOfBaggage(baggage, mid, k);
            //Console.Error.WriteLine("num: {0}, l: {2}, mid: {1}, r: {3}", num, mid, l, r);
            //if(num == baggage.Length) break;
            if(num >= baggage.Length) r = mid;
            else l = mid;
        }
        return r;
    }

    static int NumberOfBaggage(int[] baggage, long P, int k){
        int j = 0;
        for (int i = 0; i < k; i++)
        {
            long sum = 0;
            while(sum + baggage[j] <= P){
                sum+= baggage[j];
                j++;
                if(j >= baggage.Length) return j;
            }
        }
        return j;
    }
}