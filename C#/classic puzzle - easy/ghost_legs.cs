using System;

class Solution
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);
        string strEqual = "|--|";

        // first line
        char[] arrChar = Console.ReadLine().Replace(" ", String.Empty).ToCharArray();

        // start pos
        int[] arrInt = new int[arrChar.Length];
        for (int i = 0; i < arrInt.Length; i++) arrInt[i] = i;

        // action
        for (int i = 1; i < (H - 1); i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < arrChar.Length; j++)
            {
                int tmpColumn = arrInt[j];

                if ((tmpColumn * 3) + 4 <= W && line.Substring((tmpColumn * 3), 4).Equals(strEqual))
                    arrInt[j]++;
                else if (((tmpColumn - 1) * 3) >= 0 && line.Substring(((tmpColumn - 1) * 3), 4).Equals(strEqual))
                    arrInt[j]--;
            }
        }

        // end line
        char[] arrRes = Console.ReadLine().Replace(" ", String.Empty).ToCharArray();

        // output 
        for (int i = 0; i < arrChar.Length; i++)
            Console.WriteLine("{0}{1}", arrChar[i], arrRes[arrInt[i]]);
    }
}