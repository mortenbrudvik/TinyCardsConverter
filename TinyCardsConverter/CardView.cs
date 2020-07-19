using System.Collections.Generic;

namespace TinyCardsConverter
{
    public class CardView
    {
        public CardView(IEnumerable<string> alternatives)
        {
            Alternatives.AddRange(alternatives);
        }

        public List<string> Alternatives { get; set; } = new List<string>();
    }
}