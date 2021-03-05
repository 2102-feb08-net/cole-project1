using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IProductRepository
    {

        public List<Library.Product> GetAll();


        public Library.Product GetById(int id);


        public void Create(Library.Product businessproduct);




    }
}
