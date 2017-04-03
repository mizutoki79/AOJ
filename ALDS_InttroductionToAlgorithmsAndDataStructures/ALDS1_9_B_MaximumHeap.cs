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
        Console.ReadLine();
        int[] inputs = Console.ReadLine().Split(' ')
                                    .Select(val => int.Parse(val))
                                    .ToArray();
        Heap maxHeap = new Heap(inputs);
        maxHeap.BuildMaxHeap();
        maxHeap.Display();
    }
}

class Heap
{
    private const int MaxSize = 500000;
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
        Count = size;
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
}
