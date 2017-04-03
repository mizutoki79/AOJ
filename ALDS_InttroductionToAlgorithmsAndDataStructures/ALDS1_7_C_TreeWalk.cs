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
        BinaryTree btree = new BinaryTree();
        for (int i = 0; i < n; i++)
        {
            int[] node = Console.ReadLine().Split(' ')
                                        .Select(val => int.Parse(val))
                                        .ToArray();
            btree.Insert(node[0], node[1], node[2]);
        }
        
        Console.WriteLine("Preorder");
        btree.PreorderDisplay();
        Console.WriteLine("Inorder");
        btree.InorderDisplay();
        Console.WriteLine("Postorder");
        btree.PostorderDisplay();
    }
}

class BinaryTree
{
    #region class Node define
    internal class Node
    {
        #region Node's fields and properties
        internal const int MaxValue = 25;
        public int Value {get; internal set;}
        internal Node parent, left, right;
        private int _depth = 0, _height = 0;
        internal int Depth
        {
            get
            {
                if(_depth != 0) return _depth;
                else if(parent == null) return _depth = 0;
                else return this._depth = this.parent.Depth + 1;
            }
        }
        internal int Height
        {
            get
            {
                if(_height != 0) return _height;
                else
                {
                    if(this.left != null) this._height = this.left.Height + 1;
                    if(this.right != null) this._height = Math.Max(_height, this.right.Height + 1);
                    return Math.Max(this._height, 0);
                }
            }
        }
        string Type
        {
            get
            {
                if(parent == null) return "root";
                else if(left == null && right == null) return "leaf";
                else return "internal node";
            }
        }
        internal Node Root
        {
            get
            {
                if(this.parent == null) return this;
                else return this.parent.Root;
            }
        }
        #endregion

        #region Node's constructor
        public Node(int val) : this(val, null, "null") {}
        public Node(int val, Node parent, string direction)
        {
            this.Value = val;
            this.parent = parent;
            switch (direction)
            {
                case "right":
                    this.parent.right = this;
                    break;
                case "left":
                    this.parent.left = this;
                    break;
            }
        }
        public Node(int val, Node left, Node right)
        {
            this.Value = val;
            this.left = left;
            this.right = right;
            this.left = this.right = this;
        }
        #endregion

        #region Node's methods
        internal static void ConnectNodes(Node parent, Node child, string direction)
        {
            child.parent = parent;
            switch (direction)
            {
                case "right": parent.right = child; break;
                case "left": parent.left = child; break;
            }
        }
        internal void Display()
        {
            int parentVal = this.parent == null ? -1 : this.parent.Value;
            int siblingVal = -1;
            if(this.parent != null && this.parent.left != null && this.parent.right != null)
            {
                siblingVal = this.parent.left == this ? this.parent.right.Value : this.parent.left.Value;
            }
            int degree = 0;
            if(this.left != null) degree++;
            if(this.right != null) degree++;
            Console.WriteLine(string.Format("node {0}: parent = {1}, sibling = {2}, degree = {3}, depth = {4}, height = {5}, {6}"
              , this.Value, parentVal, siblingVal, degree, this.Depth, this.Height, this.Type));
        }
        public override string ToString()
        {
            return this.Value.ToString();
        }

        #endregion
    }
    #endregion //class Node define

    Node Root {get; set;}
    public int Count {get; internal set;}
    private Node[] nodes = new Node[Node.MaxValue];
    internal Node this[int i]
    {
        get
        {
            return nodes[i];
        }
        private set
        {
            nodes[i] = value;
        }
    }

    public void Insert(int thisval, int leftval, int rightval)
    {
        this.Count++;
        if(this[thisval] == null) this[thisval] = new Node(thisval);
        this.Root = this[thisval].Root;
        if(leftval == -1) {}
        else if(this[leftval] == null) this[leftval] = new Node(leftval, this[thisval], "left");
        else Node.ConnectNodes(this[thisval], this[leftval], "left");
        if(rightval == -1) {}
        else if(this[rightval] == null) this[rightval] = new Node(rightval, this[thisval], "right");
        else Node.ConnectNodes(this[thisval], this[rightval], "right");
    }

    public void DisplayAll()
    {
        for (int i = 0; i < this.Count; i++)
        {
            this[i].Display();
        }
    }

    public void PreorderDisplay()
    {
        string str = "";
        Console.WriteLine(PreorderString(ref str, this.Root));
    }
    private string PreorderString(ref string result, Node node)
    {
        result += " " + node.ToString();
        if(node.left != null) PreorderString(ref result, node.left);
        if(node.right != null) PreorderString(ref result, node.right);
        return result;
    }
    public void InorderDisplay()
    {
        string str = "";
        Console.WriteLine(InOrderString(ref str, this.Root));
    }
    private string InOrderString(ref string result, Node node)
    {
        if(node.left != null) InOrderString(ref result, node.left);
        result += " " + node.ToString();
        if(node.right != null) InOrderString(ref result, node.right);
        return result;
    }
    public void PostorderDisplay()
    {
        string str = "";
        Console.WriteLine(PostorderString(ref str, this.Root));
    }
    private string PostorderString(ref string result, Node node)
    {
        if(node.left != null) PostorderString(ref result, node.left);
        if(node.right != null) PostorderString(ref result, node.right);
        result += " " + node.ToString();
        return result;
    }
}