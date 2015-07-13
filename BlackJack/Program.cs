using System;
using System.Linq.Expressions;

namespace BlackJack
{
	class MainClass
	{
		Deck MainDeck;
		Hand Dealer;
		Hand Player;

		public static void Main(string[] args) { new MainClass().Start(); }

		public void Start()
		{
			MainDeck = new Deck();
			Dealer = new Hand(2, "Dealer");
			Player = new Hand(2, "Player");

			Console.Clear();

			for (int i = 0; i < 2; i++)
			{
				MainDeck.DealCard(Dealer);
				MainDeck.DealCard(Player);
			}

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

					PrintCards(Player);
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

			if (Player.TotalPoints < 21)
			{
				Console.WriteLine("-- Start dealer turn --");

				if (Dealer.TotalPoints > 21)
				{
					Console.WriteLine("You win, dealer has more than 21 points.");
				}

				PrintCards(Dealer);

				if (Dealer.TotalPoints > Player.TotalPoints && Dealer.TotalPoints < 21)
					Console.WriteLine("Dealer wins, more points than you.");
				if (Dealer.TotalPoints == 21)
					Console.WriteLine("Dealer wins with 21 points.");

				while (Dealer.TotalPoints <= Player.TotalPoints)
				{
					MainDeck.DealCard(Dealer);
					PrintCards(Dealer);

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

			Console.WriteLine("-- Play again? (y/n) --");

			if (Console.ReadKey(true).Key == ConsoleKey.Y)
				Start();
		}

		public void PrintCards(Hand hand)
		{
			string Cards = "";
			foreach (Card c in hand.Data)
				Cards += c.ToString() + ", ";
			Console.WriteLine(hand.Name + " cards: " + Cards.Remove(Cards.LastIndexOf(",")) + " ("+hand.TotalPoints+" total)");
		}
	}
}
