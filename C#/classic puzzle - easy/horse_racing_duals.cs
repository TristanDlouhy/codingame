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
class Solution
{
    static void Main(string[] args)
    {
        List<int> horsesStrength = new List<int>();
        int closestStrength = -1;

        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            int pi = int.Parse(Console.ReadLine());
            horsesStrength.Add(pi);
        }
        
        horsesStrength.Sort();

        for (int i = 0; i < (horsesStrength.Count - 1); i++)
        {
            int strength = horsesStrength[i + 1] - horsesStrength[i];
            
            if (closestStrength == -1 || strength < closestStrength)
                closestStrength = strength;
        }

        // output closest horses strenght
        Console.WriteLine(closestStrength);
    }
}