using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        List<Node> nodes = new List<Node>();

        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways

        // create alle nodes
        for (int i = 0; i < N; i++)
            nodes.Add(new Node());

        //Console.Error.WriteLine("Number of node: {0} Number of Links: {1} Number of Exit: {2}", N, L, E);

        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);

            // add the children
            nodes[N1].AddChildren(nodes[N2]);
        }

        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            nodes[EI].IsGateway = true;
        }

        //foreach (Node n in nodes)
        //{
        //    Console.Error.WriteLine("NodeKey: {0} IsGateway: {1} Children:", n.Key, n.IsGateway);

        //    foreach (Node child in n.Children)
        //        Console.Error.WriteLine("        {0}", child.Key);
        //}

        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn

            //Console.Error.WriteLine("Agent: {0} Gateway: ", SI);
            
            Console.WriteLine(Node.GetCutLinks(nodes[SI]));
        }
    }
}

class Node
{
    private int key;
    private bool isGateway = false;
    private List<Node> children = new List<Node>();
    
    public int Key { get { return key; } }
    public Node[] Children { get { return children.ToArray(); } }
    public bool IsGateway { set; get; }

    private static int lastKey = -1;
    private static int GetKey()
    {
        lastKey++;
        return lastKey;
    }
    public static string GetCutLinks(Node n)
    {
        //check node has childrens
        if (n.Children.Count() <= 0) return "no child";
        
        int childNode = -1;
        
        foreach (Node child in n.Children)
        {
            childNode = child.Key;
            
            if(child.IsGateway) break;
        }
        
        // call remove child
        n.RemoveChildren(n.children.Find(x => x.Key == childNode));

        // return cut links
        return string.Format("{0} {1}", n.Key, childNode);
    }

    public Node()
    {
        key = GetKey();
    }

    public void AddChildren(Node node)
    {
        if (!children.Contains(node))
        {
            children.Add(node);
            node.AddChildren(this);
        }
    }

    public void RemoveChildren(Node node)
    {
        if (children.Contains(node)) return;
        
        children.Remove(node);
        node.RemoveChildren(this);
    }
}