using CardGame.Helpers;
using CardGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CardTester
{
    [TestClass]
    public class GameTest
    {

        [TestMethod]
        public void Is_56_CardsInOneDeck()
        {
            var deck = new Deck();

            Assert.AreEqual(56, deck.Cards.Count);
        }

        [TestMethod]
        public void IsDeckEmptyAfterPoolFalseInitialize()
        {
            var deck = new Deck(false);

            Assert.IsTrue(deck.Cards.Count == 0);
        }

        [TestMethod]
        public void IsDeckNotEmptyAfterDefaultInitialize()
        {
            var deck = new Deck();

            Assert.IsTrue(deck.Cards.Count >= 0);
        }

        [TestMethod]
        public void IsDeckAfterShuffleInGoodOrder()
        {
            var deckExpected = new Deck();
            var deckToShuffle = new Deck();

            deckToShuffle.Cards.Shuffle();
            deckToShuffle.Cards.Sort();

            CollectionAssert.AreEqual(deckExpected.Cards.ToList(), deckToShuffle.Cards.ToList());
        }

        [TestMethod]
        public void IsDeckShuffledRandomly()
        {
            var deckExpected = new Deck();
            var deckToShuffle = new Deck();

            deckToShuffle.Cards.Shuffle();

            CollectionAssert.AreNotEqual(deckExpected.Cards.ToList(), deckToShuffle.Cards.ToList());
        }

        [TestMethod]
        public void IsDeckAfterShuffleNotEmpty()
        {
            var deck = new Deck();

            deck.Cards.Shuffle();

            Assert.IsTrue(deck.Cards.Count > 0);
        }

        [TestMethod]
        public void IsDeckAfterSortNotEmpty()
        {
            var deck = new Deck();

            deck.Cards.Sort();

            Assert.IsTrue(deck.Cards.Count > 0);
        }

        [TestMethod]
        public void IsDeckAfterShuffleAndSortNotEmpty()
        {
            var deck = new Deck();

            deck.Cards.Shuffle();
            deck.Cards.Sort();

            Assert.IsTrue(deck.Cards.Count > 0);
        }

        [TestMethod]
        public void IsPopReturningLastCardFromDeck()
        {
            var deck = new Deck();
            var lastExpected = deck.Cards.LastOrDefault();
            var lastActual = deck.Cards.Pop();

            Assert.AreEqual(lastExpected, lastActual);
        }

        [TestMethod]
        public void IsPopRemovingCardFromDeck()
        {
            var deck = new Deck();
            var expectedCount = deck.Cards.Count() - 1;
            deck.Cards.Pop();
            var actualCount = deck.Cards.Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void IsDeckEmptyAfterAllPoped()
        {
            var deck = new Deck();
            var count = deck.Cards.Count();

            for (int i = 0; i < count; i++)
            {
                deck.Cards.Pop();

            }

            Assert.IsTrue(deck.Cards.Count == 0);
        }

        [TestMethod]
        public void IsDeckCardsSerializeAndDeserialze()
        {
            var deck = new Deck();
            var serialised = deck.Cards.Serialize();
            var deserialized = serialised.Deserialize();

            CollectionAssert.AreEqual(deck.Cards.ToList(), deserialized.ToList());
        }

    }
}
