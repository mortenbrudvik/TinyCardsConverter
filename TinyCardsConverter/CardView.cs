using System.Collections.Generic;
using Newtonsoft.Json;

namespace TinyCardsConverter
{
    public class CardView
    {
        public CardView(IEnumerable<string> alternatives)
        {
            Alternatives.AddRange(alternatives);
        }

        [JsonProperty("alternatives")]
        public List<string> Alternatives { get; set; } = new List<string>();
    }
}