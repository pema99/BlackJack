using System;

namespace BlackJack
{
	class MainClass
	{
		Deck MainDeck = new Deck();
		Hand Dealer = new Hand(2);
		Hand Player = new Hand(2);

		public static void Main(string[] args)
		{
			new MainClass().Start();	
		}

		public void Start()
		{
			Console.Clear();

			for (int i = 0; i < 2; i++)
				MainDeck.DealCard(Dealer);

			for (int i = 0; i < 2; i++)
				MainDeck.DealCard(Player);

			Console.WriteLine("-- Initial hands --");
			//1st card is secret
			Console.WriteLine("Dealer initial card: " + Dealer.Data[0]);
			Console.WriteLine("Player cards: " + Player.Data[0] + ", " + Player.Data[1]);

			Console.WriteLine("-- Start player turn --");

			while (Player.TotalPoints < 21)
			{
				Console.WriteLine("You have " + Player.TotalPoints + " points, hit? (y/n)");
				if (Console.ReadKey(true).Key == ConsoleKey.Y)
				{
					MainDeck.DealCard(Player);

					string PlayerCards = "";
					foreach (Card c in Player.Data)
						PlayerCards += c.ToString() + ", ";
					Console.WriteLine("Your cards: " + PlayerCards.Remove(PlayerCards.LastIndexOf(",")));
				}
				else
					break;
				if (Player.TotalPoints == 21)
				{
					Console.WriteLine("You have 21 points, you win!");	
					break;
				}
				if (Player.TotalPoints > 21)
				{
					Console.WriteLine("You have " + Player.TotalPoints + " points, you lose!");
					break;
				}
			}

			if (Player.TotalPoints == 21)
				Console.WriteLine("You win with 21 points.");
			
			Console.WriteLine("-- Start dealer turn --");

			if (Player.TotalPoints < 21)
			{
				string DealerCards = "";
				foreach (Card c in Dealer.Data)
					DealerCards += c.ToString() + ", ";
				Console.WriteLine("Dealer cards: " + DealerCards.Remove(DealerCards.LastIndexOf(",")) + " ("+Dealer.TotalPoints+" total)");

				while (Dealer.TotalPoints <= Player.TotalPoints)
				{
					MainDeck.DealCard(Dealer);

					DealerCards = "";
					foreach (Card c in Dealer.Data)
						DealerCards += c.ToString() + ", ";
					Console.WriteLine("Dealer cards: " + DealerCards.Remove(DealerCards.LastIndexOf(",")) + " ("+Dealer.TotalPoints+" total)");

					if (Dealer.TotalPoints == 21)
					{
						Console.WriteLine("Dealer wins with 21 points.");
						break;
					}
					if (Dealer.TotalPoints > 21)
					{
						Console.WriteLine("You win, dealer has over 21 points.");
						break;
					}
					if (Dealer.TotalPoints > Player.TotalPoints)
					{
						Console.WriteLine("Dealer wins, higher points than you.");
						break;
					}
				}
			}
		}
	}
}
