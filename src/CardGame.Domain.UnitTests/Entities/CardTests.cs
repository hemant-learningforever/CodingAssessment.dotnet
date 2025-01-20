using CardGame.Domain.Entities;

namespace CardGame.Domain.UnitTests.Entities
{
    public class CardTests
    {

        [Fact]
        public void Card_WhenSuitAndRankIsPassedInConstuctor_CreatesCardWithGivenSuitAndRank()
        {
            // Arrange
            var suit = "Hearts";
            var rank = "Ace";

            // Act
            var card = new Card(suit, rank);

            // Assert
            Assert.Equal(suit, card.Suit); Assert.Equal(rank, card.Rank);
        }

        [Fact]
        public void Card_WhenPassedSuitAndRankIsPassedInConstuctor_ReturnsCorrectStringRepresentation()
        {
            // Arrange
            var suit = "Diamonds"; var rank = "King";
            var expectedString = "King of Diamonds";

            // Act
            var card = new Card(suit, rank);
            var actualString = card.ToString();

            // Assert
            Assert.Equal(expectedString, actualString);
        }
    }
}
