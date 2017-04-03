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
        int qn = int.Parse(Console.ReadLine());
        int[] ans = new int[qn];
        for (int i = 0; i < qn; i++)
        {
            int[] q = Console.ReadLine().Split(' ')
                                             .Select(val => int.Parse(val))
                                             .ToArray();
            char firstOrder = 'N';
            if(new int[]{2, 3}.Contains(dc.IndexOf(q[0]))) firstOrder = 'W';
            while(dc.rables[0] != q[0]) dc.Move(firstOrder);
            while(dc.rables[1] != q[1]) dc.Move('R');
            ans[i] = dc.rables[2];
        }
        foreach (int item in ans)
        {
            Console.WriteLine(item);
        }
    }

    class Dice
    {
        public int[] rables {get; set;}
        //[0]上[1]手前[2]右[3]左[4]奥[5]下
        public Dice(int[] iarr){
            rables = new int[6];
            Array.Copy(iarr, 0, this.rables, 0, iarr.Length);
        }

        public int IndexOf(int num){
            for (int i = 0; i < rables.Length; i++)
            {
                if(rables[i] == num) return i;
            }
            return -1;
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