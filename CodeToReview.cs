using System;
using System.Collegctions.Generic;
using System.Linq;

namespace Utility.Valocity.ProfileHelper
{
    //Lets have 2 seperate files for these 2 classes People and BirthingUnit
    public class People //I would recommend to rename class  to "Person" as its giving information about indiviual
    {
     private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
     public string Name { get; private set; } // I am assuming its firstname in this case pls rename it to FirstName and corresponding parameter name in constructor would also change
     public DateTimeOffset DOB { get; private set; } //rename variable to DateOfBirth to be clear and descriptive
     public People(string name) : this(name, Under16.Date) { }
     public People(string name, DateTime dob) { //Parameter dob could be descriptive as dateOfBirth
         Name = name;
         DOB = dob;// since member DOB is of type DateTimeOffset, input parameter dob should use same type instead of DateTime

        }
    }

    public class BirthingUnit //Its better to create interface IBirthingUnit and then have this class implements this interface. Its good for depedency inversion and testing
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        public List<People> GetPeople(int i)
        {
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name // spell mistake in comment it should be random
                    string name = string.Empty;
                    var random = new Random();// Don't need to create Random  instance everytime. Instead it can be a class level
                    if (random.Next(0, 1) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation"); // you are throwing new exception here due to which original exception message will be missed instead just use throw
                }
            }
            return _people;
        }

        
        private IEnumerable<People> GetBobs(bool olderThan30) // this method is private and not used anywhere in class so we can delete this.
        {
            // for comparing Name use equals with StringComparison.OrdinalIgnoreCase to make it work for all cases 
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }

        public string GetMarried(People p, string lastName) //use descriptive name like person instead of p. Also function marriage is different from birthing so pls create a seperate class for marriage  to align with single responsibility
        {
            // check for null values of p and lastname and throw ArgumentNullException if any of them is null code will break.
            if (lastName.Contains("test"))// Lets use StringComparison.OrdinalIgnoreCase to make contains work for all cases 
                return p.Name;
            if ((p.Name.Length + lastName).Length > 255) // This should be ((p.Name + lastName).Length > 255). Also use constant for 255
            {
                (p.Name + " " + lastName).Substring(0, 255);// Return is missing here. Use constants for space  
            }

            return p.Name + " " + lastName; // use constant for space
        }
    }
}