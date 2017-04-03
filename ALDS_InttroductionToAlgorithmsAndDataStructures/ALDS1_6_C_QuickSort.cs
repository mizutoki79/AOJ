using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        Tuple<char, int>[] cards = new Tuple<char, int>[n];
        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            cards[i] = new Tuple<char, int>(inputs[0][0], int.Parse(inputs[1]));
        }
        Tuple<char, int>[] origin = new Tuple<char, int>[n];
        cards.CopyTo(origin, 0);
        QuickSort(ref cards, 0, cards.Length - 1);
        Console.WriteLine(IsStable(cards, origin) ? "Stable" : "Not stable");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(cards[i].ToString());
        }
    }

    static void QuickSort(ref Tuple<char, int>[] A, int p, int r){
        if(p < r){
            int q = Partition(ref A, p, r);
            QuickSort(ref A, p, q - 1);
            QuickSort(ref A, q + 1, r);
        }
    }

    static int Partition(ref Tuple<char, int>[] A, int p, int r){
        int x = A[r].Item2;
        int i = p - 1;
        for (int j = p; j < r; j++)
        {
            if(A[j].Item2 <= x){
                i++;
                Swap(ref A, i, j);
            }
        }
        Swap(ref A, i + 1, r);
        return i + 1;
    }

    static void Swap(ref Tuple<char, int>[] A, int i, int j){
        try{
            Tuple<char, int> tmp = A[i];
            A[i] = A[j];
            A[j] = tmp;
        }
        catch(IndexOutOfRangeException ex){
            Console.Error.WriteLine(ex.Message);
        }
    }

    static bool IsStable(Tuple<char, int>[] A, Tuple<char, int>[] B){
        if(A.Length != B.Length) return false;
        Tuple<char, int>[] stableA = B.OrderBy(elem => elem.Item2).ToArray();
        for (int i = 0; i < A.Length; i++)
        {
            if(A[i] != stableA[i]) return false;
        }
        return true;
    }
}

class Tuple<T, U>{
    public T Item1 {get; set;}
    public U Item2 {get; set;}

    public Tuple(T item1, U item2){
        this.Item1 = item1;
        this.Item2 = item2;
    }

    public override string ToString(){
        return string.Format("{0} {1}", this.Item1, this.Item2);
    }
}