using System.Linq;
using NUnit.Framework;

namespace BlackJack.Tests
{
	[TestFixture]
	public class DeckFixture
	{
		[Test]
		public void ShouldContainFiftyTwoCardsWhenCreated()
		{
			var deck = new Deck();
			Assert.AreEqual(52, deck.Cards.Count);
		}

		[Test]
		public void ShouldHaveCorrectAltValueForAce()
		{
			var deck = new Deck();
			var card = deck.Cards.FirstOrDefault(x => x.FaceValue.Item1 == FaceValue.Ace);
			Assert.AreEqual(1, card.FaceValue.Item2);
			Assert.AreEqual(11, card.FaceValue.Item3);
		}

		[TestCase(FaceValue.Jack)]
		[TestCase(FaceValue.Queen)]
		[TestCase(FaceValue.King)]
		public void ShouldHaveCorrectValForRoyalCards(FaceValue faceValue)
		{
			var deck = new Deck();
			var card = deck.Cards.FirstOrDefault(x => x.FaceValue.Item1 == faceValue);
			Assert.AreEqual(10, card.FaceValue.Item2);
			Assert.AreEqual(10, card.FaceValue.Item3);
		}

		[Test]
		public void ShouldBeRandomisedAfterShuffle()
		{
			var deck = new Deck();
			deck.Shuffle();
			Assert.AreEqual(52, deck.Cards.Count);
		}
	}
}
