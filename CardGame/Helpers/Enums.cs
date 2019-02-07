using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.Helpers
{
    public class Enums
    {
        public enum CardColor
        {
            Red,
            Black,
            None = 99
        }

        public enum CardType
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        public enum CardNumber
        {
            Ace = 0,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
        }
    }
}
