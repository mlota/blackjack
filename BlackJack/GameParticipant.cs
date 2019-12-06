using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
	public class GameParticipant
	{
		public List<Card> Hand { get; set; }
		public Status Status { get; set; }

		public int HandTotalValue
		{
			get
			{
				// TODO: Requires additional logic to take into account whether an ace
				// should return 1 or an 11
				return Hand.Select(x => x.FaceValue.Item2).Aggregate((result, item) => result + item);
			}
		}

		public GameParticipant()
		{
			Hand = new List<Card>();
			Status = Status.InPlay;
		}
	}
}
