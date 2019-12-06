using BlackJack.Services;
using NUnit.Framework;

namespace BlackJack.Tests
{
	[TestFixture]
	public class GameServiceFixture
	{
		[Test]
		public void ShouldSetAGameOutcomeWhenPlayerSticks()
		{
			// TODO: If further time available, would have added mocking to
			// create a predictable outcome for the game
			var game = new GameService(new Player("Joe Bloggs"));
			game.StartGame();
			game.Stick();
			Assert.IsNotEmpty(game.GameOutcome);
		}

		[Test]
		public void ShouldCreateAGameOutcomeWhenPlayContinuesLongEnough()
		{
			var game = new GameService(new Player("Joe Bloggs"));
			game.StartGame();
			game.Hit();
			game.Hit();
			game.Hit();
			game.Hit();
			game.Hit();
			game.Hit();
			Assert.IsNotEmpty(game.GameOutcome);
		}
	}
}
