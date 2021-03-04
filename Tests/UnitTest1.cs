using System;
using Xunit;
using Library;

namespace XUnitTestProject1
{
    /// <summary>
    /// Tests to make sure the Customer logic class formats names properly
    /// </summary>
    public class CustomerUnitTest
    {
        [Fact]

        public void Customer_Constructor_ValidTrimFormat()

        {
            //Arrange

            string expected = "Johnathan";

            Customer customer = new Customer("joHnathAN  ", "smith");

            Assert.Equal(expected, customer.FirstName);


        }

        [Fact]
        public void Customer_Constructor_ValidateOnlyLetters()

        {
            //Arrange

            Customer customer;

            Assert.Throws<ArgumentException>(() => customer = new Customer("joHnat!hAN  ", "smith"));


        }
    }
}
