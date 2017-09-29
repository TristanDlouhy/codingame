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
        int n = int.Parse(Console.ReadLine());

        int highestStockMarket = int.MinValue;
        int lowestStockMarket = int.MaxValue;
        int maxLoss = 0;
        bool isGoHeigh = false;

        string[] inputs = Console.ReadLine().Split(' ');

        for (int i = 0; i < n; i++)
        {
            int v = int.Parse(inputs[i]);
            Console.Error.WriteLine("{0}", v);

            if (highestStockMarket == int.MinValue && lowestStockMarket == int.MaxValue)
            {
                highestStockMarket = v;
                lowestStockMarket = v;
            }
            else
            {
                if (highestStockMarket < v)
                {
                    highestStockMarket = v;
                    isGoHeigh = true;
                }
                else if (lowestStockMarket > v || isGoHeigh)
                {
                    lowestStockMarket = v;

                    int tmpCalc = (highestStockMarket - lowestStockMarket) * -1;

                    if (tmpCalc < maxLoss)
                    {
                        Console.Error.WriteLine("tmpCalc{0} > maxLoss{0}", tmpCalc, maxLoss);
                        maxLoss = tmpCalc;
                    }
                }
            }
        }

        Console.WriteLine("{0}", maxLoss);
    }
}