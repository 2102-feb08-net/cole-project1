using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Stores relevant information to one of the chain's store location
    /// </summary>
    public class StoreLocation
    {
        /// <summary>
        /// Id from database
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// City store is located in
        /// </summary>
        public string City { get; private set; }
        /// <summary>
        /// State store is located in
        /// </summary>
        public string State { get; private set; }
        /// <summary>
        /// Address Store is located at.
        /// </summary>
        public string Address { get; private set; }
        /// <summary>
        /// Phone number to reach this location
        /// </summary>
        public string PhoneNumber { get; private set; }

        public StoreLocation(string city, string state, string address, string phoneNumber, int id = 0)
        {

            string[] checklength = { city, state, phoneNumber, address };

            string[] onlyletters = { city, state };

            ValidateLength(50, checklength);

            ValidateOnlyLetters(onlyletters);

            Id = id;

            City = city;

            State = state;

            Address = address;

            PhoneNumber = Formatter.FormatPhoneNumber(phoneNumber);


        }

        private void ValidateLength(int length, params string[] names)
        {
            foreach (var name in names)
            {
                if (name.Length > length)
                {
                    throw new ArgumentException("Location name too long");
                }
            }
        }

        private void ValidateOnlyLetters(params string[] words)
        {
            foreach (var word in words)
            {
                foreach (char letter in word)
                {
                    if (!char.IsLetterOrDigit(letter))
                    {
                        throw new ArgumentException("Character must be a letter");
                    }

                }

            }

        }




    }
}