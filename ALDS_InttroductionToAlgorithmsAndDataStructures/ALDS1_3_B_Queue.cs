using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        string[] inputs = Console.ReadLine().Split(' ');
        int n = int.Parse(inputs[0]);
        int q = int.Parse(inputs[1]);
        Dictionary<string, int> processes = new Dictionary<string, int>();
        Queue<string> queue = new Queue<string>();
        for (int i = 0; i < n; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            processes.Add(inputs[0], int.Parse(inputs[1]));
            queue.Enqueue(inputs[0]);
        }
        int pastTime = 0;
        while (true)
        {
            string currentProcess;
            try{
                currentProcess = queue.Dequeue();
            }
            catch(InvalidOperationException){
                break;
            }
            if(processes[currentProcess] > q){
                pastTime += q;
                processes[currentProcess] -= q;
                queue.Enqueue(currentProcess);
            }
            else{
                pastTime += processes[currentProcess];
                processes[currentProcess] = 0;
                Console.WriteLine("{0} {1}", currentProcess, pastTime);
            }
        }
    }
}