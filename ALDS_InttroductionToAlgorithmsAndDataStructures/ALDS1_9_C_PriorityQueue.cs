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
        Heap piorityQueue = new Heap();
        while(true)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            switch (inputs[0])
            {
                case "insert": piorityQueue.Insert(int.Parse(inputs[1])); break;
                case "extract": Console.WriteLine(piorityQueue.ExtractMax()); break;
                case "end": return;
            }
        }
    }
}

class Heap
{
    private const int MaxSize = 2000000;
    public int Count {get; set;} // = 0;
    private int[] elements;
    public int this[int i]
    {
        get {return elements[i];}
        set {elements[i] = value;}
    }
    public Heap() : this(MaxSize) {}
    public Heap(int size)
    {
        elements = new int[size];
        Count = 0;
    }
    public Heap(int[] array)
    {
        Count = array.Length;
        elements = new int[Count];
        for (int i = 0; i < Count; i++)
        {
            elements[i] = array[i];
        }
    }
    private int LeftOf(int i)
    {
        int val = 2 * (i + 1) - 1;
        return val < Count ? val : -1;
    }
    private int RightOf(int i)
    {
        int val = 2 * (i + 1);
        return val < Count ? val : -1;
    }
    private int ParentOf(int i)
    {
        int val = (i + 1) / 2 - 1;
        return val >= 0 ? val : -1;
    }
    public void BuildMaxHeap()
    {
        for (int i = Count / 2 - 1; i >= 0 ; i--)
        {
            Modify(i);
        }
    }
    private void Modify(int i)
    {
        int l = LeftOf(i);
        int r = RightOf(i);
        int largest = i;
        if(l != -1 && elements[l] > elements[i]) largest = l;
        if(r != -1 && elements[r] > elements[largest]) largest = r;
        if(largest != i)
        {
            Swap(i, largest);
            Modify(largest);
        }
    }
    private void Swap(int i, int j)
    {
        int tmp = elements[i];
        elements[i] = elements[j];
        elements[j] = tmp;
    }
    public void Display()
    {
        for (int i = 0; i < Count; i++)
        {
            Console.Write(" " + elements[i]);
        }
        Console.WriteLine();
    }

    public void Insert(int val)
    {
        int i = Count++;
        elements[i] = val;
        while(i > 0 && elements[ParentOf(i)] < elements[i])
        {
            Swap(ParentOf(i), i);
            i = ParentOf(i);
        }
    }
    public int ExtractMax()
    {
        if(Count <= 0) return -1;
        int tmp = elements[0];
        elements[0] = elements[--Count];
        Modify(0);
        return tmp;
    }
}
