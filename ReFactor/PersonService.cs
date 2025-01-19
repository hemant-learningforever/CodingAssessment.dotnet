using System;
using System.Collections.Generic;
using System.Linq;


namespace CodingAssessment.Refactor
{
    public class PersonService : IPersonService
    {
        public IEnumerable<Person> GetOlderThan30YearBobs(List<Person> persons)
        {
            ArgumentNullException.ThrowIfNull(persons);
            return persons.Where(x => x.FirstName.Equals("Bob", StringComparison.OrdinalIgnoreCase)
                && x.DateOfBirth < DateTimeOffset.UtcNow.AddYears(-30));

            //(new TimeSpan(30 * 365, 0, 0, 0)))    

        }

        public IEnumerable<Person> GetAllBobs(List<Person> persons)
        {
            ArgumentNullException.ThrowIfNull(persons);
            return persons.Where(x => x.FirstName.Equals("Bob", StringComparison.OrdinalIgnoreCase));
        }
    }
}
