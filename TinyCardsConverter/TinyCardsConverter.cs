using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCardsConverter
{
    // Data Format: name,description,coverImage,"cards data",privacy,language,deleted,createdAt,updatedAt
    public class TinyCardsConverter
    {
        private readonly string _newLine = "\r\n";

        public IEnumerable<CardDeck> Convert(string csvData)
        {
            csvData = csvData.Substring(csvData.IndexOf(_newLine, StringComparison.Ordinal)); // remove first line

            var deckStartIndex = 0;
            while (true)
            {
                var cardsStartIndex = csvData.IndexOf('"', deckStartIndex);
                if (cardsStartIndex == -1)
                    yield break;

                var cardsEndIndex = csvData.IndexOf('"', cardsStartIndex + 1);
                var deckEndIndex = csvData.IndexOf(_newLine, cardsEndIndex, StringComparison.Ordinal);
                
                var deckDataFirstPart = csvData.Substring(deckStartIndex, cardsStartIndex- deckStartIndex).Trim();
                var cardsData = csvData.Substring(cardsStartIndex, cardsEndIndex+1 - cardsStartIndex);

                var cards = ParseCards(cardsData);
                
                var deckDataList = deckDataFirstPart.Split(new[] {','}, StringSplitOptions.None);

                deckStartIndex = deckEndIndex + 1;

                yield return new CardDeck
                {
                    Name = deckDataList[0],
                    Description = deckDataList[1],
                    CoverImagePath = deckDataList[2],
                    Cards = cards
                };

            }
        }

        private IEnumerable<Card> ParseCards(string cardsData)
        {
            static IEnumerable<string> GetAlternatives(string cardView, IEnumerable<string> lines ) => 
                lines.SkipWhile(x => x != cardView).Skip(1).TakeWhile(x => x.StartsWith("*")).Select(x=>x.Remove(0,2));
            var cards = cardsData.Trim('"').Split("###", StringSplitOptions.RemoveEmptyEntries);

            foreach (var card in cards)
            {
                var lines = card.Split(_newLine);
                var name = lines[0];
                var frontAlternatives = GetAlternatives("Front", lines); 
                var backAlternatives = GetAlternatives("Back", lines); 

                yield return new Card(name, frontAlternatives, backAlternatives);
            }
        }
    }
}