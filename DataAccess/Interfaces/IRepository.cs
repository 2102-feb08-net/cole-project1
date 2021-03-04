using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<T>
    {
        public List<T> GetAll();

        public T GetById(int id);

        public void Create(T item);


    }
}
