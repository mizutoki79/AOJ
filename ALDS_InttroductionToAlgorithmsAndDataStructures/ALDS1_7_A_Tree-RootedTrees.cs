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
        int n = int.Parse(Console.ReadLine());
        RootedTree rtree = new RootedTree();
        for (int i = 0; i < n; i++)
        {
            List<int> inputs = Console.ReadLine().Split(' ')
                                        .Select(val => int.Parse(val))
                                        .ToList();
            int p = inputs[0];
            inputs.RemoveRange(0, 2);
            rtree.Add(p, inputs);
        }
        for (int i = 0; i < n; i++)
        {
            rtree[i].Display();
        }
    }
}

class RootedTree
{
    public class Node
    {
        internal const int MaxValue = 100000;
        public int Value {get; internal set;}
        internal Node parent;
        internal List<Node> children = new List<Node>();
        private int _depth = 0;
        int Depth
        {
            get
            {
                if(this._depth != 0 ) return this._depth;
                else if(this.parent == null) return this._depth = 0;
                else return this._depth = this.parent.Depth + 1;
            }
            set
            {
                this._depth = value;
            }
        }
        string Type
        {
            get
            {
                if(parent == null) return "root";
                else if(children.Count == 0) return "leaf";
                else return "internal node";
            }
        }

        internal Node(int val, Node parent)
        {
            this.Value = val;
            if(parent != null)
            {
                this.parent = parent;
                this.parent.children.Add(this);
            }
        }

        public void Display()
        {
            Console.WriteLine("node {0}: parent = {1}, depth = {2}, {3}, [{4}]"
              , this.ToString(), this.parent != null ? this.parent.ToString() : "-1", this.Depth
              , this.Type, string.Join(", ", this.children.Select(elem => elem.ToString()).ToArray()));
        }

        public override string ToString(){
            return this.Value.ToString();
        }
    }

    private Node[] nodes = new Node[Node.MaxValue + 1];
    public Node this[int i]
    {
        get
        {
            return nodes[i];
        }
        set
        {
            nodes[i] = value;
        }
    }

    public void Add(int i, List<int> childList)
    {
        if(this[i] == null) this[i] = new Node(i, null);
        foreach (int j in childList)
        {
            if(this[j] == null) this[j] = new Node(j, this[i]);
            else
            {
                this[j].parent = this[i];
                this[i].children.Add(this[j]);
            }
        }
    }
}