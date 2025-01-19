namespace CodingAssessment.Refactor
{
    /// <summary>
    /// Defines the contract for handling marriage-related operations.
    /// </summary>
    public interface IMarriageService
    {
        /// <summary>
        /// Updates a person's name to include their married name.
        /// </summary>
        /// <param name="person">The <see cref="Person"/> whose name is to be updated.</param>
        /// <param name="lastName">The new last name to append.</param>
        /// <returns>
        /// A string representing the updated full name of the person.
        /// </returns>
        public string GetMarried(Person person, string lastName);
    }
}
