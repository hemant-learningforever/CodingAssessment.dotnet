using CardGame.Domain.Entities;
using CardGame.Infrastructure.Repositories;

namespace CardGame.Infrastructure.UnitTests.Repositories
{
    public class DeckRepositoryTests
    {
        private readonly DeckRepository _deckRepository;

        public DeckRepositoryTests()
        {
            _deckRepository = new DeckRepository();
        }

        [Fact]
        public void GetAllCards_WhenInvoked_ShouldReturnAll52Cards()
        {
            // Act
            var cards = _deckRepository.GetAllCards();

            // Assert
            Assert.Equal(52, cards.Count);
        }

        [Fact]
        public void Shuffle_WhenInvoked_RandomizesDeckOrder()
        {
            // Arrange
            var cardsBeforeShuffle = new List<Card>(_deckRepository.GetAllCards());

            // Act
            _deckRepository.Shuffle();
            var cardsAfterShuffle = _deckRepository.GetAllCards();

            // Assert
            Assert.NotEqual(cardsBeforeShuffle, cardsAfterShuffle);
        }

        [Fact]
        public void DrawCard_WhenInvoked_ReturnsACard()
        {
            // Act
            var card = _deckRepository.DrawCard();

            // Assert
            Assert.NotNull(card); Assert.IsType<Card>(card);
        }

        [Fact]
        public void DrawCard_WhenInvoked_DecreasesDeckSizeByOne()
        {
            // Arrange
            var initialCount = _deckRepository.GetAllCards().Count;

            // Act
            _deckRepository.DrawCard();
            var countAfterDealing = _deckRepository.GetAllCards().Count;

            // Assert
            Assert.Equal(initialCount - 1, countAfterDealing);
        }

        [Fact]
        public void DrawCard_WhenDeckIsEmpty_ThrowsInvalidOperationException()
        {
            // Arrange
            for (int i = 0; i < 52; i++)
            {
                _deckRepository.DrawCard();
            }

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _deckRepository.DrawCard());
        }

        [Fact]
        public void Reset_Should_Refill_Deck_To_52_Cards()
        {
            // Arrange
            for (int i = 0; i < 10; i++)
            {
                _deckRepository.DrawCard();
            }

            // Act
            _deckRepository.ResetDeck();
            var cards = _deckRepository.GetAllCards();

            // Assert
            Assert.Equal(52, cards.Count);
        }
    }
}




