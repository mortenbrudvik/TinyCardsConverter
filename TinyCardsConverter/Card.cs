using System.Collections.Generic;

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

        public string Name { get; set; }
        public CardView Front { get; set; }
        public CardView Back { get; set; }
    }
}