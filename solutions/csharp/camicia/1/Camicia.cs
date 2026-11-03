using System;
using System.Collections.Generic;
using System.Linq;

public static class Camicia
{
    public enum GameStatus
    {
        Finished,
        Loop
    }

    public record GameResult(GameStatus Status, int Tricks, int Cards);

    public static GameResult SimulateGame(string[] playerA, string[] playerB)
    {
        Queue<string> a = new Queue<string>(playerA);
        Queue<string> b = new Queue<string>(playerB);

        List<string> pile = new List<string>();
        HashSet<string> states = new HashSet<string>();

        int tricks = 0;
        int cards = 0;
        int currentPlayer = 0;
        int lastPlayer = 0;
        int penalty = 0;

        while (true)
        {
            if (pile.Count == 0 && penalty == 0)
            {
                if (a.Count == 0 || b.Count == 0)
                    return new GameResult(GameStatus.Finished, tricks, cards);

                string state = GetState(a, b, currentPlayer);

                if (!states.Add(state))
                    return new GameResult(GameStatus.Loop, tricks, cards);
            }

            Queue<string> current = currentPlayer == 0 ? a : b;
            Queue<string> other = currentPlayer == 0 ? b : a;

            if (current.Count == 0)
            {
                GivePile(other, pile);
                pile.Clear();
                tricks++;

                if (a.Count == 0 || b.Count == 0)
                    return new GameResult(GameStatus.Finished, tricks, cards);

                currentPlayer = 1 - currentPlayer;
                penalty = 0;
                continue;
            }

            string card = current.Dequeue();
            pile.Add(card);
            cards++;

            int value = GetPenalty(card);

            if (value > 0)
            {
                penalty = value;
                lastPlayer = currentPlayer;
                currentPlayer = 1 - currentPlayer;
            }
            else if (penalty > 0)
            {
                penalty--;

                if (penalty == 0)
                {
                    Queue<string> winner = lastPlayer == 0 ? a : b;

                    GivePile(winner, pile);
                    pile.Clear();
                    tricks++;

                    if (a.Count == 0 || b.Count == 0)
                        return new GameResult(GameStatus.Finished, tricks, cards);

                    currentPlayer = lastPlayer;
                }
            }
            else
            {
                currentPlayer = 1 - currentPlayer;
            }
        }
    }

    private static int GetPenalty(string card)
    {
        switch (card)
        {
            case "J": return 1;
            case "Q": return 2;
            case "K": return 3;
            case "A": return 4;
            default: return 0;
        }
    }

    private static void GivePile(Queue<string> player, List<string> pile)
    {
        foreach (string card in pile)
            player.Enqueue(card);
    }

    private static string GetState(
        Queue<string> a,
        Queue<string> b,
        int currentPlayer)
    {
        string cardsA = string.Concat(
            a.Select(card => GetPenalty(card) == 0 ? "N" : card));

        string cardsB = string.Concat(
            b.Select(card => GetPenalty(card) == 0 ? "N" : card));

        return $"{cardsA}|{cardsB}|{currentPlayer}";
    }
}