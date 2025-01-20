using CardGame.Application.Services;
using CardGame.Domain.Entities;
using CardGame.Infrastructure.Repositories;
using Moq;

namespace CardGame.Application.UnitTests.Services
{
    public class DeckServiceTests
    {
        private readonly Mock<IDeckRepository> _deckRepositoryMock;
        private readonly DeckService _deckService;

        public DeckServiceTests()
        {
            _deckRepositoryMock = new Mock<IDeckRepository>();
            _deckService = new DeckService(_deckRepositoryMock.Object);
        }

        [Fact]
        public void ShuffleDeck_WhenInvoked_ShouldCallShuffleOfDeckRepository()
        {
            // Arrange

            // Act
            _deckService.ShuffleDeck();

            // Assert
            _deckRepositoryMock.Verify(repo => repo.Shuffle(), Times.Once);
        }

        [Fact]
        public void DrawCard_WhenInvoked_ShouldCallDrawCardOfDeckRepositoryAndReturnCard()
        {
            // Arrange
            var expectedCard = new Card("Hearts", "Ace");
            _deckRepositoryMock.Setup(repo => repo.DrawCard()).Returns(expectedCard);

            // Act
            var card = _deckService.DrawCard();

            // Assert
            Assert.Equal(expectedCard, card);
            _deckRepositoryMock.Verify(repo => repo.DrawCard(), Times.Once);
        }

        [Fact]
        public void ResetDeck_WhenInvoked_ShouldCallResetDeckOfDeckRepository()
        {
            // Arrange

            // Act
            _deckService.ResetDeck();

            // Assert
            _deckRepositoryMock.Verify(repo => repo.ResetDeck(), Times.Once);
        }

        [Fact]
        public void GetAllCards_WhenInvoked_ShouldCallGetAllCardsOfDeckRepositoryAndReturnListOfCards()
        {
            // Arrange
            var expectedCards = new List<Card>
            {
                new Card("Hearts", "2"),
                new Card("Diamonds", "3")
            };
            _deckRepositoryMock.Setup(repo => repo.GetAllCards()).Returns(expectedCards);

            // Act
            var cards = _deckService.GetAllCards();

            // Assert
            Assert.Equal(expectedCards, cards);
            _deckRepositoryMock.Verify(repo => repo.GetAllCards(), Times.Once);
        }
    }
}




