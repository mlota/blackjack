using System;
using NUnit.Framework;

namespace BlackJack.Tests
{
	[TestFixture]
	public class GameParticipantFixture
	{
		[Test]
		public void ShouldGetCorrectValueForHand()
		{
			var card1 = new Card { Suit = Suit.Spades, FaceValue = Tuple.Create(FaceValue.King, 10, 10) };
			var card2 = new Card { Suit = Suit.Diamonds, FaceValue = Tuple.Create(FaceValue.Five, 5, 5) };

			var participant = new GameParticipant();
			participant.Hand.Add(card1);
			participant.Hand.Add(card2);

			Assert.AreEqual(15, participant.HandTotalValue);
		}
	}
}
