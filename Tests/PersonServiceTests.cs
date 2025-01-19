using Xunit;
using CodingAssessment.Refactor;

namespace Tests
{
    public class PersonServiceTests
    {
        private readonly IPersonService _personService;

        public PersonServiceTests()
        {
            _personService = new PersonService();
        }

        [Fact]
        public void PersonServicePresent_WhenObjectInstantiated_PersonServiceObjectCreated()
        {
            PersonService personService = new PersonService();
            Assert.NotNull(personService);
        }

        [Fact]
        public void GetAllBobs_WhenPersonsIsNull_ThrowsArgumentNullException()
        {
            //act
            Action act = () => _personService.GetAllBobs(null);

            //assert
            ArgumentNullException exception
             = Assert.Throws<ArgumentNullException>(act);

            Assert.Equal("persons", exception.ParamName);
        }

        [Fact]
        public void GetAllBobs_WhenPersonsDoesNotContainBob_ReturnsEmptyCollection()
        {
            //arrange
            List<Person> persons = new List<Person>();
            persons.Add(new Person("test"));

            //act
            var result = _personService.GetAllBobs(persons);

            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetAllBobs_WhenPersonsContainsBobs_ReturnsPersonsWithNameBobs()
        {

            //arrange
            List<Person> persons = new List<Person>();
            persons.Add(new Person("Bob"));
            persons.Add(new Person("bob"));
            persons.Add(new Person("test"));

            //act
            var result = _personService.GetAllBobs(persons);

            //assert
            Assert.All(result, item => Assert.Contains
            ("bob", item.FirstName, StringComparison.OrdinalIgnoreCase));

        }

        [Fact]
        public void GetOlderThan30YearBobs_WhenPersonsIsNull_ThrowsArgumentNullException()
        {
            //act
            Action act = () => _personService.GetOlderThan30YearBobs(null);

            //assert
            ArgumentNullException exception
             = Assert.Throws<ArgumentNullException>(act);

            Assert.Equal("persons", exception.ParamName);
        }

        [Fact]
        public void GetOlderThan30YearBobs_WhenPersonsDoesNotContainBob_ReturnsEmptyCollection()
        {
            //arrange
            List<Person> persons = new List<Person>();
            persons.Add(new Person("test"));

            //act
            var result = _personService.GetOlderThan30YearBobs(persons);

            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetOlderThan30YearBobs_WhenPersonsContainsBobsLessThan30YearOld_ReturnsEmptyCollection()
        {
            //arrange
            List<Person> persons = new List<Person>();
            persons.Add(new Person("bob"));

            //act
            var result = _personService.GetOlderThan30YearBobs(persons);

            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetOlderThan30YearBobs_WhenPersonsContainsBobsOlderThan30YearOld_ReturnsBobsOlderThan30years()
        {
            //arrange
            List<Person> persons = new List<Person>();
            persons.Add(new Person("bob", DateTimeOffset.UtcNow.AddYears(31)));
            persons.Add(new Person("bob", DateTimeOffset.UtcNow.AddYears(32)));
            persons.Add(new Person("bob", DateTimeOffset.UtcNow.AddYears(29)));

            //act
            var result = _personService.GetOlderThan30YearBobs(persons);

            //assert
            Assert.Empty(result);
        }
    }
}
