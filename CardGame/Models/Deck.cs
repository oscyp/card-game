using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CardGame.Helpers.Enums;

namespace CardGame.Models
{
    public class Deck
    {
        public IList<Card> Cards { get; private set; } = new List<Card>();

        public Deck(bool initDefaultPool = true)
        {
            if (initDefaultPool)
            {
                SetBaseDeck();
            }
        }

        private void SetBaseDeck()
        {
            foreach(CardType type in Enum.GetValues(typeof(CardType)))
            {
                foreach(CardNumber number in Enum.GetValues(typeof(CardNumber)))
                {
                    Cards.Add(new Card(type, number));
                }
            }
        }
    }
}
