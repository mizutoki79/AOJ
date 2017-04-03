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
        Dice dc = new Dice(inputs);
        string order = Console.ReadLine();
        foreach (char ch in order)
        {
            dc.Move(ch);
        }
        Console.WriteLine(dc.rables[0]);
    }

    class Dice
    {
        public int[] rables {get; set;}
        //[0]上[1]手前[2]右[3]左[4]奥[5]下
        public Dice(int[] iarr){
            rables = new int[6];
            Array.Copy(iarr, 0, this.rables, 0, iarr.Length);
        }
        public void Move(char direction){
            int tmp;
            switch (direction)
            {
                case 'N':
                    tmp = rables[0];
                    rables[0] = rables[1];
                    rables[1] = rables[5];
                    rables[5] = rables[4];
                    rables[4] = tmp;
                    break;
                case 'W':
                    tmp = rables[0];
                    rables[0] = rables[2];
                    rables[2] = rables[5];
                    rables[5] = rables[3];
                    rables[3] = tmp;
                    break;
                case 'S':
                    tmp = rables[0];
                    rables[0] = rables[4];
                    rables[4] = rables[5];
                    rables[5] = rables[1];
                    rables[1] = tmp;
                    break;
                case 'E':
                    tmp = rables[0];
                    rables[0] = rables[3];
                    rables[3] = rables[5];
                    rables[5] = rables[2];
                    rables[2] = tmp;
                    break;
            }
        }
    }
}