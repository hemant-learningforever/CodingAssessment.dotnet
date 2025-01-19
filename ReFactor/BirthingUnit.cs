using System;
using System.Collections.Generic;

namespace CodingAssessment.Refactor
{
    public class BirthingUnit:IBirthingUnit
    {
        /// <summary>
        /// Max persons to retrieve
        /// </summary>
        private List<Person> _persons;
        private Random random = new Random();

        public BirthingUnit()
        {
            _persons = new List<Person>();
        }

        /// <summary>
        /// Get list of persons
        /// </summary>
        /// <param name="numberOfPersons"></param>
        /// <returns>List<Person></returns>
        public List<Person> GetPersons(int numberOfPersons)
        {
            if(numberOfPersons<=0) return null;

            for (int counter = 0; counter < numberOfPersons; counter++)
            {
                try
                {
                    // Creates a random Name
                    string name;
                    if (random.Next(0, 1) == 0)
                    {
                        name = "Bob";
                    }
                    else
                    {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _persons.Add(new Person(name, 
                    DateTime.UtcNow.Subtract
                    (new TimeSpan(random.Next(18, 85) * 365, 0, 0, 0))));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return _persons;
        }
    }
}
