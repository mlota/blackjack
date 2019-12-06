namespace BlackJack
{
	public class Player : GameParticipant
	{
		public string Name { get; set; }

		public Player(string name)
		{
			Name = name;
		}
	}
}
