using Common.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        IEFRepository<T> GetRepository<T>() where T : class;
    }
}
