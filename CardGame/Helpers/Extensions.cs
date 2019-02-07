using CardGame.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static CardGame.Helpers.Enums;

namespace CardGame.Helpers
{
    public static class Extensions
    {

        //https://en.wikipedia.org/wiki/Fisher–Yates_shuffle
        public static void Shuffle(this IList<Card> cards)
        {
            var random = new Random();

            int counter = cards.Count;
            while (counter > 1)
            {
                counter--;
                int i = random.Next(counter + 1);
                var value = cards[i];
                cards[i] = cards[counter];
                cards[counter] = value;
            }
        }

        public static void Sort(this IList<Card> cards)
        { 
            var sortedList = new List<Card>();
            var cardTypes = Enum.GetValues(typeof(CardType));
            var cardNumbers = Enum.GetValues(typeof(CardNumber));
            var count = cards.Count;

            for (int i = count - 1; i >= 0; i--)
            {
                foreach (CardType type in cardTypes)
                {
                    var types = cards.Where(x => x.CardType == type).OrderBy(x => x.CardNumber);

                    foreach (CardNumber number in cardNumbers)
                    {
                        var card = types.Where(x => x.CardNumber == number).FirstOrDefault();

                        if (card != null)
                        {
                            sortedList.Add(card);
                            cards.Remove(card);
                        }
                    }
                }
            }

            sortedList.ForEach(x => Debug.WriteLine($"{x.CardType} of {x.CardNumber}"));
            
            foreach (var item in sortedList)
            {
                cards.Add(item);
            }
        }

        public static Card Pop(this IList<Card> cards)
        {
            var lastCard = cards.LastOrDefault();
            cards.RemoveAt(cards.Count - 1);

            return lastCard;
        }

        public static string Serialize(this ICollection<Card> cards)
        {
            return JsonConvert.SerializeObject(cards);
        }

        public static IList<Card> Deserialize(this string cardsJson)
        {
            return JsonConvert.DeserializeObject<List<Card>>(cardsJson);
        }

    }
}
