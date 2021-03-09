using System;
using Xunit;
using Library;
using Cole_Project1;

namespace XUnitTestProject1
{
    
    public class UnitTests
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

        [Fact]
        public void Servicer_ValidateQuantity_TooMuch()

        {

            Assert.Throws<ArgumentException>(() => RequestProcessor.ValidateReasonableQuantity(5000));


        }

        [Fact]
        public void Servicer_ValidateCanSell_Canr()

        {
            int storequantity = 4;

            int requestquantity = 5;

            Assert.Throws<ArgumentException>(() => RequestProcessor.ValidateStoreCanSell(storequantity,requestquantity));
            

        }

        [Fact]
        public void Product_Constructor_ValidateReasonableQuantity()

        {
            //Arrange

            Product product;

            //Assert

            Assert.Throws<ArgumentException>(() => product = new Product("Semi Truck", 100000000, 1));

        }

        [Fact]
        public void Product_Constructor_ValidateReasonableName()

        {
            //Arrange

            Product product;

            //Assert

            Assert.Throws<ArgumentException>(() => product = new Product("This name is way too long and someone probably confused it with a description", 1000, 1));

        }

        [Fact]
        public void StoreLocation_Constructor_ValidateOnlyLetters()

        {
            //Arrange

            StoreLocation storeLocation;

            //Assert

            Assert.Throws<ArgumentException>(() => storeLocation = new StoreLocation("New York", "Ne!w York", "401 N Bronx.", "207-706-3042"));

        }

        [Fact]
        public void Product_Constructor_ValidateReasonableLengthCity()

        {
            //Arrange

            StoreLocation storeLocation;

            //Assert

            Assert.Throws<ArgumentException>(() => storeLocation = new StoreLocation("Whywouldacityeverneedtobethislongsajndfoanmdspofi[mdasofmoaspdfmaosdmfoasdfniasodfmoisamdfaspodmfdgo", "New York", "401 N Bronx.", "207-706-3042"));

        }


        [Fact]
        public void Product_Constructor_ValidateReasonableLengthState()

        {
            //Arrange

            StoreLocation storeLocation;

            //Assert

            Assert.Throws<ArgumentException>(() => storeLocation = new StoreLocation("OOOOOOOOOOOOOOOOOOOOOOOOOOooooooooossssssssssssssssssssssssssssssssoooooooooooooooooOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO:))))))))))))", "New York", "401 N Bronx.", "207-706-3042"));

        }

        [Fact]

        public void Formatter_FormatPhoneNumber_RemoveNonDigits()

        {
            //Arrange

            string expected = "6088844692";

            StoreLocation storeLocation = new StoreLocation("Edgerton", "Wisconsin", "501 N Main St", "608-884-4692");

            Assert.Equal(expected, storeLocation.PhoneNumber);



        }

    }
}
