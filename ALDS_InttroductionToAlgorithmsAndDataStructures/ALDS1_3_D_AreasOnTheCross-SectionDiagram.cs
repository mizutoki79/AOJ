using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        string s = Console.ReadLine();
        Stack<int> startStk = new Stack<int>(s.Length);
        //Stack<Tuple<int, int>> areaStk = new Stack<Tuple<int, int>>(s.Length / 2);
        Stack<int[]> astk = new Stack<int[]>(s.Length / 2);
        int area = 0;
        int totalArea = 0;
        int currentPosition = 0;
        foreach (char ch in s)
        {
            if(ch == '\\') startStk.Push(currentPosition);
            else if(ch == '/' && startStk.Count() > 0){
                int startPosition = startStk.Pop();
                area = currentPosition - startPosition;
                totalArea += area;
                int areaStart = startPosition;
                //while(areaStk.Count() > 0 && startPosition < areaStk.Peek().Item1){
                while(astk.Count() > 0 && startPosition < astk.Peek()[0]){
                    //var tmp = areaStk.Pop();
                    var tmp = astk.Pop();
                    //areaStart = tmp.Item1;
                    areaStart = tmp[0];
                    //area += tmp.Item2;
                    area += tmp[1];
                }
                //areaStk.Push(Tuple.Create(areaStart, area));
                astk.Push(new int[]{areaStart, area});
            }
            currentPosition++;
        }
        Console.WriteLine(totalArea);
        //Console.Write(areaStk.Count());
        Console.Write(astk.Count());
        //if(areaStack.Count() > 0) Console.Write(" {0}", string.Join(" ", areaStk.Select(val => val.Item2).Reverse()));
        if(astk.Count() > 0) Console.Write(" {0}", string.Join(" ", astk.Select(val => val[1].ToString() ).Reverse().ToArray() ) );
        Console.WriteLine();
    }
}