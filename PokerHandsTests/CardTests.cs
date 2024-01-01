using static PokerChallenge.Cards;

namespace PokerChallengeTests
{
    public class CardTests
    {
        [Test]
        public void RoyalFlushPass()
        {
            var cards = new[] { "TC", "JH", "QD", "KH", "AH" };
            var result = HasRoyalFlush(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void RoyalFlushFail()
        {
            var cards = new[] { "9C", "JH", "QD", "KH", "AH" };
            var result = HasRoyalFlush(cards);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void StraightFlushPass()
        {
            var cards = new[] { "2C", "3C", "4C", "5C", "6C" };
            var result = HasStraightFlush(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void StraightFlushReversePass()
        {
            var cards = new[] { "6C", "5C", "4C", "3C", "2C" };
            var result = HasStraightFlush(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void StraightFlushFail()
        {
            var cards = new[] { "2C", "3C", "4D", "5C", "6C" };
            var result = HasStraightFlush(cards);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void FourOfAKindPass()
        {
            var cards = new[] { "2D", "2H", "2C", "2S", "TC" };
            var result = HasFourOfAKind(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void FourOfAKindFail()
        {
            var cards = new[] { "2D", "2H", "3C", "2S", "TC" };
            var result = HasFourOfAKind(cards);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void FullHousePass()
        {
            var cards = new[] { "2D", "2H", "2C", "3S", "3C" };
            var result = HasFullHouse(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void FullHouseFail()
        {
            var cards = new[] { "2D", "2H", "2C", "3S", "4C" };
            var result = HasFullHouse(cards);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void FlushPass()
        {
            var cards = new[] { "2C", "3C", "4C", "KC", "QC" };
            var result = HasFlush(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void FlushFail()
        {
            var cards = new[] { "2C", "3C", "4C", "KS", "QC" };
            var result = HasFlush(cards);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void StraightPass()
        {
            var cards = new[] { "7S", "8S", "9C", "TD", "JD" };
            var result = HasStraight(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void StraightReversePass()
        {
            var cards = new[] { "AD", "KC", "QS", "JC", "TD" };
            var result = HasStraight(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void StraightFail()
        {
            var cards = new[] { "2C", "3C", "5D", "4C", "7C" };
            var result = HasStraight(cards);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ThreeOfAKindPass()
        {
            var cards = new[] { "2C", "2S", "3H", "4C", "2D" };
            var result = HasThreeOfAKind(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ThreeOfAKindFail()
        {
            var cards = new[] { "2C", "2S", "3H", "4C", "3D" };
            var result = HasThreeOfAKind(cards);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TwoPairsPass()
        {
            var cards = new[] { "2C", "2S", "3H", "KC", "KD" };
            var result = HasTwoPairs(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TwoPairsFail()
        {
            var cards = new[] { "2C", "2S", "3H", "9C", "KD" };
            var result = HasTwoPairs(cards);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void OnePairPass()
        {
            var cards = new[] { "2C", "2S", "3H", "KC", "6D" };
            var result = HasOnePair(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void OnePairFail()
        {
            var cards = new[] { "2C", "7S", "3H", "KC", "6D" };
            var result = HasOnePair(cards);
            Assert.That(result, Is.EqualTo(false));
        }
    }
}