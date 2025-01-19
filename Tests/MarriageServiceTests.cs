using System;
using FluentAssertions;
using Xunit;
using CodingAssessment.Refactor;
namespace Tests
{
    public class MarriageServiceTests
    {
        private readonly IMarriageService _marriageService;

        public MarriageServiceTests()
        {
            _marriageService = new MarriageService();
        }

        [Fact]
        public void MarriageServiceClassPresent_WhenObjectInstantiated_MarriageServiceObjectCreated()
        {
            MarriageService marriageService = new MarriageService();
            Assert.NotNull(marriageService);
        }

        [Fact]
        public void GetMarried_WhenPersonIsnullAndLastNameNotnull_ThrowArgumentNullExcepion()
        {
            //act
            Action act = () => _marriageService.GetMarried(null, "ahire");
            //assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("person", exception.ParamName);

        }

        [Fact]
        public void GetMarried_WhenPersonIsNotnullAndLastNameIsnull_ThrowArgumentNullExcepion()
        {
            //act
            Action act = () => _marriageService.GetMarried(new Person("hemant"), null);

            //assert
            ArgumentNullException exception
             = Assert.Throws<ArgumentNullException>(act);

            Assert.Equal("lastName", exception.ParamName);

        }

        [Fact]
        public void GetMarried_WhenLastNameIsTestAndPersonHavingFirstName_ReturnPersonsFirstName()
        {
            //act
            var result = _marriageService.GetMarried(new Person("hemant"), "test");

            //assert
            Assert.Equal("hemant", result);

        }

        [Fact]
        public void GetMarried_WhenLastNameAndPersonFirstNameLengthExceeeds255_ReturnFirst255CharsFromConcatenatedFirstNameSpaceAndLastName()
        {
            //arrange
            string firstName = new string('f', 128);
            string lastName = new string('l', 128);

            var person = new Person(firstName);


            //act
            var result = _marriageService.GetMarried(person, lastName);

            //assert
            Assert.Equal((person.FirstName + CommonConstants.Space + lastName).Substring(0, 255), result);

        }

        [Fact]
        public void GetMarried_WhenLastNameAndPersonFirstNameLengthEquals255_ReturnConcatenatedFirstNameSpaceAndLasName()
        {
            //arrange
            string firstName = new string('f', 127);
            string lastName = new string('l', 128);

            var person = new Person(firstName);

            //act
            var result = _marriageService.GetMarried(person, lastName);

            //assert
            Assert.Equal(person.FirstName + CommonConstants.Space + lastName, result);

        }

        [Fact]
        public void GetMarried_WhenLastNameAndPersonFirstNameLengthLessThan255_ReturnConcatenatedFirstNameSpaceAndLasName()
        {
            //arrange
            var person = new Person("kiran");
            string lastName = "ahire";

            //act
            var result = _marriageService.GetMarried(person, lastName);

            //assert
            Assert.Equal(person.FirstName + CommonConstants.Space + lastName, result);

        }
    }
}
