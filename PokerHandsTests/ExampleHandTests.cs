using static PokerChallenge.Program;

namespace PokerChallengeTests
{
    public class ExampleHandTests
    {
        [Test]
        public void HandOne()
        {
            var hands = new[] { new[] { "5H", "5C", "6S", "7S", "KD" }, new[] { "2C", "3S", "8S", "8D", "TD" } };
            var winner = DetermineWinner(hands);
            Assert.That(winner, Is.EqualTo(Player.PlayerTwo));
        }

        [Test]
        public void HandTwo()
        {
            var hands = new[] { new[] { "5D", "8C", "9S", "JS", "AC" }, new[] { "2C", "5C", "7D", "8S", "QH" } };
            var winner = DetermineWinner(hands);
            Assert.That(winner, Is.EqualTo(Player.PlayerOne));
        }

        [Test]
        public void HandThree()
        {
            var hands = new[] { new[] { "2D", "9C", "AS", "AH", "AC" }, new[] { "3D", "6D", "7D", "TD", "QD" } };
            var winner = DetermineWinner(hands);
            Assert.That(winner, Is.EqualTo(Player.PlayerTwo));
        }

        [Test]
        public void HandFour()
        {
            var hands = new[] { new[] { "4D", "6S", "9H", "QH", "QC" }, new[] { "3D", "6D", "7H", "QD", "QS" } };
            var winner = DetermineWinner(hands);
            Assert.That(winner, Is.EqualTo(Player.PlayerOne));
        }

        [Test]
        public void HandFive()
        {
            var hands = new[] { new[] { "2H", "2D", "4C", "4D", "4S" }, new[] { "3C", "3D", "3S", "9S", "9D" } };
            var winner = DetermineWinner(hands);
            Assert.That(winner, Is.EqualTo(Player.PlayerOne));
        }
    }
}