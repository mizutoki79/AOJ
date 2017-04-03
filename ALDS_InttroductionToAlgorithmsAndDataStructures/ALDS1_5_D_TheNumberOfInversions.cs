using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int l = int.Parse(Console.ReadLine());
        int[] A = Console.ReadLine().Split(' ')
                                    .Select(val => int.Parse(val))
                                    .ToArray();
        long ans = Divide(ref A, 0, l);
        Console.WriteLine(ans);
    }

    static long Divide(ref int[] A, int left, int right)
    {
        if(left + 1 < right)
        {
            int mid = (left + right) / 2;
            long v1 = Divide(ref A, left, mid);
            long v2 = Divide(ref A, mid, right);
            long v3 = Merge(ref A, left, mid, right);
            return v1 + v2 + v3;
        }
        else return 0L;
    }

    static long Merge(ref int[] A, int left, int mid, int right)
    {
        int llength = mid - left;
        int rlength = right - mid;
        int[] L = new int[llength + 1];
        int[] R = new int[rlength + 1];
        Array.Copy(A, left, L, 0, llength);
        Array.Copy(A, mid, R, 0, rlength);
        L[llength] = int.MaxValue;
        R[rlength] = int.MaxValue;
        //Console.Error.WriteLine("L: {0}", string.Join(" ", L));
        //Console.Error.WriteLine("R: {0}", string.Join(" ", R));
        int i = 0, j = 0, k;
        long cnt = 0;
        do
        {
            k = i + j;
            //Console.Error.WriteLine("i: {0}, j: {1}, k: {2}", i, j, k);
            if(L[i] > R[j])
            {
                //Console.Error.WriteLine("L{0} R{1}", L[i], R[j]);
                A[left + k] = R[j++];
                cnt += llength - i;
            }
            else A[left + k] = L[i++];
        } while (k < llength + rlength - 1);
        //Console.Error.WriteLine("cnt: {0}", cnt);
        return cnt;
    }
}
