using GadeliniumGroupCapstone.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SiteUserContext SiteUserContext { get; set; }

        public RepositoryBase(SiteUserContext siteUserContext)
        {
            SiteUserContext = siteUserContext;
        }

        public IQueryable<T> FindAll()
        {
            return SiteUserContext.Set<T>().AsNoTracking();

        }
        public IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression)
        {
            return SiteUserContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            SiteUserContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            SiteUserContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            SiteUserContext.Set<T>().Update(entity);
        }
    }
}
