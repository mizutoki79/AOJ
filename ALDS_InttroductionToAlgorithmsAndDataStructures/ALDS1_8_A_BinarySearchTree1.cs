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
        BinaryTree btr = new BinaryTree();
        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            if(inputs[0] == "insert") btr.Insert(int.Parse(inputs[1]));
            else btr.Print();
        }
    }
}

class BinaryTree
{
    public class Node
    {
        public int Value {get; set;}
        internal Node parent, left, right;
        internal Node(int val, Node parent)
        {
            this.Value = val;
            this.parent = parent;
        }
    }

    Node root;

    public void Insert(int val)
    {
        Node tmpParent = null;
        Node tmpPosition = this.root;
        while(tmpPosition != null)
        {
            tmpParent = tmpPosition;
            if(val < tmpParent.Value) tmpPosition = tmpParent.left;
            else tmpPosition = tmpParent.right; 
        }
        if(tmpParent == null) this.root = new Node(val, null);
        else if(val < tmpParent.Value) tmpParent.left = new Node(val, tmpParent);
        else tmpParent.right = new Node(val, tmpParent);
    }

    public void Print()
    {
        InorderedDisplay(this.root);
        Console.WriteLine();
        PreorderedDisplay(this.root);
        Console.WriteLine();
    }
    private void InorderedDisplay(Node node)
    {
        if(node == null) return;
        InorderedDisplay(node.left);
        Console.Write(" " + node.Value);
        InorderedDisplay(node.right);
    }
    private void PreorderedDisplay(Node node)
    {
        if(node == null) return;
        Console.Write(" " + node.Value);
        PreorderedDisplay(node.left);
        PreorderedDisplay(node.right);
    }
}
