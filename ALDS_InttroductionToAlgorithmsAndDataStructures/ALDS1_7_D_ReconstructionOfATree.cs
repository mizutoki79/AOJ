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
        List<int> preorder = Console.ReadLine().Split(' ')
                                    .Select(val => int.Parse(val))
                                    .ToList();
        int[] inorder = Console.ReadLine().Split(' ')
                                    .Select(val => int.Parse(val))
                                    .ToArray();
        BinaryTree btree = new BinaryTree(n);
        btree.Reconstruct(ref preorder, inorder);
        btree.PostorderDisplay();
    }
}

class BinaryTree
{
    internal class Node
    {
        internal int Value {get; set;}
        internal Node parent, left, right;

        internal Node() : this(0) {}
        internal Node(int val) : this(val, null, "") {}
        internal Node(int val, Node parent, string direction)
        {
            this.Value = val;
            this.parent = parent;
            switch (direction)
            {
                case "right": this.parent.right = this; break;
                case "left": this.parent.left = this; break;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }


    private Node[] nodes;
    private Node this[int i]
    {
        get
        {
            return nodes[i];
        }
        set
        {
            this[i] = value;
        }
    }
    private Node root;

    public BinaryTree(int n)
    {
        nodes = new Node[n + 1];
        nodes[0] = new Node();
    }

    public Node Reconstruct(ref List<int> preorder, int[] inorder)
    {
        if(preorder.Count <= 0 || inorder.Length <= 0) return null;
        int center = preorder[0];
        preorder.RemoveAt(0);
        nodes[center] = new Node(center);
        if(this.root == null) this.root = nodes[center];
        int splitPoint = Array.IndexOf(inorder, center);
        if(splitPoint == -1) return null;
        if(splitPoint > 0)
        {
            int[] leftTree = new int[splitPoint];
            Array.Copy(inorder, 0, leftTree, 0, splitPoint);
            this[center].left = Reconstruct(ref preorder, leftTree);
        }
        if(inorder.Length > splitPoint + 1)
        {
            int[] rightTree = new int[inorder.Length - splitPoint - 1];
            Array.Copy(inorder, splitPoint + 1, rightTree, 0, inorder.Length - splitPoint - 1);
            this[center].right = Reconstruct(ref preorder, rightTree);
        }
        return this[center];
    }

    public void PostorderDisplay()
    {
        string str = "";
        Console.WriteLine(PostorderString(ref str, this.root).Trim());
    }
    private string PostorderString(ref string result, Node node)
    {
        if(node.left != null) PostorderString(ref result, node.left);
        if(node.right != null) PostorderString(ref result, node.right);
        result += " " + node.ToString();
        return result;
    }
}