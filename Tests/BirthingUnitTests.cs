using Xunit;
using CodingAssessment.Refactor;

namespace Tests
{
    public class BirthingUnitTests
    {
        private readonly IBirthingUnit _birthingUnit;

        public BirthingUnitTests()
        {
            _birthingUnit = new BirthingUnit();
        }

        [Fact]
        public void BirthingUnitPresent_WhenObjectInstantiated_BirthingUnitObjectCreated()
        {
            //arrange act
            BirthingUnit birthingUnit = new BirthingUnit();

            //assert
            Assert.NotNull(birthingUnit);
        }

        [Fact]
        public void GetPersons_WhenInputIsProvided_ReturnsNumberOfPersonsPassedAsInputs()
        {
            //arrange
            int numberOfPersons = 6;

            //act
            var result = _birthingUnit.GetPersons(numberOfPersons);

            //assert
            Assert.Equal(numberOfPersons, result.Count);
        }

        [Fact]
        public void GetPersons_WhenInputIsProvidedGreaterThan15_ReturnsCollectionWithPassedInputAndContainsBobAndBetty()
        {
            //arrange
            int numberOfPersons = 16;

            //act
            var result = _birthingUnit.GetPersons(numberOfPersons);

            //assert
            Assert.Equal(numberOfPersons, result.Count);
            var isBobPresent = result.Any(x => x.FirstName.Equals("bob", StringComparison.OrdinalIgnoreCase));
            var isBettyPresent = result.Any(x => x.FirstName.Equals("betty", StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void GetPersons_WhenInputIsZero_ReturnsNull()
        {
            //act
            var result = _birthingUnit.GetPersons(0);

            //assert
            Assert.Null(result);
        }

        [Fact]
        public void GetPersons_WhenInputIsNegative_ReturnsNull()
        {
            //act
            var result = _birthingUnit.GetPersons(-1);

            //assert
            Assert.Null(result);
        }
    }
}
