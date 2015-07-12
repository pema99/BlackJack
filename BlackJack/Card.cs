using System;

namespace BlackJack
{
	public class Card
	{
		public CardFace Face;
		public CardType Type;

		public Card (CardFace Face, CardType Type)
		{
			this.Face = Face;
			this.Type = Type;
		}

		public override string ToString ()
		{
			return Type + " " + Face;
		}
	}
}

