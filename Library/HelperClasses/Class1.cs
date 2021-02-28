using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Formatter
    {
        public static string FormatName(string Name)
        {

            char[] nameletters = Name.ToCharArray();

            //Capitalizes the first letter of the word, while lowercasing the rest.
            // !!Important!! Throws ArguementException Error if character is not a letter.

            for (int i = 0; i < nameletters.Length; i++)
            {

                if (i == 0)
                {
                    nameletters[0] = char.ToUpper(nameletters[0]);
                }
                else
                {
                    nameletters[i] = char.ToLower(nameletters[i]);
                }
            }

            return new string(nameletters);
        }

        public static string FormatPhoneNumber(string phoneNumber)
        {
            string formattedNumber = "";

            foreach (char letter in phoneNumber)
            {
                if (char.IsDigit(letter))
                {
                    formattedNumber = formattedNumber + letter;
                }
            }

            return formattedNumber;
        }


    }
}