using CardGame.Domain.Entities;

namespace CardGame.Infrastructure.Repositories
{
    /// <summary> 
    /// Interface for Deck repository. 
    /// Defines the methods for shuffling, dealing, and retrieving cards from the deck. 
    /// </summary>
    public interface IDeckRepository
    {
        /// <summary>
        /// Shuffles the deck of cards.
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Deals one card from the deck.
        /// </summary>
        /// <returns></returns>
        Card DrawCard();

        /// <summary>
        /// Resets the deck
        /// </summary>
        void ResetDeck();

        /// <summary>
        /// Gets the list of all cards in the deck.
        /// </summary>
        /// <returns></returns>
        List<Card> GetAllCards();
    }
}
