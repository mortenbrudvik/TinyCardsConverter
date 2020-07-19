using System;
using System.Collections.Generic;

namespace TinyCardsConverter
{
    public class CardDeck
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string CoverImagePath { get; set; }

        public IEnumerable<Card> Cards { get; set; } = new List<Card>();
        public string Privacy { get; set; }
        public string Language { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}