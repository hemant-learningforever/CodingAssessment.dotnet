using System.Collections.Generic;

namespace CodingAssessment.Refactor
{

    /// <summary>
    /// Defines the contract for retrieval of persons.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Person with name Bob and more than 30 year old
        /// </summary>
        /// <param name="olderThan30"></param>
        /// <returns>
        /// A list of <see cref="Person"/> objects, each with a name Bob and 30 years older when compared to current date.
        /// </returns>
        public IEnumerable<Person> GetOlderThan30YearBobs(List<Person> persons);

        /// <summary>
        /// Persons with name Bob 
        /// </summary>
        /// <param name="olderThan30"></param>
        /// <returns>
        /// A list of <see cref="Person"/> objects, each with a name Bob.
        /// </returns>
        public IEnumerable<Person> GetAllBobs(List<Person> persons);
    }

}
