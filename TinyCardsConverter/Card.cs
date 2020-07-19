using System.Collections.Generic;
using Newtonsoft.Json;

namespace TinyCardsConverter
{
    public class Card
    {
        public Card(string name, IEnumerable<string> frontAlternatives, IEnumerable<string> backAlternatives)
        {
            Name = name;
            Front = new CardView(frontAlternatives);
            Back = new CardView(backAlternatives);
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("front")]
        public CardView Front { get; set; }
        [JsonProperty("back")]
        public CardView Back { get; set; }
    }
}