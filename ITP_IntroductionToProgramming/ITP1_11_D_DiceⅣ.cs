using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        Dice[] dces = new Dice[n];
        for (int i = 0; i < n; i++)
        {
            int[] inputs = Console.ReadLine().Split(' ')
                                             .Select(val => int.Parse(val))
                                             .ToArray();
            dces[i] = new Dice(inputs);
        }
        bool flag = true;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if(dces[i].Equals(dces[j])) flag = false;
                if(!flag) break;
            }
            if(!flag) break;
        }
        Console.WriteLine(flag ? "Yes" : "No");
    }

    class Dice
    {
        const int NumOfFace = 6;
        public int[] rables {get; set;}
        //[0]上[1]手前[2]右[3]左[4]奥[5]下
        //[5 - index]で反対側になる
        public Dice(int[] iarr){
            rables = new int[NumOfFace];
            Array.Copy(iarr, 0, this.rables, 0, iarr.Length);
        }

        public int IndexOf(int num){
            for (int i = 0; i < rables.Length; i++)
            {
                if(rables[i] == num) return i;
            }
            return -1;
        }

        public void Rotate(int top, int front){
            char firstOrder = 'N';
            if(new int[]{2, 3}.Contains(this.IndexOf(top))) firstOrder = 'W';
            while(this.rables[0] != top) this.Move(firstOrder);
            while(this.rables[1] != front) this.Move('R');
            //Console.Error.WriteLine("Rotated: {0}", string.Join(" ", this.rables));
        }

        public bool Equals(Dice dice){
            int[] thisDiceNumber = new int[NumOfFace];
            Array.Copy(this.rables, 0, thisDiceNumber, 0, NumOfFace);
            int[] comparedDiceNumber = new int[NumOfFace];
            Array.Copy(dice.rables, 0, comparedDiceNumber, 0, NumOfFace);
            int top1, front1;
            /*var result = */Search(thisDiceNumber,out top1, out front1);
            //int top1 = result.Item1;
            //int front1 = result.Item2;
            int top2, front2;
            /*result = */Search(comparedDiceNumber,out top2, out front2);
            //int top2 = result.Item1;
            //int front2 = result.Item2;
            if(top1 != top2 || front1 != front2) return false;
            Dice thisDice = new Dice(thisDiceNumber);
            thisDice.Rotate(top1, front1);
            Dice comparedDice = new Dice(comparedDiceNumber);
            comparedDice.Rotate(top2, front2);
            return thisDice.rables.SequenceEqual(comparedDice.rables);
        }

        public /*Tuple<int, int>*/ void Search(int[] diceNumbers, out int first, out int second){
            var lowerDuplicateNumbers = diceNumbers.GroupBy(val => val)
                                                   .OrderBy(val => val.Count())
                                                   .ThenBy(val => val.Key)
                                                   .Select(val => val.Key)
                                                   .ToArray();
            /*int */first = lowerDuplicateNumbers[0];
            int tmpfirst = first;
            /*int */second = diceNumbers.Where((val, idx) => idx != Array.IndexOf(diceNumbers, tmpfirst) 
                                    && idx != NumOfFace - 1 - Array.IndexOf(diceNumbers, tmpfirst))
                                    .GroupBy(val => val)
                                    .OrderBy(val => val.Count())
                                    .ThenBy(val => val.Key)
                                    .FirstOrDefault()
                                    .Key;
            //Console.Error.WriteLine("first: {0}, second: {1}", first, second);
            //return Tuple.Create(first, second);
        }

        public void Move(char direction){
            int tmp;
            switch (direction)
            {
                case 'N':   //奥方向
                    tmp = rables[0];
                    rables[0] = rables[1];
                    rables[1] = rables[5];
                    rables[5] = rables[4];
                    rables[4] = tmp;
                    break;
                case 'W':   //左方向
                    tmp = rables[0];
                    rables[0] = rables[2];
                    rables[2] = rables[5];
                    rables[5] = rables[3];
                    rables[3] = tmp;
                    break;
                case 'S':   //下方向
                    tmp = rables[0];
                    rables[0] = rables[4];
                    rables[4] = rables[5];
                    rables[5] = rables[1];
                    rables[1] = tmp;
                    break;
                case 'E':   //右方向
                    tmp = rables[0];
                    rables[0] = rables[3];
                    rables[3] = rables[5];
                    rables[5] = rables[2];
                    rables[2] = tmp;
                    break;
                default:
                    tmp = rables[1];
                    rables[1] = rables[2];
                    rables[2] = rables[4];
                    rables[4] = rables[3];
                    rables[3] = tmp;
                    break;
            }
        }
    }
}