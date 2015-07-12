using System;
using System.Collections.Generic;

namespace BlackJack
{
	public class Deck
	{
		Random Shuffler = new Random();
		public List<Card> Data = new List<Card>();

		public Deck (bool Empty = false, bool Shuffle = true, int DeckSize = 52)
		{
			Data.Capacity = DeckSize;

			if (!Empty)
			{
				foreach (CardFace Face in Enum.GetValues(typeof(CardFace)))				
				{
					foreach (CardType Type in Enum.GetValues(typeof(CardType)))
					{
						Data.Add(new Card(Face, Type));
					}
				}	
			}

			if (Shuffle)
				this.Shuffle();
		}

		/// <summary>
		/// Shuffles the deck.
		/// </summary>
		public void Shuffle()
		{
			foreach (Card c in Data.ToArray())
				SwapCards(Shuffler.Next(52), Shuffler.Next(52));
		}

		/// <summary>
		/// Swaps two cards position in the deck.
		/// </summary>
		/// <param name="A">First card</param>
		/// <param name="B">Second card</param>
		public void SwapCards(int CardA, int CardB)
		{
			var TmpA = Data[CardA];
			var TmpB = Data[CardB];

			Data[CardA] = TmpB;
			Data[CardB] = TmpA;
		}

		/// <summary>
		/// Deals a random card to a hand.
		/// </summary>
		/// <param name="hand">Hand to deal a card to</param>
		public void DealCard(Hand hand)
		{
			Card card = Data[Shuffler.Next(Data.Count)];
			hand.Data.Add(card);	
			Data.Remove(card);
		}

		/// <summary>
		/// Deals a card to a hand.
		/// </summary>
		/// <param name="hand">Hand to deal a card to</param>
		public void DealCard(Hand hand, int CardIndex)
		{
			Card card = Data[CardIndex];
			hand.Data.Add(card);	
			Data.Remove(card);
		}
	}
}

