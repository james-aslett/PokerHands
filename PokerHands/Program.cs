using static PokerChallenge.Cards;

namespace PokerChallenge;

public class Program
{
    public static void Main()
    {
        var playerOneWinCount = PlayGame(File.ReadLines("poker_hands.txt"));
        Console.WriteLine($"Player 1 won {playerOneWinCount} times.");
    }

    public static int PlayGame(IEnumerable<string> hands)
    {
        var playerOneWinCount = 0;

        foreach (var hand in hands)
        {
            var players = SplitPlayers(hand);
            var winner = DetermineWinner(players);
            if (winner == Player.PlayerOne)
            {
                playerOneWinCount++;
            }
        }

        return playerOneWinCount;
    }

    private static string[][] SplitPlayers(string hand)
    {
        var cleanHands = hand.Replace(" ", "");
        var player1 = PlayerHandsToArray(cleanHands[..10]);
        var player2 = PlayerHandsToArray(cleanHands[10..]);
        return new[] { player1, player2 };
    }

    private static string[] PlayerHandsToArray(string player)
    {
        var playerArray = new string[player.Length / 2];
        for (var i = 0; i < player.Length; i += 2)
        {
            playerArray[i / 2] = player.Substring(i, 2);
        }

        return playerArray;
    }

    public static Player DetermineWinner(string[][] players)
    {
        var p1Cards = players[0];
        var p2Cards = players[1];

        var (p1Score, p1Rank) = CalculateScore(p1Cards);
        var (p2Score, p2Rank) = CalculateScore(p2Cards);

        var playerOneScore = p1Score;
        var playerTwoScore = p2Score;
        var playerOneRank = p1Rank;
        var playerTwoRank = p2Rank;

        if (playerOneScore == playerTwoScore)
        {
            int playerOneTiebreakerScore = 0;
            int playerTwoTiebreakerScore = 0;

            if (playerOneRank == TiebreakerRank.FourOfAKind && playerTwoRank == TiebreakerRank.FourOfAKind)
            {
                playerOneTiebreakerScore = GetPairValue(p1Cards, TiebreakerRank.FourOfAKind);
                playerTwoTiebreakerScore = GetPairValue(p2Cards, TiebreakerRank.FourOfAKind);
            }
            else if (playerOneRank == TiebreakerRank.FullHouse && playerTwoRank == TiebreakerRank.FullHouse)
            {
                playerOneTiebreakerScore = GetPairValue(p1Cards, TiebreakerRank.FullHouse);
                playerTwoTiebreakerScore = GetPairValue(p2Cards, TiebreakerRank.FullHouse);
            }
            else if (playerOneRank == TiebreakerRank.ThreeOfAKind && playerTwoRank == TiebreakerRank.ThreeOfAKind)
            {
                playerOneTiebreakerScore = GetPairValue(p1Cards, TiebreakerRank.ThreeOfAKind);
                playerTwoTiebreakerScore = GetPairValue(p2Cards, TiebreakerRank.ThreeOfAKind);
            }
            else if (playerOneRank == TiebreakerRank.TwoPairs && playerTwoRank == TiebreakerRank.TwoPairs)
            {
                playerOneTiebreakerScore = GetPairValue(p1Cards, TiebreakerRank.TwoPairs);
                playerTwoTiebreakerScore = GetPairValue(p2Cards, TiebreakerRank.TwoPairs);
            }
            else if (playerOneRank == TiebreakerRank.OnePair && playerTwoRank == TiebreakerRank.OnePair)
            {
                playerOneTiebreakerScore = GetPairValue(p1Cards, TiebreakerRank.OnePair);
                playerTwoTiebreakerScore = GetPairValue(p2Cards, TiebreakerRank.OnePair);
            }
            if (playerOneTiebreakerScore == playerTwoTiebreakerScore)
            {
                playerOneTiebreakerScore = GetHighCard(p1Cards);
                playerTwoTiebreakerScore = GetHighCard(p2Cards);
            }

            return (playerOneTiebreakerScore > playerTwoTiebreakerScore) ? Player.PlayerOne : Player.PlayerTwo;
        }

        return (playerOneScore > playerTwoScore) ? Player.PlayerOne : Player.PlayerTwo;
    }

    private static (int score, TiebreakerRank? rank) CalculateScore(string[] cards)
    {
        if (HasRoyalFlush(cards)) return (10, null);
        if (HasStraightFlush(cards)) return (9, null);
        if (HasFourOfAKind(cards)) return (8, TiebreakerRank.FourOfAKind);
        if (HasFullHouse(cards)) return (7, TiebreakerRank.FullHouse);
        if (HasFlush(cards)) return (6, null);
        if (HasStraight(cards)) return (5, null);
        if (HasThreeOfAKind(cards)) return (4, TiebreakerRank.ThreeOfAKind);
        if (HasTwoPairs(cards)) return (3, TiebreakerRank.TwoPairs);
        if (HasOnePair(cards)) return (2, TiebreakerRank.OnePair);

        return (0, null);
    }

    public enum Player
    {
        PlayerOne,
        PlayerTwo
    }

    public enum TiebreakerRank
    {
        FourOfAKind,
        FullHouse,
        ThreeOfAKind,
        TwoPairs,
        OnePair
    }
}