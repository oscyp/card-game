using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.Models;
using CardGame.Helpers;
using Microsoft.AspNetCore.Mvc;
using CardGame.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardGame.Controllers
{
    public class CardController : Controller
    {
        private const string CARDS = "cards";

        public IActionResult Index()
        {
            return View(new CardViewModel());
        }

        public IActionResult SetDecksCount(int count)
        {
            var cards = new List<Card>();

            for (int i = 0; i < count; i++)
            { 
                cards.AddRange(new Deck().Cards);
            }

            SerializeAndSetContext(cards);

            return View("Index", new CardViewModel() { CardsInPool = cards.Count});
        }

        public IActionResult Shuffle()
        {
            var cards = DeserializeAndGetCardsFromJson();

            cards.Shuffle();

            SerializeAndSetContext(cards);

            return View("Index", new CardViewModel() { CardsInPool = cards.Count });
        }


        public IActionResult Sort()
        {
            var cards = DeserializeAndGetCardsFromJson();

            cards.Sort();

            SerializeAndSetContext(cards);

            return View("Index", new CardViewModel() { CardsInPool = cards.Count });
        }

        public IActionResult Draw()
        {
            var cards = DeserializeAndGetCardsFromJson();
            var lastCard = cards.Pop();

            SerializeAndSetContext(cards);

            var cardViewModel = new CardViewModel() { CardName = $"{lastCard?.CardNumber} of {lastCard?.CardType}", CardsInPool = cards.Count };

            return View("Index", cardViewModel); 
        }

        private IList<Card> DeserializeAndGetCardsFromJson()
        {
            var cardsJson = HttpContext.Session.GetString(CARDS);
            return cardsJson.Deserialize();
        }

        private void SerializeAndSetContext(IList<Card> cards)
        {
            HttpContext.Session.SetString(CARDS, cards.Serialize());
        }
    }
}
