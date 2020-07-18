using System;
using System.Collections.Generic;
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
            var data = CreateCardData(new List<CardDeck>());

            var converter = new TinyCardsConverter();
            var decks = converter.Convert(data);

            Assert.IsEmpty(decks);
        }

        [Test]
        public void Convert_1DeckWith0Cards_1DeckWith0CardsReturned()
        {
            var data = CreateCardData(new List<CardDeck>(){CreateCardDeck("Deck 1")});

            var converter = new TinyCardsConverter();
            var decks = converter.Convert(data);

            Assert.That(decks.Count == 1 );
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
        
        private string CreateCardData(List<CardDeck> decks)
        {
            var cardData = new StringBuilder();

            cardData.AppendLine("name,description,coverImage,cards,privacy,language,deleted,createdAt,updatedAt");

            foreach (var deck in decks)
            {
                cardData.AppendLine();
                cardData.AppendLine($"{deck.Name},{deck.Description},{deck.CoverImagePath},\"\",{deck.Privacy},{deck.Language},{deck.IsDeleted},{deck.CreatedAt},{deck.UpdatedAt}");
                cardData.AppendLine();
            }

            return cardData.ToString();
        }
    }
}
