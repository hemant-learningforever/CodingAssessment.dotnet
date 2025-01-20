namespace CardGame.Domain.Entities
{
    public class Card
    {
        public string Suit { get; private set; }
        public string Rank { get; private set; }
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public override string ToString()
        { return $"{Rank} of {Suit}"; }
    }
}