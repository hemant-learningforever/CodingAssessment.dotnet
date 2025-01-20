using CardGame.Domain.Entities;


namespace CardGame.Infrastructure.Repositories
{
    /// <summary> 
    /// Implementation of IDeckRepository interface. 
    /// </summary>
    public class DeckRepository : IDeckRepository
    {
        private static readonly string[] Suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        private static readonly string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        private List<Card> _cards;

        public int Count => _cards.Count;

        public DeckRepository()
        {
            _cards = new List<Card>();
            ResetDeck();
        }

        public List<Card> GetAllCards() { return _cards; }

        public void Shuffle()
        {
            Random rng = new();
            int n = _cards.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
            }
        }

        public Card DrawCard()
        {
            if (_cards.Count == 0)
                throw new InvalidOperationException("Deck is empty");
            Card card = _cards[^1];
            _cards.RemoveAt(_cards.Count - 1);
            return card;
        }

        public void ResetDeck()
        {
            _cards.Clear();
            foreach (var suit in Suits)
            {
                foreach (var rank in Ranks)
                {
                    _cards.Add(new Card(suit, rank));
                }
            }
        }
    }
}
