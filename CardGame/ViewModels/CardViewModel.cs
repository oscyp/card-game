using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.ViewModels
{
    public class CardViewModel
    {
        public string CardName { get; set; }
        public int CardsInPool { get; set; } = 0;
    }
}
