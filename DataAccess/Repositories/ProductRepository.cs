using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductRepository 
    {
        private readonly project1Context _context;
        public ProductRepository(project1Context context)
        {
            _context = context;
        }
        public List<Library.Product> GetAllProducts()
        {
            var results = _context.Products;

            List<Library.Product> products = new List<Library.Product>();

            foreach (var result in results)
            {
                products.Add(new Library.Product(result.ProductName,result.Price.Value,result.Id));
            }
           
            return products;
        }

        public Library.Product GetProductById(int id)
        {
            var result = _context.Products.Where(x => x.Id == id).FirstOrDefault();

            Library.Product product = new Library.Product(result.ProductName,result.Price.Value,result.Id);

            return product;
        }


    }
}
