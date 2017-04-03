using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        Card[] cards1 = new Card[n];
        Card[] cards2 = new Card[n];
        string[] inputs = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
        {
            cards1[i].suit = inputs[i][0];
            cards1[i].value = int.Parse(inputs[i].Substring(1));
        }
        cards1.CopyTo(cards2, 0);

        BubbleSort(ref cards1, n);
        Print(cards1);
        Console.WriteLine("Stable");
        SelectionSort(ref cards2, n);
        Print(cards2);
        if(IsStable(cards1, cards2)) Console.WriteLine("Stable");
        else Console.WriteLine("Not stable");
    }

    static void BubbleSort(ref Card[] cards, int n){
        for (int i = 0; i < n; i++)
        {
            for (int j = n - 1; j >= i + 1 ; j--)
            {
                if(cards[j].value < cards[j - 1].value) Swap(ref cards, j, j - 1);
            }
        }
    }

    static void SelectionSort(ref Card[] cards, int n){
        for (int i = 0; i < n; i++)
        {
            int minj = i;
            for (int j = i; j < n; j++)
            {
                if(cards[j].value < cards[minj].value) minj = j;
            }
            if(i != minj) Swap(ref cards, i, minj);
        }
    }

    static void Swap(ref Card[] cards, int index1, int index2){
        Card tmp = cards[index1];
        cards[index1] = cards[index2];
        cards[index2] = tmp;
    }

    static bool IsStable(Card[] cards1, Card[] cards2){
        if(cards1.Length != cards2.Length) return false;
        for (int i = 0; i < cards1.Length; i++)
        {
            if(cards1[i] != cards2[i]) return false;
        }
        return true;
    }

    static void Print(Card[] cards){
        for (int i = 0; i < cards.Length; i++)
        {
            if(i != 0) Console.Write(" ");
            Console.Write("{0}{1}", cards[i].suit, cards[i].value);
        }
        Console.WriteLine();
    }
}

public struct Card
{
    public char suit {get; set;}
    public int value {get; set;}

    public static bool operator == (Card card1, Card card2){
        return card1.suit == card2.suit && card1.value == card2.value;
    }
    public static bool operator != (Card card1, Card card2){
        return !(card1 == card2);
    }

    // override object.Equals
    public override bool Equals (object obj)
    {
        //
        // See the full list of guidelines at
        //   http://go.microsoft.com/fwlink/?LinkID=85237
        // and also the guidance for operator== at
        //   http://go.microsoft.com/fwlink/?LinkId=85238
        //
        
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        // TODO: write your implementation of Equals() here
        Card c = (Card)obj;
        return this.suit.Equals(c.suit) && this.value.Equals(c.value);
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        return this.value ^ this.suit.GetHashCode();
    }
}