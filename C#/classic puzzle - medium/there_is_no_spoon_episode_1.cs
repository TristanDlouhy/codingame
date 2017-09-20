using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis

        int[,] arr = new int[width, height];

        //Console.Error.WriteLine("width: {0} height: {1}", width, height);

        for (int y = 0; y < height; y++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            char[] chars = line.ToCharArray();

            for (int x = 0; x < width; x++)
            {
                arr[x, y] = (Convert.ToInt32(Char.GetNumericValue(chars[x])) == 0) ? 0 : -1;
                //Console.Error.WriteLine("X: {0} Y: {1} Value: {2}", x, y, arr[x, y]);
            }
        }
        //Console.Error.WriteLine("width: {1} height: {0}", arr.GetLength(0), arr.GetLength(1));

        for (int y = 0; y < arr.GetLength(1); y++)
        {
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                //Console.Error.WriteLine("X: {0} Y: {1} Value: {2}", x, y, arr[x, y]);
                if (arr[x, y] == -1) continue;

                string strOutput = "";

                strOutput += string.Format("{0} {1} ", x, y);

                if ((x + 1) < width)
                    strOutput += GetNeighbourX(arr, x, y);
                else
                    strOutput += string.Format("-1 -1 ");

                if ((y + 1) < height)
                    strOutput += GetNeighbourY(arr, x, y);
                else
                    strOutput += string.Format("-1 -1 ");

                Console.WriteLine(strOutput);
            }
        }

        // SOLUTION 4 EXAMPLE
        //Console.WriteLine("0 0 1 0 0 1");
        //Console.WriteLine("1 0 -1 -1 -1 -1");
        //Console.WriteLine("0 1 -1 -1 -1 -1");
    }

    static string GetNeighbourX(int[,] arr, int curPosX, int curPosY)
    {
        for (int x = (curPosX + 1); x < arr.GetLength(0); x++)
        {
            if (arr[x, curPosY] == 0)
                return string.Format("{0} {1} ", x, curPosY);
        }
        
        return "-1 -1 ";
    }

    static string GetNeighbourY(int[,] arr, int curPosX, int curPosY)
    {
        for (int y = (curPosY + 1); y < arr.GetLength(1); y++)
        {
            if (arr[curPosX, y] == 0)
                return string.Format("{0} {1} ", curPosX, y);
        }

        return "-1 -1 ";
    }
}