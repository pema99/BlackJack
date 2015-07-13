using System;
using System.Collections.Generic;

namespace BlackJack
{
	public class Hand
	{
		public List<Card> Data = new List<Card>();
		public string Name;

		/// <summary>
		/// Gets the total points of this hand.
		/// </summary>
		/// <value>The total points of this hand</value>
		public int TotalPoints
		{
			get 
			{
				int Points = 0;
				foreach (Card c in Data)
				{
					Points += (int)c.Face;
				}
				return Points;
			}
		}

		public Hand (int HandSize, string Name)
		{
			Data.Capacity = HandSize;
			this.Name = Name;
		}

		/// <summary>
		/// Puts a card from this hand in a specified deck.
		/// </summary>
		public void GiveCard(Deck deck, int CardIndex)
		{
			Card card = Data[CardIndex];
			deck.Data.Add(card);
			Data.Remove(card);
		}
	}
}

