using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Repo
{
    public class EFRepository<TEntity> : IEFRepository<TEntity> where TEntity : class
        //BaseDomainClass
    {
        private DbContext _dbcontext;
        private DbSet<TEntity> _dbset;

        public EFRepository(DbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbset = dbcontext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Added;
            
            //_dbset.Add(entity);
            //_dbcontext.SaveChanges();
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null) return _dbset.AsQueryable();
            return _dbset.Where(filter);
        }

        public TEntity GetById(object id)
        {
            return _dbset.Find(id);
        }

        public void Remove(TEntity entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Deleted;
            
            //isDeleted = true;
            //_dbcontext.Entry(entity).State = EntityState.Modified;
            //veri kaybı yaşanmasını istemiyorsak üstteki kodu aktif hale getireceğiz
        }

        public void Update(TEntity entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
        }
    }
}
