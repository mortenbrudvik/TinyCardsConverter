using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TinyCardsConverter.Test
{
    [TestFixture]
    public class TinyCardsConverterTest
    {
        [Test]
        public void Convert_EmptyFile_EmptyListReturned()
        {
            var data = CreateDecks(new List<string>());

            var converter = new TinyCardsConverter();
            var decks = converter.Convert(data);

            Console.Out.WriteLine(data);

            Assert.IsEmpty(decks);
        }

        [Test]
        public void Convert_1DeckWith0Cards_1DeckWith0CardsReturned()
        {
            var data = CreateDecks(new List<string> { CreateDeck("Deck 1") });

            var converter = new TinyCardsConverter();
            var decks = converter.Convert(data).ToList();

            Console.Out.WriteLine(data);

            Assert.That(decks.Count == 1 && decks[0].Name == "Deck 1");
        }

        [Test]
        public void Convert_2DeckWith0Cards_2DeckWith0CardsReturned()
        {
            var data = CreateDecks(new List<string> { CreateDeck("Deck 1"), CreateDeck("Deck 2") });

            var converter = new TinyCardsConverter();
            var decks = converter.Convert(data).ToList();

            Console.Out.WriteLine(data);

            Assert.That(decks.Count == 2 && decks[1].Name == "Deck 2");
        }

        [Test]
        public void Convert_1DeckWith1Cards_1DeckWith1CardsReturned()
        {
            var data = CreateDecks(new List<string> { CreateDeck("Deck 1", "", "", new List<string> {CreateCard(1)}) });

            var converter = new TinyCardsConverter();
            var decks = converter.Convert(data).ToList();

            Console.Out.WriteLine(data);
            
            Assert.That(decks.Count == 1 && decks[0].Cards.Count() == 1);
        }

        private CardDeck CreateCardDeck(string name)
        {
            return new CardDeck
            {
                Name = name,
                Description = "description",
                CoverImagePath = "https://domain.com/image/1"
            };
        }

        private string CreateCard(int numberOfCards)
        {
            var cardData = new StringBuilder();
            for (var i = 0; i < numberOfCards; i++)
            {
                cardData.AppendLine("### Card 1");
                cardData.AppendLine("Front");
                cardData.AppendLine("* " + Guid.NewGuid());
                cardData.AppendLine("* " + Guid.NewGuid());
                cardData.AppendLine();
                cardData.AppendLine("Back");
                cardData.AppendLine("* " + Guid.NewGuid());
                cardData.AppendLine("* " + Guid.NewGuid());
                cardData.AppendLine();
            }

            return cardData.ToString();
        }

        private string CreateDecks(IEnumerable<string> decks)
        {
            var cardData = new StringBuilder();

            cardData.AppendLine("name,description,coverImage,cards,privacy,language,deleted,createdAt,updatedAt");
            cardData.AppendLine();

            foreach (var deck in decks)
            {
                cardData.Append(deck);
            }

            return cardData.ToString();
        }
        
        private static string CreateDeck(string name = "deck", string description = "", string coverImagePath = "", IReadOnlyCollection<string> cards = null, string deleted = "False", string createdAt = "2020-06-07 11:18:52", string updatedAt = "2020-06-23 14:38:53")
        {
            var cardsData = new StringBuilder();

            if (cards != null)
            {
                foreach (var card in cards)
                {
                    cardsData.Append(card);
                }
            }
            var deckData = new StringBuilder();
            deckData.AppendLine($"{name},{description},{coverImagePath},\"{cardsData}\",Only me,en,{deleted},{createdAt},{updatedAt}");
            deckData.AppendLine();


            return deckData.ToString();
        }
    }
}
