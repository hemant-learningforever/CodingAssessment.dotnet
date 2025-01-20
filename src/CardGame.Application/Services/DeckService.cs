using CardGame.Application.Contracts;
using CardGame.Domain.Entities;
using CardGame.Infrastructure.Repositories;

namespace CardGame.Application.Services
{
    /// <summary>
    /// Implements IDeckService
    /// </summary>
    public class DeckService : IDeckService
    {
        private readonly IDeckRepository _deckRepository;

        public DeckService(IDeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }

        public void ShuffleDeck() => _deckRepository.Shuffle();
        public Card DrawCard()
        {
            return _deckRepository.DrawCard();
        }

        public void ResetDeck() => _deckRepository.ResetDeck();
        public List<Card> GetAllCards() => _deckRepository.GetAllCards();
    }
}
