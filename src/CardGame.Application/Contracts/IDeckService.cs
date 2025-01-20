using CardGame.Domain.Entities;

namespace CardGame.Application.Contracts
{
    /// <summary> 
    /// Interface for Deck service. 
    /// Defines the methods for shuffling, dealing, and retrieving cards from the deck. 
    /// </summary>
    public interface IDeckService
    {
        /// <summary>
        /// Shuffles the deck of cards.
        /// </summary>
        void ShuffleDeck();

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

