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
            switch (inputs[0])
            {
                case "insert": btr.Insert(int.Parse(inputs[1])); break;
                case "find":
                    if(btr.Find(int.Parse(inputs[1])) != null) Console.WriteLine("yes");
                    else Console.WriteLine("no");
                    break;
                case "delete": btr.Delete(int.Parse(inputs[1])); break;
                case "print": btr.Print(); break;
            }
        }
    }
}

class BinaryTree
{
    public class Node
    {
        public int Value {get; internal set;}
        internal Node parent, left, right;
        internal Node Successor
        {
            get
            {
                Node node = null;
                if(this.right != null)
                {
                    node = this.right;
                    while(node.left != null) node = node.left;
                }
                else
                {
                    node = this;
                    while(node.parent.right == node) node = node.parent;
                    node = node.parent;
                }
                return node;
            }
        }
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

    public Node Find(int val)
    {
        if(this.root.Value == val) return this.root;
        Node node = this.root;
        while(node != null && node.Value != val)
        {
            if(val < node.Value) node = node.left;
            else node = node.right;
        }
        return node;
    }

    public void Delete(int val)
    {
        Node target = this.Find(val);
        Node node = null;
        if(target.left == null || target.right == null) node = target;
        else node = target.Successor;
        Node child = null;
        if(node.left != null) child = node.left;
        else child = node.right;
        if(child != null) child.parent = node.parent;
        if(node.parent == null) this.root = child;
        else if(node == node.parent.left) node.parent.left = child;
        else node.parent.right = child;
        if(node != target) target.Value = node.Value;
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
