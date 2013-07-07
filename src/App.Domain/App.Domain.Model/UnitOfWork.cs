using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class UnitOfWork : IDisposable
    {
        private IRepository repository;
        public UnitOfWork(IRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            this.repository = repository;
        }
        public void Dispose()
        {
            repository.Commit();
        }
    }
}