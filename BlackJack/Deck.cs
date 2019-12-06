using System;
using System.Collections.Generic;

namespace BlackJack
{
	public class Deck
	{
		public List<Card> Cards;
		
		public Deck()
		{
			Cards = new List<Card>();
			Populate();
		}

		/// <summary>
		/// Shuffles the list of cards in the current <see cref="Deck"/>.
		/// </summary>
		/// <remarks>
		/// Shuffle algorithm ref: https://stackoverflow.com/a/1262619
		/// </remarks>
		public void Shuffle()
		{
			var rng = new Random();
			int n = Cards.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				Card value = Cards[k];
				Cards[k] = Cards[n];
				Cards[n] = value;
			}
		}

		/// <summary>
		/// Populates the deck with a standard set of 52 playing cards.
		/// </summary>
		private void Populate()
		{
			var suits = Enum.GetValues(typeof(Suit));
			var faceValues = Enum.GetValues(typeof(FaceValue));
			
			foreach (Suit suit in suits)
			{
				foreach (FaceValue faceValue in faceValues)
				{
					Cards.Add(new Card
					{
						Suit = suit,
						FaceValue = GetFaceValue(faceValue)
					});
				}
			}
		}

		private Tuple<FaceValue, int, int> GetFaceValue(FaceValue faceValue)
		{
			int standardVal;
			int altVal;

			switch (faceValue)
			{
				case FaceValue.Ace:
				{
					standardVal = 1;
					altVal = 11;
					break;
				}
				case FaceValue.Jack:
				case FaceValue.Queen:
				case FaceValue.King:
				{
					standardVal = altVal = 10;
					break;
				}
				default:
					standardVal = altVal = (int) faceValue + 1;
					break;
			}

			return Tuple.Create(faceValue, standardVal, altVal);
		}
	}
}
