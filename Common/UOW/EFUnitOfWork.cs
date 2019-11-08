using Common.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.UOW
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public EFUnitOfWork(DbContext db)
        {
            if (db == null)
                throw new ArgumentNullException(nameof(_dbContext));

            _dbContext = db;
        }
        public void Dispose()
        {
            try
            {
                _dbContext.Dispose();
            }
            catch (Exception)
            {
                throw new ArgumentNullException(nameof(_dbContext.Entry));

            }

        }

        public IEFRepository<T> GetRepository<T>() where T : class
        {
            return new EFRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }


    }
}
