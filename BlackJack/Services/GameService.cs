using System;
using BlackJack.Extensions;

namespace BlackJack.Services
{
	public class GameService
	{
		private const int NumberOfStartingCards = 2;
		private const int MaxScore = 21;
		private const int DealerLimit = 17;
		private const string DealerWinsMsg = "Dealer Wins!";
		private const string PlayerWinsMsg = "Player Wins!";

		private readonly Player _player;
		private readonly Dealer _dealer;
		private bool _isPlayersTurn = true;

		public string GameOutcome { get; set; }

		public GameService(Player player)
		{
			_player = player;
			_dealer = new Dealer();
		}

		public void StartGame()
		{
			var deck = new Deck();
			deck.Shuffle();
			_dealer.Deck = deck;
			Deal();
		}

		private void SwitchTurn()
		{
			if (_dealer.Status == Status.Bust)
			{
				GameOutcome = PlayerWinsMsg;
			}
			if (_player.Status == Status.Bust)
			{
				GameOutcome = DealerWinsMsg;
			}
			_isPlayersTurn = !_isPlayersTurn;
		}

		private Status ValidateScore<T>(T participant) where T :  GameParticipant
		{
			return participant.HandTotalValue >= MaxScore
				? Status.Bust
				: Status.InPlay;
		}

		private void CheckFinalScore(Player player, Dealer dealer)
		{
			GameOutcome = player.HandTotalValue > dealer.HandTotalValue
				? "Player Wins!"
				: "Dealer Wins!";
		}

		public void Hit()
		{
			if (!string.IsNullOrEmpty(GameOutcome))
				return;

			if (_isPlayersTurn)
			{
				_player.Hand.Add(_dealer.Deck.Cards.PopAt(GetRandomCardIndex()));
				_player.Status = ValidateScore(_player);
			}
			else
			{
				_dealer.Hand.Add(_dealer.Deck.Cards.PopAt(GetRandomCardIndex()));
				_dealer.Status = ValidateScore(_dealer);
			}
			SwitchTurn();
		}

		public void Stick()
		{
			while (_dealer.HandTotalValue < DealerLimit)
			{
				_dealer.Hand.Add(_dealer.Deck.Cards.PopAt(GetRandomCardIndex()));
			}
			_dealer.Status = ValidateScore(_dealer);
			if (_dealer.Status != Status.Bust)
			{
				CheckFinalScore(_player, _dealer);
			}
		}

		private void Deal()
		{
			for(int i = 0; i < NumberOfStartingCards; i++)
			{
				_dealer.Hand.Add(_dealer.Deck.Cards.PopAt(GetRandomCardIndex()));
				_player.Hand.Add(_dealer.Deck.Cards.PopAt(GetRandomCardIndex()));
			}
		}

		private int GetRandomCardIndex()
		{
			var rng = new Random();
			return rng.Next(_dealer.Deck.Cards.Count);
		}
	}
}
