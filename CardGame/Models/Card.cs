using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CardGame.Helpers.Enums;

namespace CardGame.Models
{
    public class Card
    {
        public CardColor Color
        {
            get
            {
                switch (CardType)
                {
                    case CardType.Hearts:
                        return CardColor.Red;
                    case CardType.Spades:
                        return CardColor.Black;
                    case CardType.Clubs:
                        return CardColor.Black;
                    case CardType.Diamonds:
                        return CardColor.Red;
                    default:
                        return CardColor.None;
                }
            }
        }
        public CardType CardType { get; private set; }
        public CardNumber CardNumber { get; private set; }

        public Card(CardType cardType, CardNumber cardNumber)
        {
            CardType = cardType;
            CardNumber = cardNumber;
            
        }

        public override bool Equals(object obj)
        {
            var other = obj as Card;
            return other != null && this.CardType == other.CardType && this.CardNumber == other.CardNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Color, CardType, CardNumber);
        }
    }
}
