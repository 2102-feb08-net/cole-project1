using System;

namespace Library
{
    /// <summary>
    /// Groups information about one product, offers validation on various fields.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Use to hold primary key from data base, can not be changed by User from code.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Name of Product, can not be empty
        /// </summary>
        public string ProductName { get; private set; }
        /// <summary>
        /// Products price, validated to be positive and reasonable
        /// </summary>
        public decimal Price { get; private set; }

        public Product(string productName, decimal price, int id = 0)
        {

            ValidateName(productName);

            ValidatePrice(price);

            Price = price;

            ProductName = productName;

            Id = id;
        }

        private void ValidatePrice(decimal price)
        {
            if (price < 0 || price > 1000000)
            {
                throw new ArgumentException($"Price must be reasonable {price} is not reasonable");
            }
        }

        private void ValidateName(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can not be empty");
            }


            if (name.Length > 30)
            {
                throw new ArgumentException("This is a name, not a description");
            }
        }
    }
}
