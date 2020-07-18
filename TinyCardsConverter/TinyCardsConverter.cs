using System;
using System.Collections.Generic;

namespace TinyCardsConverter
{
    // Data Format
    //  name,description,coverImage,"cards data",privacy,language,deleted,createdAt,updatedAt
    public class TinyCardsConverter
    {
        public List<CardDeck> Convert(string csvData)
        {
            var decks = new List<CardDeck>();
            csvData = csvData.Substring(csvData.IndexOf(Environment.NewLine)); // remove first line

            var deckStartIndex = 0;
            while (true)
            {
                try
                {
                    var cardsStartIndex = csvData.IndexOf('"', deckStartIndex);
                    if (cardsStartIndex == -1)
                        break;

                    var cardsEndIndex = csvData.IndexOf('"', cardsStartIndex + 1);
                    var deckEndIndex = csvData.IndexOf(Environment.NewLine, cardsEndIndex);
                    
                    var deckDataFirstPart = csvData.Substring(0, cardsStartIndex).Trim();
                    //var cardsData = csvData.Substring(cardsStartIndex, cardsEndIndex+1 - cardsStartIndex);
                    //var deckDataLastPart = csvData.Substring(cardsEndIndex+1, deckEndIndex - cardsEndIndex);
                    //var csvDeckData = csvData.Substring(cardsStartIndex, deckEndIndex - cardsStartIndex + 1);

                    var deckDataList = deckDataFirstPart.Split(new[] {','}, StringSplitOptions.None);
                    var deck = new CardDeck()
                    {
                        Name = deckDataList[0],
                        Description = deckDataList[1],
                        CoverImagePath = deckDataList[2]
                    };

                    decks.Add(deck);

                    deckStartIndex = deckEndIndex + 1;
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Failed to parse data. Error message: " + e.Message);
                }
            }

            return decks;
        }
    }
}