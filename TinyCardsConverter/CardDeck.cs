using System.Collections.Generic;
using Newtonsoft.Json;

namespace TinyCardsConverter
{
    public class CardDeck
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("coverImagePath")]
        public string CoverImagePath { get; set; }
        [JsonProperty("cards")]
        public IEnumerable<Card> Cards { get; set; } = new List<Card>();
    }
}