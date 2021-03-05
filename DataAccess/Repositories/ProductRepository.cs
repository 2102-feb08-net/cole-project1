using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductRepository : IProductRepository 
    {
        private readonly project1Context _context;
        public ProductRepository(project1Context context)
        {
            _context = context;
        }
        public List<Library.Product> GetAll()
        {
            var results = _context.Products;

            List<Library.Product> products = new List<Library.Product>();

            foreach (var result in results)
            {
                products.Add(new Library.Product(result.ProductName,result.Price.Value,result.Id));
            }
           
            return products;
        }

        public Library.Product GetById(int id)
        {
            var result = _context.Products.Where(x => x.Id == id).FirstOrDefault();

            Library.Product product = new Library.Product(result.ProductName,result.Price.Value,result.Id);

            return product;
        }

        public void Create(Library.Product businessproduct)
        {

            // ID left at default 0
            Product product = new Product() { Id = businessproduct.Id, ProductName = businessproduct.ProductName, Price = businessproduct.Price };

            _context.Add(product);

        }


    }
}
