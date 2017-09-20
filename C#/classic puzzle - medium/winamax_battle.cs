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
        List<Player> player = new List<Player>();
        int gameRound; 

        player.Add(new Player(1));
        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        for (int i = 0; i < n; i++)
        {
            string cardp1 = Console.ReadLine(); // the n cards of player 1
            player[0].Cards.Enqueue(new Card(cardp1));
        }

        player.Add(new Player(2));
        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++)
        {
            string cardp2 = Console.ReadLine(); // the m cards of player 2
            player[1].Cards.Enqueue(new Card(cardp2));
        }

        //Console.Error.WriteLine("Player1: Cards({0}) Player 2: Cards({1})", Players[0].Cards.Count(), Players[1].Cards.Count());

        Player winner = Game.PlayTheGame(player, out gameRound);

        //Console.Error.WriteLine("Player1: Cards({0}) Player 2: Cards({1})", Players[0].Cards.Count(), Players[1].Cards.Count());

        if (winner == null)
            Console.WriteLine("PAT");
        else 
            Console.WriteLine("{0} {1}", winner.PlayerID, gameRound);
    }
}

static class Game
{
    private static string[] pictureWeight = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    private static string[] sheetWeight = { "D", "H", "C", "S" };
    private static int warDrawCards = 3;

    public static string CompareCard(Card card1, Card card2)
    {
        string str = "";

        if (Array.IndexOf(pictureWeight, card1.Picture) > Array.IndexOf(pictureWeight, card2.Picture))
            str = "Player1";
        else if (Array.IndexOf(pictureWeight, card1.Picture) < Array.IndexOf(pictureWeight, card2.Picture))
            str = "Player2";
        else if (Array.IndexOf(pictureWeight, card1.Picture) == Array.IndexOf(pictureWeight, card2.Picture))
            str = "WAR";

        //Console.Error.WriteLine("{0} VS {1} RESULT: {2}", card1.Picture, card2.Picture, str);

        return str;
    }

    public static Player PlayTheGame(List<Player> player, out int round)
    {
        round = 0;
        string res = "";

        while (player[0].Cards.Count() != 0 && player[1].Cards.Count() != 0)
        {
            round++;

            res = CompareCard(player[0].Cards.ToArray()[0], player[1].Cards.ToArray()[0]);

            player[0].CardsOnTable.Enqueue(player[0].Cards.Dequeue());
            player[1].CardsOnTable.Enqueue(player[1].Cards.Dequeue());

            if (res.Equals("Player1") || res.Equals("Player2"))
            {
                int playerWinRound = (res.Equals("Player1")) ? 0 : 1;

                while (player[0].CardsOnTable.Count() != 0)
                    player[playerWinRound].Cards.Enqueue(player[0].CardsOnTable.Dequeue());

                while (player[1].CardsOnTable.Count() != 0)
                    player[playerWinRound].Cards.Enqueue(player[1].CardsOnTable.Dequeue());

                player[0].CardsOnTable.Clear();
                player[1].CardsOnTable.Clear();
            }
            else
            {
                round--;

                if (player[0].Cards.Count() < 3 || player[1].Cards.Count() < 3)
                {
                    res = "PAT";
                    break;
                }

                player[0].CardsOnTable.Enqueue(player[0].Cards.Dequeue());
                player[0].CardsOnTable.Enqueue(player[0].Cards.Dequeue());
                player[0].CardsOnTable.Enqueue(player[0].Cards.Dequeue());
                player[1].CardsOnTable.Enqueue(player[1].Cards.Dequeue());
                player[1].CardsOnTable.Enqueue(player[1].Cards.Dequeue());
                player[1].CardsOnTable.Enqueue(player[1].Cards.Dequeue());
            }
        } 


        if (res.Equals("Player1") || res.Equals("Player2"))
            return (res.Equals("Player1")) ? player[0] : player[1];
        else
            return null;
    }

}

class Player
{
    public Queue<Card> Cards = new Queue<Card>();
    public Queue<Card> CardsOnTable = new Queue<Card>();

    public int PlayerID { set; get; }

    public Player(int playerID)
    {
        PlayerID = playerID;
    }

}

class Card
{
    public string Value { set; get; }
    public string Picture { get { return Value.Substring(0, (Value.Count() - 1)); } }
    public string Sheet { get { return Value.Substring((Value.Count() - 1)); } }

    public Card(string value)
    {
        Value = value;
    }
}