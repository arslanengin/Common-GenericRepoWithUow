using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Common.Repo
{
    public interface IEFRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);

        TEntity GetById(object id);
    }
}
