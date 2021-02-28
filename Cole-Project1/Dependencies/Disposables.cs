using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dependencies
{
    public class Disposables : IDisposable
    {
        private bool _isDisposed;

        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        public project1Context getContext()
        {
            string constring = File.ReadAllText("/Revature/Sql/connectionstring.txt");

            DbContextOptions<project1Context> options = new DbContextOptionsBuilder<project1Context>().UseSqlServer(constring).Options;

            var context = new project1Context(options);

            return context;

        }

        public CustomerRepository GetCustomerRepository()
        {
            var context = getContext();
            _disposables.Add(context);
            return new CustomerRepository(context);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    foreach (IDisposable disposable in _disposables)
                    {
                        disposable.Dispose();
                    }
                }

                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
