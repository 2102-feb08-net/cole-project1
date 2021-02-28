using System;

namespace Library
{
    /// <summary>
    /// Purpose of this class is to both store and validate relavant information to customers.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customers id, can not be set, only retrieved from database.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Customer's First Name
        /// </summary>
        public string FirstName { get; private set; }
        /// <summary>
        /// Customr's Last Name
        /// </summary>

        public string LastName { get; private set; }

        public Customer(string firstName, string lastName, int id = 0)
        {
            string validfirstname = ValidateAndFormatName(firstName.Trim());

            string validlastname = ValidateAndFormatName(lastName.Trim());

            FirstName = validfirstname;

            LastName = validlastname;

            Id = id;
        }

        /// <summary>
        /// Makes sure the name is only letters, and returns a formatted name with proper uppercase and whitespace trimmed.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Formatted Name</returns>

        private static string ValidateAndFormatName(string name)

        {
            // Checks whether the string is Null or Empty, throws an error if it is.

            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("There are no letters");
            }

            // Seperates string into a character array to check and make sure all characters are letters,
            // Throws an ArgumentException error if it finds a non letter

            char[] nameletters = name.ToCharArray();


            for (int i = 0; i < nameletters.Length; i++)
            {
                if (!char.IsLetter(nameletters[i]))
                {
                    throw new ArgumentException("All characters must be a letter");
                }

            }

            // Returns a formatted Name

            string formattedname = Formatter.FormatName(name);

            return formattedname;
        }
    }
}
