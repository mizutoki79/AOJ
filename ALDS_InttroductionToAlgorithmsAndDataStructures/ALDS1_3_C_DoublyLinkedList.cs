using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        LinkedList<int> ll = new LinkedList<int>();
        for (int i = 0; i < n; i++)
        {
            string[] order = Console.ReadLine().Split(' ');
            switch (order[0])
            {
                case "insert":
                    ll.AddFirst(int.Parse(order[1]));
                    break;
                case "delete":
                    ll.Remove(int.Parse(order[1]));
                    break;
                case "deleteFirst":
                    ll.RemoveFirst();
                    break;
                case "deleteLast":
                    ll.RemoveLast();
                    break;
            }
        }

        Console.WriteLine(string.Join(" ", ll.Select(elem => elem.ToString()).ToArray()));
    }
}

/*
public class LinkedList<T> : IEnumerable<T>{
    public class Node{
        T val;
        Node prev;
        Node next;
        int count;

        internal Node(T val, Node prev, Node next){
            this.val = val;
            this.prev = prev;
            this.next = next;
        }

        public T Value{
            get {return this.val;}
            set {this.val = value;}
        }

        public Node Next {
            get {return this.next;}
            internal set {this.next = value;}
        }

        public Node Previous{
            get {return this.prev;}
            set {this.prev = value;}
        }
    }

    Node dummy;

    public LinkedList(){
        this.dummy = new Node(default(T), null, null);
        this.dummy.Next = this.dummy;
        this.dummy.Previous = this.dummy;
    }

    public Node First{
        get { return this.dummy.Next; }
    }

    public Node Last{
        get { return this.dummy.Previous; }
    }


    public Node InsertAfter(Node n, T elem){
        Node m = new Node(elem, n, n,Next);
        n.Next.Previous = m;
        n.Next = m;
        count++;
        return m;
    }

    public Node InsertBefoure(Node n, T elem){
        Node m = new Node(elem, n, n.Next);
        n.Next.Previous = m;
        n.Next = m;
        count++;
        return m;
    }

    public Node Erase(Node n){
        if(n == this.dummy){
            return this.dummy;
        }
        n.Previous.Next = n.Next;
        n.Next.Previous = n.Previous;
        count--;
        return n.Next;
    }

    public Node InsertFirst(T elem){
        return InsertAfter(this.dummy, elem);
    }

    public Node InsertLast(T elem){
        return InsertBefoure(this.dummy, elem);
    }

    public void EraseFirst(){
        this.Erase(this.First);
    }
    public void EraseLast(){
        this.Erase(this.Last);
    }

    public int Count(){
        return this.count;
    }
}
*/