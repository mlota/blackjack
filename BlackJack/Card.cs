using System;

namespace BlackJack
{
	public class Card
	{
		public Suit Suit { get; set; }
		public Tuple<FaceValue, int, int> FaceValue { get; set; }
	}
}
