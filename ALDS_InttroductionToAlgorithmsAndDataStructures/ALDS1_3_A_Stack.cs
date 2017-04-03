using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        string[] inputs = Console.ReadLine().Split(' ');
        Stack<int> stk = new Stack<int>();
        int num, calculated = 0;
        for (int i = 0; i < inputs.Length; i++)
        {
            if(Int32.TryParse(inputs[i], out num)) stk.Push(num);
            else{
                int val2 = stk.Pop();
                int val1 = stk.Pop();
                switch (inputs[i])
                {
                    case "+":
                        calculated = val1 + val2;
                        break;
                    case "-":
                        calculated = val1 - val2;
                        break;
                    case "*":
                        calculated = val1 * val2;
                        break;
                }
                stk.Push(calculated);
            }
        }
        Console.WriteLine(stk.Pop());
    }
}