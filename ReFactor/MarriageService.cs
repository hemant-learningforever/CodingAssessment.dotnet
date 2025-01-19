using System;
namespace CodingAssessment.Refactor
{
    public class MarriageService : IMarriageService
    {
        public string GetMarried(Person person, string lastName)
        {
            ArgumentNullException.ThrowIfNull(person);
            
            ArgumentNullException.ThrowIfNull(lastName);
            
            if (lastName.Contains("test", StringComparison.OrdinalIgnoreCase))
                return person.FirstName;

            if ((person.FirstName + lastName).Length > CommonConstants.MaxLength)
            {
                return (person.FirstName + CommonConstants.Space + lastName).Substring(0, CommonConstants.MaxLength);
            }

            return person.FirstName + CommonConstants.Space + lastName;
        }
    }
}
