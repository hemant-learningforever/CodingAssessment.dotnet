using System;

namespace CodingAssessment.Refactor
{
    public sealed class Person
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string FirstName { get; private set; }
        public DateTimeOffset DateOfBirth { get; private set; }

        public Person(string firstName) : this(firstName, Under16.Date)
        {
        }

        public Person(string firstName, DateTimeOffset dateOfBirth)
        {
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
        }
    }
}
