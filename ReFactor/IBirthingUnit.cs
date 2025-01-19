using System.Collections.Generic;

namespace CodingAssessment.Refactor
{
    /// <summary>
    /// Defines the contract for managing and interacting with a birthing unit.
    /// </summary>
    public interface IBirthingUnit
    {
        /// <summary>
        /// Generates a list of persons with randomly assigned names and ages.
        /// </summary>
        /// <param name="numberOfPersons">The number of persons to generate.</param>
        /// <returns>
        /// A list of <see cref="Person"/> objects, each with a randomly assigned name (Bob or Betty) and age.
        /// </returns>
        public List<Person> GetPersons(int numberOfPersons);
    }
}
